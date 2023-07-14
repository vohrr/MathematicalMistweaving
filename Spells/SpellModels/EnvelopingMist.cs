﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Mistweaver.SpellData.SpellModels.Base;

namespace Mistweaver.SpellData.SpellModels
{
    public class EnvelopingMist : HealBase
    {
        public EnvelopingMist() 
        {
            SpellId = 124682; 
            Name = "Enveloping Mist"; 
            Coefficient = 286.80m; 
            ManaCost = 0.048m;
            MaxTargets = 1;
            CastTime = 2;
            MasteryTrigger = true;
            HotInfoId = (int)HotIds.EnvelopingMist;
            HotInfo = new HotInfo()
            {
                Id = (int)HotIds.EnvelopingMist,
                Name = "Enveloping Mist",
                Duration = 6,
                TickRate = 1,
                SpellBaseId = this.Id
            };
        }
    }
}
