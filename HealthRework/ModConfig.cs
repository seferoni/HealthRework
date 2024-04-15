namespace HealthRework;

#region using directives

using SharedLibrary.Integrations.GMCM;

#endregion

public sealed class ModConfig
{
	[GMCMRange(0, 100)]
	[GMCMInterval(1)]
	public int HealthRecoveredFromFoodModifier { get; set; } = 0;

	[GMCMRange(0, 100)]
	[GMCMInterval(1)]
	public int HealthRecoveredOnSleepOffset { get; set; } = 10;
}
