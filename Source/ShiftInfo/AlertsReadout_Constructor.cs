using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using RimWorld;
using Verse;

namespace ShiftInfo;

[HarmonyPatch(typeof(AlertsReadout), MethodType.Constructor)]
public static class AlertsReadout_Constructor
{
    public static void Prefix()
    {
        ShiftInfo.CreatedAlerts = 0;
    }

    public static void Postfix(List<Alert> ___AllAlerts)
    {
        ___AllAlerts.AddRange(ShiftInfo.AvailableShifts.Where(def => def != TimeAssignmentDefOf.Anything)
            .Select(_ => (Alert)Activator.CreateInstance(typeof(Alert_Shift))));

        Log.Message($"[ShiftInfo]: Created shiftalerts for {ShiftInfo.CreatedAlerts} shifts");
    }
}