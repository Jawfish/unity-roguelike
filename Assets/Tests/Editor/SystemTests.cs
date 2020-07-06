using Abilities;
using Components;
using Modifiers;
using NUnit.Framework;
using UnityEngine;

namespace Tests.Editor
{
    public class AbilityTests
    {
        [Test]
        public void AbilityHandler_ShouldAddAbilities()
        {
            AbilityHandler abilityHandler = new AbilityHandler();
            Ability ability = new Ability();
            abilityHandler.AddAbility(ability);
            Assert.AreEqual(abilityHandler.ListAbilities().Count, 1);
            Assert.AreEqual(abilityHandler.ListAbilities()[0], ability);
        }
        
        [Test]
        public void AbilityHandler_ShouldCastAbilities()
        {
            AbilityHandler abilityHandler = new AbilityHandler();
            Ability ability = new Ability();
            abilityHandler.AddAbility(ability);
            abilityHandler.Cast(ability);
            Assert.AreEqual(ability.casting, true);
        }
    }
}