using UnityModManagerNet;
using ModKit;
using static SolastaFactionRelics.Main;

namespace SolastaFactionRelics.Menus.Viewers
{
    public class SolastaFactionRelicsMenu : IMenuSelectablePage
    {
        public string Name => "Faction Settings";

        public int Priority => 1;

        public void OnGUI(UnityModManager.ModEntry modEntry)
        {
            if (Mod == null || !Mod.Enabled) return;

            UI.Toggle("Maximum Faction", ref Main.Settings.maxFaction, 0, UI.AutoWidth());
            // UI.Toggle("Add to Gorim", ref Main.Settings.addToGorim, 0, UI.AutoWidth());
            UI.Toggle("Restock Relics", ref Main.Settings.relicRestock, 0, UI.AutoWidth());
        }
    }
}

