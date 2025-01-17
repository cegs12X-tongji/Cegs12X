﻿using System.Collections.Generic;
using static AeonHacs.Utilities.Utility;
using System.Linq;

namespace AeonHacs.Components;

public partial class Cegs12X : Cegs
{
    #region HacsComponent
    #endregion HacsComponent

    #region System configuration
    #region HacsComponents
    #endregion HacsComponents
    #endregion System configuration

    #region Process Management

    protected override void BuildProcessDictionary()
    {
        Separators.Clear();

        // Running samples
        ProcessDictionary["Run samples"] = RunSamples;
        Separators.Add(ProcessDictionary.Count);

        // Preparation for running samples
        ProcessDictionary["Prepare GRs for new iron and desiccant"] = PrepareGRsForService;
        ProcessDictionary["Precondition GR iron"] = PreconditionGRs;
        ProcessDictionary["Replace iron in sulfur traps"] = ChangeSulfurFe;
        ProcessDictionary["Prepare loaded inlet ports for collection"] = PrepareIPsForCollection;
        Separators.Add(ProcessDictionary.Count);

        ProcessDictionary["Prepare carbonate sample for acid"] = PrepareCarbonateSample;
        ProcessDictionary["Load acidified carbonate sample"] = LoadCarbonateSample;
        Separators.Add(ProcessDictionary.Count);

        // Open line
        ProcessDictionary["Open and evacuate line"] = OpenLine;
        Separators.Add(ProcessDictionary.Count);

        // Main process continuations
        ProcessDictionary["Collect, etc."] = CollectEtc;
        ProcessDictionary["Extract, etc."] = ExtractEtc;
        ProcessDictionary["Measure, etc."] = MeasureEtc;
        ProcessDictionary["Graphitize, etc."] = GraphitizeEtc;
        Separators.Add(ProcessDictionary.Count);

        // Top-level steps for main process sequence
        ProcessDictionary["Admit sealed CO2 to InletPort"] = AdmitSealedCO2IP;
        ProcessDictionary["Collect CO2 from InletPort"] = Collect;
        ProcessDictionary["Extract"] = Extract;
        ProcessDictionary["Measure"] = Measure;
        ProcessDictionary["Discard excess CO2 by splits"] = DiscardSplit;
        ProcessDictionary["Remove sulfur"] = RemoveSulfur;
        ProcessDictionary["Dilute small sample"] = Dilute;
        ProcessDictionary["Graphitize aliquots"] = GraphitizeAliquots;
        Separators.Add(ProcessDictionary.Count);

        // Secondary-level process sub-steps
        ProcessDictionary["Evacuate Inlet Port"] = EvacuateIP;
        ProcessDictionary["Flush Inlet Port"] = FlushIP;
        ProcessDictionary["Admit O2 into Inlet Port"] = AdmitIPO2;
        ProcessDictionary["Heat Quartz and Open Line"] = HeatQuartzOpenLine;
        ProcessDictionary["Turn off IP furnaces"] = TurnOffIPFurnaces;
        ProcessDictionary["Discard IP gases"] = DiscardIPGases;
        ProcessDictionary["Close IP"] = CloseIP;
        ProcessDictionary["Start collecting"] = StartCollecting;
        ProcessDictionary["Clear collection conditions"] = ClearCollectionConditions;
        ProcessDictionary["Collect until condition met"] = CollectUntilConditionMet;
        ProcessDictionary["Stop collecting"] = StopCollecting;
        ProcessDictionary["Stop collecting immediately"] = StopCollectingImmediately;
        ProcessDictionary["Stop collecting after bleed down"] = StopCollectingAfterBleedDown;
        ProcessDictionary["Evacuate and Freeze VTT"] = FreezeVtt;
        ProcessDictionary["Admit Dead CO2 into MC"] = AdmitDeadCO2;
        ProcessDictionary["Purify CO2 in MC"] = CleanupCO2InMC;
        ProcessDictionary["Discard MC gases"] = DiscardMCGases;
        ProcessDictionary["Divide sample into aliquots"] = DivideAliquots;
        Separators.Add(ProcessDictionary.Count);

        // Granular inlet port & sample process control
        ProcessDictionary["Turn on quartz furnace"] = TurnOnIpQuartzFurnace;
        ProcessDictionary["Turn off quartz furnace"] = TurnOffIpQuartzFurnace;
        ProcessDictionary["Turn on sample furnace"] = TurnOnIpSampleFurnace;
        ProcessDictionary["Adjust sample setpoint"] = AdjustIpSetpoint;
        ProcessDictionary["Wait for sample to rise to setpoint"] = WaitIpRiseToSetpoint;
        ProcessDictionary["Wait for sample to fall to setpoint"] = WaitIpFallToSetpoint;
        ProcessDictionary["Turn off sample furnace"] = TurnOffIpSampleFurnace;
        Separators.Add(ProcessDictionary.Count);

        // General-purpose process control actions
        ProcessDictionary["Wait for timer"] = WaitForTimer;
        ProcessDictionary["Wait for operator"] = WaitForOperator;
        Separators.Add(ProcessDictionary.Count);

        // Transferring CO2
        ProcessDictionary["Transfer CO2 from CT to VTT"] = TransferCO2FromCTToVTT;
        ProcessDictionary["Transfer CO2 from MC to VTT"] = TransferCO2FromMCToVTT;
        ProcessDictionary["Transfer CO2 from MC to GR"] = TransferCO2FromMCToGR;
        ProcessDictionary["Transfer CO2 from prior GR to MC"] = TransferCO2FromGRToMC;
        Separators.Add(ProcessDictionary.Count);

        // Utilities (generally not for sample processing)
        ProcessDictionary["Exercise all Opened valves"] = ExerciseAllValves;
        ProcessDictionary["Close all Opened valves"] = CloseAllValves;
        ProcessDictionary["Exercise all LN Manifold valves"] = ExerciseLNValves;
        ProcessDictionary["Calibrate all multi-turn valves"] = CalibrateRS232Valves;
        ProcessDictionary["Measure MC volume (KV in MCP2)"] = MeasureVolumeMC;
        ProcessDictionary["Measure valve volumes (plug in MCP2)"] = MeasureValveVolumes;
        ProcessDictionary["Measure remaining chamber volumes"] = MeasureRemainingVolumes;
        ProcessDictionary["Check GR H2 density ratios"] = CalibrateGRH2;
        ProcessDictionary["Calibrate VP He initial manifold pressure"] = CalibrateVPHeP0;
        ProcessDictionary["Measure Extraction efficiency"] = MeasureExtractEfficiency;
        ProcessDictionary["Measure IP collection efficiency"] = MeasureIpCollectionEfficiency;
        Separators.Add(ProcessDictionary.Count);

        // Test functions
        ProcessDictionary["Test"] = Test;
    }

    #region Process Control Parameters
    #endregion Process Control Parameters

    #region Process Control Properties
    #endregion Process Control Properties

    #region Process Steps
    #endregion Process Steps

    #endregion Process Management

    #region Test functions

    /// <summary>
    /// General-purpose code tester. Put whatever you want here.
    /// </summary>
    protected override void Test()
    {
        //var grs = new List<IHeater>()
        //{
        //    Find<IHeater>("hGR2"),
        //    Find<IHeater>("hGR4"),
        //    Find<IHeater>("hGR6"),
        //    Find<IHeater>("hGR8"),
        //    Find<IHeater>("hGR10"),
        //    Find<IHeater>("hGR12")
        //}.ToArray();
        //PidStepTest(grs);
        //return;

        //CalibrateManualHeaters();
        //return;

        //var ips = new List<IInletPort>()
        //{
        //    Find<IInletPort>("IP2"),
        //    Find<IInletPort>("IP4"),
        //    Find<IInletPort>("IP6"),
        //    Find<IInletPort>("IP8"),
        //    Find<IInletPort>("IP10"),
        //    Find<IInletPort>("IP12")
        //};
        //ips.ForEach(ip => ip.QuartzFurnace.TurnOn());
        //WaitMinutes(10);
        //PidStepTest(ips.Select(ip => ip.SampleFurnace).Cast<IHeater>().ToArray());
        //ips.ForEach(ip => ip.QuartzFurnace.TurnOff());
        //return;

        //VttWarmStepTest();
        //return;

        //TestPressurize("H2.GM", 100);
        //TestPressurize("H2.GM", 900);
        //TestPressurize("He.MC", 80);
        //TestPressurize("He.GM", 800);
        //TestAdmit("He.GM", 800);
        //TestAdmit("He.IM", 800);
        //TestPressurize("CO2.MC", 75);
        TestPressurize("CO2.MC", 850);
        //TestAdmit("O2.IM", 1350);
        return;

        //TestValveRaceCondition();
        //return;
    }

    #endregion Test functions
}