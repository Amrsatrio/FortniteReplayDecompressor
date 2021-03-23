﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FortniteReplayReader.Models.Enums;
using Unreal.Core.Models;

namespace FortniteReplayReader.Models
{
    public class KillFeedEntry
    {
        public Player FinisherOrDowner { get; internal set; }
        public Player Player { get; internal set; }
        public PlayerState CurrentPlayerState { get; internal set; }
        public ItemRarity ItemRarity { get; internal set; }
        public ItemType ItemType { get; internal set; }
        public int ItemId { get; internal set; }
        public float DeltaGameTimeSeconds { get; internal set; }
        public float Distance { get; internal set; }
        public Weapon Weapon { get; internal set; }
        public bool DoNotDisplayInKillFeed { get; internal set; }

        public string[] DeathTags
        {
            get
            {
                return _deathTags;
            }
            internal set
            {
                _deathTags = value;
                UpdateWeaponTypes();
            }
        }

        private string[] _deathTags;

        public bool KilledSelf => FinisherOrDowner == Player;
        public bool HasError { get; internal set; }

        private void UpdateWeaponTypes()
        {
            if(_deathTags == null || _deathTags.Length == 0)
            {
                return;
            }

            foreach (string deathTag in DeathTags)
            {
                switch (deathTag)
                {
                    case "Pawn.Athena.DoNotDisplayInKillFeed":
                        DoNotDisplayInKillFeed = true;
                        break;
                    case "Weapon.Melee.Impact.Pickaxe":
                        ItemType = ItemType.PickAxe;
                        break;
                    case "weapon.ranged.assault.burst":
                        ItemType = ItemType.BurstRifle;
                        break;
                    case "weapon.ranged.assault.standard":
                        ItemType = ItemType.AssaultRifle;
                        break;
                    case "weapon.ranged.assault.silenced":
                        ItemType = ItemType.SuppressedAR;
                        break;
                    case "weapon.ranged.heavy.rocket_launcher":
                        ItemType = ItemType.RocketLauncher;
                        break;
                    case "weapon.ranged.pistol":
                    case "Weapon.Ranged.Pistol.Standard":
                        ItemType = ItemType.Pistol;
                        break;
                    case "Weapon.Ranged.Shotgun.Pump":
                        ItemType = ItemType.PumpShotgun;
                        break;
                    case "Weapon.Ranged.Shotgun.Tactical":
                        ItemType = ItemType.TacticalShotgun;
                        break;
                    case "Item.Weapon.Ranged.SMG.PDW":
                        ItemType = ItemType.SMG;
                        break;
                    case "Item.Weapon.Ranged.SMG.Suppressed":
                        ItemType = ItemType.SuppressedSMG;
                        break;
                    case "weapon.ranged.sniper.bolt":
                        ItemType = ItemType.BoltSniper;
                        break;
                    case "phoebe.items.SuppressedSniper":
                        ItemType = ItemType.SuppressedSniper;
                        break;
                    case "Abilities.Generic.M80":
                        ItemType = ItemType.Grenade;
                        break;
                    case "Weapon.Ranged.Assault.Heavy":
                        ItemType = ItemType.HeavyAR;
                        break;
                    case "phoebe.items.harpoon":
                        ItemType = ItemType.Harpoon;
                        break;
                    case "phoebe.weapon.ranged.minigun":
                        ItemType = ItemType.Minigun;
                        break;
                    case "Weapon.Ranged.Heavy.C4":
                        ItemType = ItemType.C4;
                        ItemRarity = ItemRarity.Epic; //Doesn't have death tags for it
                        break;
                    case "Gameplay.Damage.Physical.Energy":
                        ItemType = ItemType.Storm;
                        break;
                    case "DeathCause.LoggedOut":
                    case "DeathCause.RemovedFromGame":
                        ItemType = ItemType.Logout;
                        break;
                    case "Asset.Athena.EnvItem.Sentry.Turret.Damage":
                        ItemType = ItemType.SentryTurret;
                        break;
                    case "Gameplay.Damage.Environment":
                    case "EnvItem.ReactiveProp.GasPump": //Death by gas pump?
                        ItemType = ItemType.Environment;
                        break;
                    case "Gameplay.Damage.Environment.Falling":
                        ItemType = ItemType.Falling;
                        break;
                    case "Item.Trap.DamageTrap":
                        ItemType = ItemType.Trap;
                        break;
                    case "Rarity.Common":
                        ItemRarity = ItemRarity.Common;
                        break;
                    case "Rarity.Uncommon":
                        ItemRarity = ItemRarity.Uncommon;
                        break;
                    case "Rarity.Rare":
                        ItemRarity = ItemRarity.Rare;
                        break;
                    case "Rarity.SuperRare":
                        ItemRarity = ItemRarity.Legendary;
                        break;
                    case "Rarity.VeryRare":
                        ItemRarity = ItemRarity.Epic;
                        break;
                    case "Rarity.Mythic":
                        ItemRarity = ItemRarity.Mythic;
                        break;
                }
            }

            if(!DoNotDisplayInKillFeed && ItemRarity == ItemRarity.Uncommon && ItemType == ItemType.SMG)
            {

            }
        }
    }

    public enum PlayerState { Unknown, Alive, Knocked, BleedOut, Killed, Revived, FinallyEliminated }
}
