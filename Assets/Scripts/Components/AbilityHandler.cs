using System.Collections.Generic;
using Abilities;
using Actors;
using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(Awareness))]
    [RequireComponent(typeof(Actor))]
    public class AbilityHandler : MonoBehaviour
    {
        private readonly List<Ability> abilities = new List<Ability>();
        private Actor owner;

        private void Awake() => owner = GetComponent<Actor>();

        void Update()
        {
            foreach (Ability ability in abilities)
            {
                if (ability.casting && ability.castTimer > 0)
                {
                    ability.castTimer -= Time.deltaTime * owner.World.TimeScale;
                }
                else if (ability.casting && ability.castTimer <= 0)
                {
                    ability.casting = false;
                    SendModifiers(ability);
                    ability.remainingCooldown = ability.cooldown;
                }

                if (ability.remainingCooldown > 0)
                {
                    ability.remainingCooldown -= Time.deltaTime * owner.World.TimeScale;
                }
            }
        }

        public void Cast(Ability ability)
        {
            if (ability.remainingCooldown > 0 || ability.casting)
            {
                return;
            }

            ability.casting = true;
        }

        public void AddAbility(Ability ability) => abilities.Add(ability);
        
        public List<Ability> ListAbilities() => abilities;

        private void SendModifiers(Ability ability)
        {
            foreach (var modifier in ability.modifiers)
            {
                var targets = new List<Actor>();
                if (modifier.targetSender)
                {
                    targets.Add(owner);
                }

                if (modifier.targetReceiver)
                {
                    targets.Add(owner.Awareness.target);
                }

                owner.AbilityManager.AddEntry(modifier, targets);
            }
        }
    }
}