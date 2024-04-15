namespace HealthRework;

#region using directives

using SharedLibrary.Classes;

#endregion

public sealed class ModConfig : ConfigClass
{
	internal Dictionary<string, IComparable> _Defaults = new()
	{
		{ "HealthRecoveredFromFoodModifier", 0 },
		{ "HealthRecoveredOnSleepOffset", 10 }
	};
	internal override Dictionary<string, IComparable> Defaults
	{
		get
		{
			return _Defaults;
		}
		set{}
	}

	public ModConfig()
	{
		ResetProperties();
	}

	[GMCMRange(0.0f, 1f)]
	[GMCMInterval(0.1f)]
	public float HealthRecoveredFromFoodModifier { get; set; }

	[GMCMRange(0, 100)]
	[GMCMInterval(1)]
	public int HealthRecoveredOnSleepOffset { get; set; }
}
