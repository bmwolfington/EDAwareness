﻿namespace EDAwareness.Core.Journal
{
    public enum JournalEventType
    {
        Unknown,

        AfmuRepairs,
        ApproachBody,
        ApproachSettlement,
        AppliedToSquadron,
        AsteroidCracked,
        Backpack,
        BackpackChange,
        BookDropship,
        BookTaxi,
        Bounty,
        BuyAmmo,
        BuyDrones,
        BuyExplorationData,
        BuyMicroResources,
        BuySuit,
        BuyWeapon,
        BuyTradeData,
        CancelDropship,
        CancelTaxi,
        CapShipBond,
        Cargo,
        CargoDepot,
        CargoTransfer,
        CarrierBankTransfer,
        CarrierBuy,
        CarrierCancelDecommission,
        CarrierCrewServices,
        CarrierDecommission,
        CarrierDepositFuel,
        CarrierDockingPermission,
        CarrierFinance,
        CarrierJumpRequest,
        CarrierJump,
        CarrierModulePack,
        CarrierShipPack,
        CarrierStats,
        CarrierTradeOrder,
        CarrierNameChange,
        CarrierJumpCancelled,
        ChangeCrewRole,
        ClearSavedGame,
        ClearImpound,
        CockpitBreached,
        CodexEntry,
        CollectCargo,
        CollectItems,
        Commander,
        CommitCrime,
        CommunityGoal,
        CommunityGoalJoin,
        CommunityGoalReward,
        CommunityGoalDiscard,
        Continued,
        CreateSuitLoadout,
        CrewAssign,
        CrewFire,
        CrewHire,
        CrewLaunchFighter,
        CrewMemberJoins,
        CrewMemberQuits,
        CrewMemberRoleChange,
        CrimeVictim,
        DataScanned,
        DatalinkScan,
        DatalinkVoucher,
        DeleteSuitLoadout,
        Died,
        DiscoveryScan,
        DisbandedSquadron,
        Disembark,
        Docked,
        DockFighter,
        DockingCancelled,
        DockingDenied,
        DockingGranted,
        DockingRequested,
        DockingTimeout,
        DockSRV,
        DropItems,
        DropshipDeploy,
        EjectCargo,
        EndCrewSession,
        EngineerApply,
        EngineerContribution,
        EngineerCraft,
        EngineerLegacyConvert,
        EngineerProgress,
        Embark,
        EscapeInterdiction,
        FactionKillBond,
        FCMaterials,
        FetchRemoteModule,
        FSDJump,
        FSDTarget,
        FSSAllBodiesFound,
        FuelScoop,
        Fileheader,
        FighterDestroyed,
        FighterRebuilt,
        Friends,
        FSSDiscoveryScan,
        FSSSignalDiscovered,
        FSSBodySignals,
        HeatDamage,
        HeatWarning,
        HullDamage,
        Interdicted,
        Interdiction,
        InvitedToSquadron,
        JoinedSquadron,
        JetConeBoost,
        JetConeDamage,
        JoinACrew,
        KickCrewMember,
        KickedFromSquadron,
        LaunchDrone,
        LaunchFighter,
        LaunchSRV,
        LeftSquadron,
        LeaveBody,
        Liftoff,
        LoadGame,
        Loadout,
        LoadoutEquipModule,
        LoadoutRemoveModule,
        Location,
        MassModuleStore,
        Market,
        MarketBuy,
        MarketSell,
        MaterialCollected,
        MaterialDiscarded,
        MaterialDiscovered,
        MaterialTrade,
        Materials,
        MiningRefined,
        Missions,
        MissionAbandoned,
        MissionAccepted,
        MissionCompleted,
        MissionFailed,
        MissionRedirected,
        ModuleInfo,
        ModuleBuy,
        ModuleBuyAndStore,
        ModuleRetrieve,
        ModuleSell,
        ModuleSellRemote,
        ModuleStore,
        ModuleSwap,
        MultiSellExplorationData,
        Music,
        NavBeaconScan,
        NavRoute,
        NavRouteClear,
        NewCommander,
        NpcCrewPaidWage,
        NpcCrewRank,
        Outfitting,
        Passengers,
        PayFines,
        PayBounties,
        PayLegacyFines,
        Powerplay,
        PowerplayCollect,
        PowerplayDefect,
        PowerplayDeliver,
        PowerplayFastTrack,
        PowerplayJoin,
        PowerplayLeave,
        PowerplaySalary,
        PowerplayVote,
        PowerplayVoucher,
        Progress,
        Promotion,
        ProspectedAsteroid,
        PVPKill,
        QuitACrew,
        Rank,
        RebootRepair,
        ReceiveText,
        RedeemVoucher,
        RefuelAll,
        RefuelPartial,
        RenameSuitLoadout,
        Repair,
        RepairAll,
        RepairDrone,
        Reputation,
        RestockVehicle,
        Resurrect,
        ReservoirReplenished,
        Resupply,
        SAAScanComplete,
        SAASignalsFound,
        Scan,
        ScanBaryCentre,
        ScanOrganic,
        Scanned,
        ScientificResearch,
        Screenshot,
        SearchAndRescue,
        SelfDestruct,
        SellDrones,
        SellExplorationData,
        SellMicroResources,
        SellOrganicData,
        SellShipOnRebuy,
        SellSuit,
        SellWeapon,
        SendText,
        SetUserShipName,
        SharedBookmarkToSquadron,
        ShieldState,
        Shipyard,
        ShipyardBuy,
        ShipyardNew,
        ShipyardSell,
        ShipyardSwap,
        ShipyardTransfer,
        ShipTargeted,
        ShipLocker,
        Shutdown,
        SRVDestroyed,
        StartJump,
        Statistics,
        StoredModules,
        StoredShips,
        SupercruiseEntry,
        SquadronCreated,
        SquadronDemotion,
        SquadronPromotion,
        SquadronStartup,
        SupercruiseExit,
        SwitchSuitLoadout,
        SuitLoadout,
        Synthesis,
        SystemsShutdown,
        TechnologyBroker,
        Touchdown,
        TradeMicroResources,
        UnderAttack,
        Undocked,
        UpgradeSuit,
        UpgradeWeapon,
        UseConsumable,
        USSDrop,
        VehicleSwitch,
        WingAdd,
        WingInvite,
        WingJoin,
        WingLeave,
        WonATrophyForSquadron,
    }
}
