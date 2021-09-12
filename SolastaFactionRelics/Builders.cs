using SolastaModApi;
using SolastaModApi.Extensions;

namespace SolastaFactionRelics.Builders
{
    internal class ImperialSwordRelicBuilder : BaseDefinitionBuilder<ItemDefinition>
    {
        const string ImperialSwordRelicName = "ImperialSwordRelic";
        const string ImperialSwordRelicGuid = "c7219474-8fce-4cb4-829f-5c2ae0f8e57a";

        protected ImperialSwordRelicBuilder(string name, string guid) : base(DatabaseHelper.ItemDefinitions.Longsword, name, guid)
        {
            Definition.GuiPresentation.Title = "SolastaFactionRelics/&ImperialSwordRelicTitle";
            Definition.GuiPresentation.Description = "SolastaFactionRelics/&ImperialSwordRelicDescription";
            Definition.SetRequiresIdentification(false);
            Definition.SetRequiresAttunement(false);
            Definition.SetInDungeonEditor(false);
            Definition.SetIsFactionRelic(true);
            Definition.SetFactionRelicDescription(DatabaseHelper.ItemDefinitions.CaerLem_Gate_Plaque.FactionRelicDescription);
            if (Main.Settings.maxFaction == false)
            {
                Definition.FactionRelicDescription.SetLoreValue(10);
                return;
            }
            if (Main.Settings.maxFaction == true)
            {
                Definition.FactionRelicDescription.SetLoreValue(100);
                return;
            }
            

        }

        public static ItemDefinition CreateAndAddToDB(string name, string guid)
            => new ImperialSwordRelicBuilder(name, guid).AddToDB();

        public static ItemDefinition ImperialSwordRelic = CreateAndAddToDB(ImperialSwordRelicName, ImperialSwordRelicGuid);
    }
}
