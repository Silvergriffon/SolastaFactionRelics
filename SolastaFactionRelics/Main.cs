using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using UnityModManagerNet;
using SolastaModApi;
using SolastaModApi.Extensions;
using ModKit;
using ModKit.Utility;

namespace SolastaFactionRelics
{
    public static class Main
    {
        public static readonly string MOD_FOLDER = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        [Conditional("DEBUG")]
        internal static void Log(string msg) => Logger.Log(msg);
        internal static void Error(Exception ex) => Logger?.Error(ex.ToString());
        internal static void Error(string msg) => Logger?.Error(msg);
        internal static void Warning(string msg) => Logger?.Warning(msg);
        internal static UnityModManager.ModEntry.ModLogger Logger { get; private set; }
        internal static ModManager<Core, Settings> Mod { get; private set; }
        internal static MenuManager Menu { get; private set; }
        internal static Settings Settings { get { return Mod.Settings; } }

        internal static bool Load(UnityModManager.ModEntry modEntry)
        {
            try
            {
                Logger = modEntry.Logger;

                Mod = new ModManager<Core, Settings>();
                Menu = new MenuManager();
                modEntry.OnToggle = OnToggle;

                Translations.Load(MOD_FOLDER);
            }
            catch (Exception ex)
            {
                Error(ex);
                throw;
            }

            return true;
        }

        static bool OnToggle(UnityModManager.ModEntry modEntry, bool enabled)
        {
            if (enabled)
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                Mod.Enable(modEntry, assembly);
                Menu.Enable(modEntry, assembly);
            }
            else
            {
                Menu.Disable(modEntry);
                Mod.Disable(modEntry, false);
                ReflectionCache.Clear();
            }
            return true;
        }

        internal static void OnGameReady()
        {
            StockUnitDescription ImperialSwordRelic_stock = new StockUnitDescription();
            ImperialSwordRelic_stock.SetFactionStatus("Alliance");
            ImperialSwordRelic_stock.SetInitialAmount(4);
            ImperialSwordRelic_stock.SetMaxAmount(4);
            ImperialSwordRelic_stock.SetInitialized(true);
            ImperialSwordRelic_stock.SetItemDefinition(SolastaFactionRelics.Builders.ImperialSwordRelicBuilder.ImperialSwordRelic);
            MerchantDefinition add_ImperialSwordRelic = DatabaseHelper.MerchantDefinitions.Store_Merchant_Caer_Lem_Outpost;
            add_ImperialSwordRelic.StockUnitDescriptions.Add(ImperialSwordRelic_stock);
        }
    }
}