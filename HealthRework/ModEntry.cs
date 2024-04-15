#region global using directives

global using System;

#endregion

namespace HealthRework;

#region using directives

using SharedLibrary.Interfaces.GMCM;
using SharedLibrary.Integrations.GMCM;
using StardewModdingAPI;
using HarmonyLib;
using SObject = StardewValley.Object;
using StardewModdingAPI.Events;
using HealthRework.Interfaces;
using HealthRework.Common;

#endregion

internal sealed class ModEntry : Mod
{
	internal static ModConfig Config { get; set; } = null!;

	public override void Entry(IModHelper helper)
	{
		Config = Helper.ReadConfig<ModConfig>();
		Harmony harmonyInstance = new(ModManifest.UniqueID);

		harmonyInstance.Patch(
			original: AccessTools.Method(typeof(SObject), nameof(SObject.healthRecoveredOnConsumption)),
			postfix: new HarmonyMethod(typeof(HarmonyPatcher), nameof(HarmonyPatcher.HealthRecoveredOnConsumption_PostFix))
		);

		helper.Events.GameLoop.GameLaunched += GameLaunched;
		helper.Events.GameLoop.DayEnding += DayEnding;
		helper.Events.GameLoop.Saving += Saving;
	}

	private void Saving(object? sender, SavingEventArgs e)
	{
		Utilities.RestoreHealth();
	}

	private void DayEnding(object? sender, DayEndingEventArgs e)
	{
		Utilities.SaveCurrentHealth();
	}
	private void GameLaunched(object? sender, GameLaunchedEventArgs e)
	{
		SetupConfig();
	}

	private void SetupConfig()
	{
		var api = Helper.ModRegistry.GetApi<IGenericModConfigMenuApi>("spacechase0.GenericModConfigMenu");

		if (api is null)
		{
			return;
		}

		GMCMHelper configHelper = new(api, Helper, ModManifest);
		configHelper.Build(Config);
	}
}

