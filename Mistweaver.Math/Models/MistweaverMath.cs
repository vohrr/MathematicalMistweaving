﻿using Mistweaver.Data.Common;
using Mistweaver.Data.Helpers;
using Mistweaver.Data.Interfaces;
using Mistweaver.Data.Profile;
using Mistweaver.Data.Talents;
using Mistweaver.Data.Talents.Base;
using Mistweaver.Math.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mistweaver.Math.Models
{
    public class MistweaverMath : IMistweaverMath
    {
        private readonly ISpellBook _spellBook;
        private readonly IProfile _profile;
        public MistweaverMath(ISpellBook spellBook, IProfile profile) 
        {
            _spellBook = spellBook;
            _profile = profile;
        }

        //this should go in the application layer and call _math.modify...
        public void ApplyPlayerTalents()
        {
            if (_profile.PlayerTalents.SelectedTalents.Count > 0)
            {
                foreach (SelectedTalent talent in _profile.PlayerTalents.SelectedTalents)  // _profile.PlayerTalents.Talents will be a collection from the front end that only contains a single talent rank data for each talent based on what was selected
                {
                    
                    foreach (var affectedSpell in talent.AffectedHeals)
                    {
                        ModifyHealProperties(_spellBook.GetHeal(affectedSpell), talent);
                    }
                    foreach (var affectedSpell in talent.AffectedDamages)
                    {
                        ModifyDamageProperties(_spellBook.GetDamage(affectedSpell), talent);
                    }
                    //TODO: apply talents that affect other talents i.e. ancient concordance making teachings of the monastery 20/25% reset chance instead of 15%
                }
            }
        }

        public virtual decimal CalculateUniqueEffect<T>()
        {
            throw new NotImplementedException();
        }
        public void ModifyHealProperties(HealBase spell, SelectedTalent talent)
        {
            throw new NotImplementedException();


        }

        public void ModifyDamageProperties(DamageBase spell, SelectedTalent talent)
        {
            throw new NotImplementedException();
        }
        
        public decimal CalculateModifiedCoefficient(SpellBase spell, TalentEffect talent)
        {
            if (talent.Type != TalentEffectTypes.Coefficient)
                return spell.Coefficient * (1 + talent.Value);

            else
                throw new Exception("Talent does not modify coefficient");
        }

        public void ApplyStatScaling(SpellBase spell)
        {
            throw new NotImplementedException();
        }

    }
}
