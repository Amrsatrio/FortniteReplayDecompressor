using System;
using System.Collections.Generic;
using System.Text;
using FortniteReplayReader.Models.NetFieldExports;
using FortniteReplayReader.Models.NetFieldExports.Enums;
using Unreal.Core.Attributes;
using Unreal.Core.Models;
using Unreal.Core.Models.Enums;

namespace FortniteReplayReader.Models.NetFieldExports.Items.Weapons
{
    public class MachineGun : BaseWeapon
    {
    }

    [NetFieldExportGroup("/Game/Weapons/FORT_Rifles/Blueprints/Assault/B_Minigun_Athena.B_Minigun_Athena_C", ParseType.Normal)]
    public class Minigun : MachineGun
    {
        [NetFieldExport("ChargeStatusPack", RepLayoutCmdType.Ignore)]
        public DebuggingObject ChargeStatusPack { get; set; }

        [NetFieldExport("CurrentSpinAudioComponent", RepLayoutCmdType.Property)]
        public NetworkGUID CurrentSpinAudioComponent { get; set; }

        [NetFieldExport("bIsChargingWeapon", RepLayoutCmdType.PropertyBool)]
        public bool? bIsChargingWeapon { get; set; }

        [NetFieldExport("SpinVolumeMultiplier", RepLayoutCmdType.PropertyFloat)]
        public float? SpinVolumeMultiplier { get; set; }

        [NetFieldExport("bPlayedSpinUpAudio", RepLayoutCmdType.PropertyBool)]
        public bool? bPlayedSpinUpAudio { get; set; }

        [NetFieldExport("bPlayedSpinDownAudio", RepLayoutCmdType.PropertyBool)]
        public bool? bPlayedSpinDownAudio { get; set; }

		[NetFieldExport("OverheatState", RepLayoutCmdType.Enum)]
		public EFortWeaponOverheatState OverheatState { get; set; } = EFortWeaponOverheatState.EFortWeaponOverheatState_MAX;

        [NetFieldExport("TimeOverheatedBegan", RepLayoutCmdType.PropertyFloat)]
        public float? TimeOverheatedBegan { get; set; }
    }

    [NetFieldExportGroup("/Game/Weapons/FORT_Rifles/Blueprints/Assault/B_Assault_LMG_SAW_Athena.B_Assault_LMG_SAW_Athena_C", ParseType.Normal)]
    public class LightMachineGun : MachineGun
    {
    }
}
