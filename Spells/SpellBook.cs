﻿using Mistweaver.SpellData.Interfaces;
using Mistweaver.SpellData.SpellModels;


namespace Mistweaver.SpellData
{
    public class SpellBook : ISpellBook
    {
        public List<SpellBase> Spells { get; set; } = new List<SpellBase>();
        public List<HealBase> HealingSpells { get; set; } = new List<HealBase>();
        public List<DamageBase> DamageSpells { get; set; } = new List<DamageBase>();
        public List<HotInfo> Hots { get; set; } = new List<HotInfo>();
        public List<DotInfo> Dots { get; set; } = new List<DotInfo>();

        /* heals */
        public HealBase? Vivify(bool cleave = false) => cleave ? GetSpellByName<HealBase>(SpellNames.VivifyCleave) : GetSpellByName<HealBase>(SpellNames.Vivify);
        public HealBase? RenewingMist() => GetSpellByName<HealBase>(SpellNames.RenewingMist);
        public HealBase? EssenceFont(bool hot = false) => hot ? GetSpellByName<HealBase>("Essence Font (Hot)") : GetSpellByName<HealBase>("Essence Font");
        public HealBase? Revival() => GetSpellByName<HealBase>("Revival");
        public HealBase? EnvelopingMist() => GetSpellByName<HealBase>("Enveloping Mist");
        public HealBase? SoothingMist(bool jadeSerpentStatue = false) => jadeSerpentStatue ? GetSpellByName<HealBase>("Soothing Mist (Jade Serpent Statue)") : GetSpellByName<HealBase>("Soothing Mist");
        public HealBase? EnvelopingBreath() => GetSpellByName<HealBase>("Enveloping Breath");
        public HealBase? ChiCocoon(bool chiji = false, bool yulon = false)
        {
            if (chiji)
                return GetSpellByName<HealBase>("Chi Cocoon (Chi-Ji)");

            if (yulon)
                return GetSpellByName<HealBase>("Chi Cocoon (Yu'lon)");

            return new HealBase() { SpellId = -1, Name = "Please select Chi-Ji or Yu'lon" };
        }
        public HealBase? LifeCocoon() => GetSpellByName<HealBase>("Life Cocoon");
        public HealBase? SoothingBreath() => GetSpellByName<HealBase>("Soothing Breath");
        public HealBase? GustOfMists(bool chiji = false) => chiji ? GetSpellByName<HealBase>("Gust of Mists (Chi-Ji)") : GetSpellByName<HealBase>("Gust of Mists");
        public HealBase? SheilunsGift() => GetSpellByName<HealBase>("Sheilun's Gift");
        public HealBase? RefreshingJadeWind() => GetSpellByName<HealBase>("Refreshing Jade Wind");
        public HealBase? SummonJadeSerpentStatue() => GetSpellByName<HealBase>("Summon Jade Serpent Statue");
        public HealBase? Unison() => GetSpellByName<HealBase>("Unison");

        /* hurts */
        public DamageBase? RisingSunKick() => GetSpellByName<DamageBase>("Rising Sun Kick");
        public DamageBase? BlackoutKick() => GetSpellByName<DamageBase>("Blackout Kick");
        public DamageBase? TigerPalm() => GetSpellByName<DamageBase>("Tiger Palm");
        public DamageBase? SpinningCraneKick() => GetSpellByName<DamageBase>("Spinning Crane Kick");
        public DamageBase? TouchOfDeath() => GetSpellByName<DamageBase>("Touch of Death");

        /* hyrids */
        public object ChiBurst(bool damage = false)
        {
            if (damage)
                return GetSpellById<DamageBase>(148135);

            return GetSpellById<HealBase>(130654);
        }
        public object ChiWave(bool damage = false)
        {
            if (damage)
                return GetSpellById<DamageBase>(115098);

            return GetSpellById<HealBase>(132463);
        }


        public SpellBook()
        {
            HealingSpells = new List<HealBase> {
                new Vivify.VivifyPrimary(), 
                new Vivify.VivifyCleave(), 
                new RenewingMist(),
                new EssenceFont.EssenceFontHit(), 
                new EssenceFont.EssenceFontHot(),
                new Revival(),
                new HealBase { SpellId = 124682, Name = "Enveloping Mist", Coefficient = 286.80m, ManaCost = 0.048m, MaxTargets = 1, CastTime = 2, MasteryTrigger = true, HotInfoId = (int)HotIds.EnvelopingMist, HotInfo = Hots.Where(x=> x.Id == (int)HotIds.EnvelopingMist).FirstOrDefault() },
                new HealBase { SpellId = 115175, Name = "Soothing Mist", Coefficient = 440m, ManaCost = 0.032m, MaxTargets = 1, CastTime = 8, MasteryTrigger = true, IsChannel = true, HotInfoId = (int)HotIds.SoothingMist, HotInfo = Hots.Where(x=> x.Id == (int)HotIds.SoothingMist).FirstOrDefault() },
                new HealBase { SpellId = 325209, Name = "Enveloping Breath", Coefficient = 162.00m, MaxTargets = 6, CastTime = 2, MasteryTrigger = false, IsIndirect = true, HotInfoId = (int)HotIds.EnvelopingBreath, HotInfo = Hots.Where(x=> x.Id == (int)HotIds.EnvelopingBreath).FirstOrDefault()},
                //new HealBase { SpellId = 406220, Name = "Chi Cocoon (Chi-Ji)", Coefficient = 0.10m, MaxTargets = 5, CastTime = 0, IsIndirect = true },
                //new HealBase { SpellId = 406139, Name = "Chi Cocoon (Yu'lon)", Coefficient = 0.10m, MaxTargets = 5, CastTime = 0, IsIndirect = true },
                new HealBase { SpellId = 116849, Name = "Life Cocoon", Coefficient = 60.00m, ManaCost = 0.024m, MaxTargets = 1, CastTime = 0, MasteryTrigger = false, Cooldown = 120, IsHealthCoefficient = true, },
                new HealBase { SpellId = 343737, Name = "Soothing Breath", Coefficient = 105, MaxTargets = 3, MasteryTrigger = false, Cooldown = 1.5m, CastTime = 4.5m, IsIndirect = true, HotInfoId = (int)HotIds.SoothingBreath, HotInfo = Hots.Where(x => x.Id == (int)HotIds.SoothingBreath).FirstOrDefault() },
                new HealBase { SpellId = 343819, Name = "Gust of Mists (Chi-Ji)", Coefficient = 33.6m, MaxTargets = 2, CastTime = 0, MasteryTrigger = true, IsIndirect = true },
                new HealBase { SpellId = 191894, Name = "Gust of Mists", Coefficient = 33.6m, MaxTargets = 1, IsIndirect = true, CastTime = 0, },
                new HealBase { SpellId = 399491, Name = "Sheilun's Gift", Coefficient = 114, MaxTargets = 3, CastTime = 2, Cooldown = 8, ManaCost = 0.025m },
                //new HealBase { SpellId = 196725, Name = "Refreshing Jade Wind", Coefficient = 277.704m, MaxTargets = 6, CastTime = 1.5m, Cooldown = 45, IsCooldownHasted = true, ManaCost = 0.05m, HotInfoId = (int)HotIds.RefreshingJadeWind, HotInfo = Hots.Where(x => x.Id == (int)HotIds.RefreshingJadeWind).FirstOrDefault() },
                new HealBase { SpellId = 115313, Name = "Summon Jade Serpent Statue", Coefficient = 0, CastTime = 1.5m, MaxTargets = 1},
                new HealBase { SpellId = 198533, Name = "Soothing Mist (Summon Jade Serpent Statue)", Coefficient = 220, CastTime = 8, MaxTargets = 1, IsChannel = true, IsIndirect = true, HotInfoId = (int)HotIds.SoothingMist_Jss, HotInfo = Hots.Where(x => x.Id == (int)HotIds.SoothingMist_Jss).FirstOrDefault() },
                new HealBase { SpellId = 130654, Name = "Chi Burst", Coefficient = 94.5m, CastTime = 0.75m, MaxTargets = 6, IsSqrtScaling = true, IsAttackPower = true, Cooldown = 30, },
                new HealBase { SpellId = 132463, Name = "Chi Wave", Coefficient = 42, CastTime = 1.5m, MaxTargets = 4, IsAttackPower = true, Cooldown = 15 },
                new HealBase { SpellId = 388480, Name = "Unison", Coefficient = 100, CastTime = 0, MaxTargets = 1, IsIndirect = true }

            };

            DamageSpells = new List<DamageBase> {
                new DamageBase { SpellId = 107428, Name = "Rising Sun Kick", Coefficient = 143.8m, ManaCost = .02m, MaxTargets = 1, CastTime = 1.5m, Cooldown = 12, IsCooldownHasted = true, IsAttackPower = true },
                new DamageBase { SpellId = 100784, Name = "Blackout Kick", Coefficient = 84.7m, MaxTargets = 1, CastTime = 1.5m, Cooldown = 3, IsCooldownHasted = true, IsAttackPower = true },
                new DamageBase { SpellId = 100780, Name = "Tiger Palm", Coefficient = 27.027m, MaxTargets = 1, CastTime = 1.5m, IsAttackPower = true },
                new DamageBase { SpellId = 107270, Name = "Spinning Crane Kick", Coefficient = 40, MaxTargets = 5, CastTime = 1.5m, IsChannel = true, IsAttackPower = true, IsSqrtScaling = true },
                new DamageBase { SpellId = 322109, Name = "Touch of Death", Coefficient = 35, MaxTargets = 1, CastTime = 1.5m, IsHealthCoefficient = true, Cooldown = 180 },
                new DamageBase { SpellId = 148135, Name = "Chi Burst", Coefficient = 46, CastTime = .75m, MaxTargets = 6, IsSqrtScaling = true, Cooldown = 30, IsAttackPower = true },
                new DamageBase { SpellId = 115098, Name = "Chi Wave", Coefficient = 14.2015m, CastTime = 1.5m, MaxTargets = 4, Cooldown = 15, IsAttackPower = true }

                //TODO break out casts that don't do damage
            };
            Spells.AddRange(DamageSpells);
            Spells.AddRange(HealingSpells);
            Spells = Spells.OrderBy(x => x.Id).ToList();

            foreach(var spell in HealingSpells)
            {
                if(spell.HotInfo != null)
                {
                    Hots.Add(spell.HotInfo);
                }
            }

            foreach(var spell in DamageSpells)
            {
                if(spell.DotInfo != null)
                {
                    Dots.Add(spell.DotInfo);
                }
            }






            var bug = new HotInfo { Id = (int)HotIds.SoothingMist_Jss, Name = "Soothing Mist (Jade Serpent Statue)", Duration = 8, TickRate = 1, IsExtendable = false };
            


        }

        public T GetSpellById<T>(int spellId)
        {
            if (GetType() == typeof(HealBase))
                return (T)(object)HealingSpells.Where(x => x.SpellId == spellId).First();

            if (GetType() == typeof(DamageBase))
                return (T)(object)DamageSpells.Where(x => x.SpellId == spellId).First();

            return (T)(object)Spells.Where(x => x.SpellId == spellId).First();
        }

        public T GetSpellByName<T>(string name)
        {
            if(GetType() == typeof(HealBase))
                return (T)(object)HealingSpells.Where(x => x.Name == name).First();

            if(GetType() == typeof(DamageBase))
                return (T)(object)DamageSpells.Where(x => x.Name == name).First();

            return (T)(object)Spells.Where(x => x.Name == name).First();

        }

        public void AddSourceIds(List<SpellBase> spells)
        {
            
        }
    }
}
