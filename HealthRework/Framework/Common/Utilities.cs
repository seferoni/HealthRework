using System;
using StardewValley;
using SObject = StardewValley.Object;

namespace HealthRework.Common
{
	internal sealed class Utilities
	{
		private static int CurrentHealth { get; set; } = 100;
		private const string LifeElixirID = "(O)773";

		internal static int GetHealthRecoveredOnConsumption(SObject consumable, int healthRecovered)
		{
			if (consumable.QualifiedItemId == LifeElixirID)
			{
				return healthRecovered;
			}

			var modifier = ModEntry.Config.HealthRecoveredFromFoodModifier * 0.01f;
			return (int)(modifier * healthRecovered);
		}

		internal static void SaveCurrentHealth()
		{
			CurrentHealth = Game1.player.health;
		}

		internal static void RestoreHealth()
		{
			Game1.player.health = Math.Min(Game1.player.maxHealth, CurrentHealth + ModEntry.Config.HealthRecoveredOnSleepOffset);
		}
	}
}
