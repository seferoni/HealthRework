namespace HealthRework.Common;

#region using directives

using StardewValley;
using SObject = StardewValley.Object;

#endregion

internal static class Utilities
{
	private static int CurrentHealth { get; set; } = 100;

	internal static int GetHealthRecoveredOnConsumption(SObject consumable, int healthRecovered)
	{
		if (consumable.QualifiedItemId == GetLifeElixirID())
		{
			return healthRecovered;
		}

		return (int)(ModEntry.Config.HealthRecoveredFromFoodModifier * healthRecovered);
	}

	internal static void SaveCurrentHealth()
	{
		CurrentHealth = Game1.player.health;
	}

	internal static void RestoreHealth()
	{
		Game1.player.health = Math.Min(Game1.player.maxHealth, CurrentHealth + ModEntry.Config.HealthRecoveredOnSleepOffset);
	}

	internal static string GetLifeElixirID()
	{
		return "(O)773";
	}
}