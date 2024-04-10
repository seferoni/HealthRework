using System;
using StardewValley;
using SObject = StardewValley.Object;

namespace HealthRework.Common
{
	internal sealed class Utilities
	{
		private static int CurrentHealth { get; set; } = 100;
		internal static int GetHealthRecoveredOnConsumption(int healthRecovered)
		{
			var modifier = ModEntry.Config.HealthRecoveredFromFoodModifier * 0.01f;
			return (int)(modifier * healthRecovered);
		}

		internal static void SaveCurrentHealth()
		{
			CurrentHealth = Game1.player.health;
		}

		internal static void RestoreHealth()
		{
			Game1.player.health = CurrentHealth + ModEntry.Config.HealthRecoveredOnSleepOffset;
		}
	}
}
