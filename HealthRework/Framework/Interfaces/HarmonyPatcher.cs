﻿namespace HealthRework.Interfaces;

#region using directives

using HealthRework.Common;
using SObject = StardewValley.Object;

#endregion

internal static class HarmonyPatcher
{
	private static IMonitor Monitor { get; set; } = null!;

	internal static void InitialiseMonitor(IMonitor monitorInstance)
	{
		Monitor = monitorInstance;
	}

	internal static void HealthRecoveredOnConsumption_PostFix(SObject __instance, ref int __result)
	{
		try
		{
			__result = Utilities.GetHealthRecoveredOnConsumption(__instance, __result);
		}
		catch(Exception ex)
		{
			Monitor.Log($"[Health Rework] Method patch failed! \nReason: {ex}", LogLevel.Error);
		}
	}
}