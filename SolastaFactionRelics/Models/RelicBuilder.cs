using SolastaModApi;
using SolastaModApi.Extensions;
using static SolastaModApi.DatabaseHelper.ItemDefinitions;
using static SolastaModApi.DatabaseHelper.MerchantDefinitions;

namespace SolastaFactionRelics.Models
{
	internal static class RelicBuilder
	{
		internal static void Load()
		{
			ItemDefinition ImperialSwordRelic = ImperialSwordRelicBuilder.CreateAndAddToDB(
			"ImperialSwordRelic",
			"c7219474-8fce-4cb4-829f-5c2ae0f8e57a",
			"SolastaFactionRelics/&ImperialSwordRelicTitle",
			"SolastaFactionRelics/&ImperialSwordRelicDescription",
			Longsword);
		}
		internal class ImperialSwordRelicBuilder : BaseDefinitionBuilder<ItemDefinition>
		{
			protected ImperialSwordRelicBuilder(string name, string guid, string title, string description, ItemDefinition original) : base(original, name, guid)
			{
				Definition.GuiPresentation.Title = title;
				Definition.GuiPresentation.Description = description;
				Definition.SetRequiresIdentification(false);
				Definition.SetRequiresAttunement(false);
				Definition.SetInDungeonEditor(false);
				Definition.ItemTags.Clear();
				Definition.ItemTags.Add("Metal");
				Definition.SetIsFactionRelic(true);
				Definition.SetFactionRelicDescription(CaerLem_Gate_Plaque.FactionRelicDescription);
				Definition.FactionRelicDescription.SetLoreValue(10);

				
				var stockRelics = new StockUnitDescription();
				
				stockRelics.SetItemDefinition(Definition);
				stockRelics.SetInitialAmount(4);
				stockRelics.SetInitialized(true);
				stockRelics.SetFactionStatus("Indifference");
				stockRelics.SetMaxAmount(4);
				stockRelics.SetMinAmount(1);
				stockRelics.SetReassortAmount(4);
				stockRelics.SetReassortRateType(RuleDefinitions.DurationType.Day);
				stockRelics.SetReassortRateValue(1);
				
				
				Store_Merchant_Caer_Lem_Outpost.StockUnitDescriptions.Add(stockRelics);
				
			}
			
			internal static ItemDefinition CreateAndAddToDB(string name, string guid, string title, string description, ItemDefinition original) =>	new ImperialSwordRelicBuilder(name, guid, title, description, original).AddToDB();
			

				
		}
	}
}