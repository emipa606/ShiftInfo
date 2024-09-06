using System;
using System.Collections.Generic;
using System.Linq;
using RimWorld;
using UnityEngine;
using Verse;

namespace ShiftInfo;

public class Alert_Shift : Alert
{
    private readonly TimeAssignmentDef currentShift;
    private readonly List<Pawn> pawnsOnShift = [];
    private int lastUpdatedTick = 50;

    public Alert_Shift()
    {
        currentShift = ShiftInfo.AvailableShifts[ShiftInfo.CreatedAlerts];
        ShiftInfo.CreatedAlerts++;
        defaultLabel = currentShift.LabelCap;
        defaultPriority = AlertPriority.Medium;
    }

    private List<Pawn> PawnsOnShift
    {
        get
        {
            if (lastUpdatedTick < 50)
            {
                lastUpdatedTick++;
                return pawnsOnShift;
            }

            pawnsOnShift.Clear();

            Find.CurrentMap.mapPawns.FreeColonistsAndPrisonersSpawned.ForEach(x =>
            {
                if (x.timetable.CurrentAssignment != currentShift)
                {
                    return;
                }

                if (x.IsPrisonerOfColony && !ShiftInfoMod.instance.Settings.IncludePrisoners)
                {
                    return;
                }

                if (x.IsSlaveOfColony && !ShiftInfoMod.instance.Settings.IncludeSlaves)
                {
                    return;
                }

                pawnsOnShift.Add(x);
            });

            lastUpdatedTick = 0;
            return pawnsOnShift;
        }
    }

    protected override Color BGColor => currentShift.color;

    public override TaggedString GetExplanation()
    {
        lastUpdatedTick = 50;
        if (!PawnsOnShift.Any())
        {
            return "ShI.NoPawnsOnShift".Translate();
        }

        return string.Join(Environment.NewLine, PawnsOnShift.Select(Selector));

        TaggedString Selector(Pawn pawn)
        {
            if (pawn.IsSlaveOfColony)
            {
                return $"{pawn.NameFullColored} ({"Slave".Translate().ToLower()})";
            }

            if (pawn.IsPrisonerOfColony)
            {
                return $"{pawn.NameFullColored} ({"Prisoner".Translate().ToLower()})";
            }

            return pawn.NameFullColored;
        }
    }

    public override AlertReport GetReport()
    {
        defaultLabel = $"{currentShift.LabelCap}: {PawnsOnShift.Count}";
        if (PawnsOnShift.Any())
        {
            return AlertReport.CulpritsAre(PawnsOnShift);
        }

        return ShiftInfoMod.instance.Settings.AlwaysShow ? AlertReport.Active : AlertReport.Inactive;
    }
}