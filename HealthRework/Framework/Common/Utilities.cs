using System;
using StardewValley;
using SObject = StardewValley.Object;

namespace HealthRework.Common
{
	internal class Utilities
	{
		internal static int CurrentHealth = 100;
		internal static int GetHealthRecoveredOnConsumption(int healthRecovered)
		{
			return ModEntry.Config.HealthRecoveredModifier * healthRecovered;
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
