using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using RimWorld;

namespace ShiftInfo;

[HarmonyPatch(typeof(AlertsReadout), "CheckAddOrRemoveAlert")]
public static class AlertsReadout_CheckAddOrRemoveAlert
{
    public static void Postfix(ref List<Alert> ___activeAlerts)
    {
        ___activeAlerts = ___activeAlerts.OrderBy(alert => alert is not Alert_Shift).ToList();
    }
}