﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Mistweaver.Data.SpellModels.Base;

namespace Mistweaver.Data.SpellModels
{
    public class EnvelopingMist : HealBase
    {
        public const decimal HealingIncrease = 0.30m;
        public EnvelopingMist() 
        {
            SpellId = 124682;
            Name = SpellNames.EnvelopingMist;
            Coefficient = 286.80m; 
            ManaCost = 0.048m;
            MaxTargets = 1;
            CastTime = 2;
            MasteryTrigger = true;
            HotInfoId = (int)HotIds.EnvelopingMist;
            HotInfo = new HotInfo()
            {
                Id = (int)this.HotInfoId,
                Name = this.Name,
                Duration = 6,
                TickRate = 1,
                SpellBaseId = this.Id
            };
            StatScaling = new StatScaling()
            {
                CriticalStrike = true,
                Haste = true,
                Mastery = false,
                Versatility = true
            };
        }
    }
}
