using BepInEx;
using HarmonyLib;
using System.Reflection;

namespace SortByPlayersButton {
    [BepInPlugin(modGUID, modName, modVer)]
    public class SortByPlayersButtonPlugin : BaseUnityPlugin {
        private const string modGUID = "loadingsomething.SortByPlayersButton";
        private const string modName = "SortByPlayersButton";
        private const string modVer = "1.0.1";

        private void Awake() {
            Harmony harmony = new Harmony(modGUID);
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
