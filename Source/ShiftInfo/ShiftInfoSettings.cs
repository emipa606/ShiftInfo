using Verse;

namespace ShiftInfo;

/// <summary>
///     Definition of the settings for the mod
/// </summary>
internal class ShiftInfoSettings : ModSettings
{
    public bool AlwaysShow;

    /// <summary>
    ///     Saving and loading the values
    /// </summary>
    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref AlwaysShow, "AlwaysShow");
    }
}