using UnityModManagerNet;
using ModKit;
using static SolastaFactionRelics.Main;
using UnityEngine;
using UnityEngine.UI;


namespace SolastaFactionRelics.Menus.Viewers
{
    public class SolastaFactionRelicsMenu : IMenuSelectablePage
    {
        public string Name => "Faction Settings";

        public int Priority => 1;


        public void OnGUI(UnityModManager.ModEntry modEntry)
        {
            if (Main.Mod == null || !Main.Mod.Enabled) return;

            /*bool toggle;

            UI.Label("");
            toggle = Main.Settings.maxFaction;
            if (UI.Toggle("Maximum Faction", ref toggle, UI.AutoWidth()))
            {
                Main.Settings.maxFaction = toggle;
            }
            */
  
            
        }
    }
}

