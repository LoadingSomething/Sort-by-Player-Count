using HarmonyLib;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SortByPlayersButton.Patches {
    [HarmonyPatch]
    internal class MenuManagerPatch {
        [HarmonyPostfix]
        [HarmonyPatch(typeof(MenuManager), "Start")]
        private static void AddSortButton() {
            GameObject refreshButtonObject = GameObject.Find("/Canvas/MenuContainer/LobbyList/ListPanel/RefreshButton");
            if (refreshButtonObject != null) {
                GameObject sortButtonObject = Object.Instantiate(refreshButtonObject.gameObject, refreshButtonObject.transform.parent);
                sortButtonObject.GetComponent<RectTransform>().anchoredPosition += new Vector2(0f, 18f);
                sortButtonObject.GetComponentInChildren<TextMeshProUGUI>().text = "[ Sort ]";
                Button sortButton = sortButtonObject.GetComponent<Button>();
                sortButton.onClick = new Button.ButtonClickedEvent();
                sortButton.onClick.AddListener(() => {
                    LobbySlot[] lobbySlots = Object.FindObjectsOfType<LobbySlot>();
                    lobbySlots = lobbySlots.OrderByDescending(lobby => int.Parse(lobby.playerCount.text.Split(' ')[0])).ToArray();
                    float lobbySlotPositionOffset = 0f;
                    for (int i = 0; i < lobbySlots.Length; i++) {
                        lobbySlots[i].gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, lobbySlotPositionOffset);
                        lobbySlotPositionOffset -= 42f;
                    }
                });
            }
        }
    }
}