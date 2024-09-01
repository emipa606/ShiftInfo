using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;

namespace ShiftInfo;

[StaticConstructorOnStartup]
public static class ShiftInfo
{
    public static int CreatedAlerts;

    public static readonly List<TimeAssignmentDef> AvailableShifts =
        DefDatabase<TimeAssignmentDef>.AllDefsListForReading;

    static ShiftInfo()
    {
        new Harmony("Mlie.ShiftInfo").PatchAll(Assembly.GetExecutingAssembly());
    }
}