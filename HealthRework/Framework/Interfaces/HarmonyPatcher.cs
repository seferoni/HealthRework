using System;
using StardewModdingAPI;
using SObject = StardewValley.Object;
using HealthRework.Common;

namespace HealthRework.Interfaces
{
	internal class HarmonyPatcher
	{
		private static IMonitor Monitor { get; set; } = null!;

		internal static void InitialiseMonitor(IMonitor monitorInstance)
		{
			Monitor = monitorInstance;
		}

		internal static void HealthRecoveredOnConsumption_PostFix(SObject __instance, int __result)
		{
			try
			{
				__result = Utilities.GetHealthRecoveredOnConsumption(__result);
			}
			catch(Exception ex)
			{
				Monitor.Log($"[Health Rework] Method patch failed! \nReason: {ex}", LogLevel.Error);
			}
		}
	}
}
