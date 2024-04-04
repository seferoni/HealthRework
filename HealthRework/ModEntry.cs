using System;
using System.Collections.Generic;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace HealthRework
{	// TODO: need to implement custom event
	internal sealed class ModEntry : Mod
	{
		private readonly Dictionary<string, float> Parameters = new()
		{
			{"HealthFloor", 25f}
		};

		public override void Entry(IModHelper helper)
		{
			throw new NotImplementedException();
		}
	}
}
