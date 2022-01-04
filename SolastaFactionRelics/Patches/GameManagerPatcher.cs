using HarmonyLib;
using SolastaFactionRelics.Models;

namespace SolastaFactionRelics.Patches
{
    internal static class GameManagerPatcher
    {
        [HarmonyPatch(typeof(GameManager), "BindPostDatabase")]
        internal static class GameManager_BindPostDatabase_Patch
        {
            internal static void Postfix()
            {
                RelicBuilder.Load();
            }
        }
    }
}
