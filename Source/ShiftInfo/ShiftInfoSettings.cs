using Verse;

namespace ShiftInfo;

/// <summary>
///     Definition of the settings for the mod
/// </summary>
internal class ShiftInfoSettings : ModSettings
{
    public bool AlwaysShow;
    public bool DarkerColors;
    public bool IncludePrisoners;
    public bool IncludeSlaves;

    /// <summary>
    ///     Saving and loading the values
    /// </summary>
    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref AlwaysShow, "AlwaysShow");
        Scribe_Values.Look(ref DarkerColors, "DarkerColors");
        Scribe_Values.Look(ref IncludePrisoners, "IncludePrisoners");
        Scribe_Values.Look(ref IncludeSlaves, "IncludeSlaves");
    }
}