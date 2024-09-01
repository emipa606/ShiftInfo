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
            Find.CurrentMap.mapPawns.FreeColonists.ForEach(x =>
            {
                if (x.timetable.CurrentAssignment == currentShift)
                {
                    pawnsOnShift.Add(x);
                }
            });
            lastUpdatedTick = 0;
            return pawnsOnShift;
        }
    }

    protected override Color BGColor => currentShift.color;

    public override TaggedString GetExplanation()
    {
        lastUpdatedTick = 50;
        if (PawnsOnShift.Any())
        {
            return string.Join(Environment.NewLine, PawnsOnShift.Select(pawn => pawn.NameFullColored));
        }

        return "ShI.NoPawnsOnShift".Translate();
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