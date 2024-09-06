using Mlie;
using UnityEngine;
using Verse;

namespace ShiftInfo;

[StaticConstructorOnStartup]
internal class ShiftInfoMod : Mod
{
    /// <summary>
    ///     The instance of the settings to be read by the mod
    /// </summary>
    public static ShiftInfoMod instance;

    private static string currentVersion;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="content"></param>
    public ShiftInfoMod(ModContentPack content) : base(content)
    {
        instance = this;
        Settings = GetSettings<ShiftInfoSettings>();
        currentVersion = VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
    }

    /// <summary>
    ///     The instance-settings for the mod
    /// </summary>
    internal ShiftInfoSettings Settings { get; }

    /// <summary>
    ///     The title for the mod-settings
    /// </summary>
    /// <returns></returns>
    public override string SettingsCategory()
    {
        return "Shift Info";
    }

    /// <summary>
    ///     The settings-window
    ///     For more info: https://rimworldwiki.com/wiki/Modding_Tutorials/ModSettings
    /// </summary>
    /// <param name="rect"></param>
    public override void DoSettingsWindowContents(Rect rect)
    {
        var listing_Standard = new Listing_Standard();
        listing_Standard.Begin(rect);
        listing_Standard.Gap();
        listing_Standard.CheckboxLabeled("ShI.AlwaysShow".Translate(), ref Settings.AlwaysShow,
            "ShI.AlwaysShowTT".Translate());
        listing_Standard.CheckboxLabeled("ShI.IncludePrisoners".Translate(), ref Settings.IncludePrisoners,
            "ShI.IncludePrisonersTT".Translate());
        if (ModsConfig.RoyaltyActive)
        {
            listing_Standard.CheckboxLabeled("ShI.IncludeSlaves".Translate(), ref Settings.IncludeSlaves,
                "ShI.AIncludeSlavesTT".Translate());
        }
        else
        {
            Settings.IncludeSlaves = false;
        }

        if (currentVersion != null)
        {
            listing_Standard.Gap();
            GUI.contentColor = Color.gray;
            listing_Standard.Label("ShI.ModVersion".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listing_Standard.End();
    }
}