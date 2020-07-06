using System;
using System.Collections.Generic;
using System.Linq;
using Actors;
using Conditions;
using Effects;
using Engine;
using UnityEngine;

namespace Modifiers
{
    [Serializable]
    [CreateAssetMenu(fileName = "Modifier", menuName = "Modifier", order = 0)]
    public class Modifier : ScriptableObject
    {
        public bool OneShot;
        public float duration;
        public bool ticking;
        public float ticksPerSecond;
        public bool persistent;
        public Condition[] conditions;
        public Effect[] effects;

        private bool active;
        private float timeRemaining;
        private float tickTimer;
        private bool tickFrame;
        
        private void Initialize()
        {
            if (!persistent)
            {
                timeRemaining = duration;
            }

            if (!ticking) return;
            tickTimer = 1 / ticksPerSecond;
            // tickFrame = true; re-enable this to enable DoT effects ticking as soon as they land on a target
        }

        public void Execute(Actor target)
        {
            if (!persistent && !OneShot)
            {
                if (timeRemaining > 0)
                {
                    active = true;
                    timeRemaining -= Time.deltaTime * TimeScale.Instance.Current;
                }
                else if (timeRemaining <= 0)
                {
                    // TODO: clear this modifier after remaining time depletes
                }
            }

            if (ticking && tickTimer > 0)
            {
                tickTimer -= Time.deltaTime * TimeScale.Instance.Current;
                tickFrame = false;
            }
            else if (ticking && tickTimer <= 0)
            {
                tickFrame = true;
                tickTimer = 1 / ticksPerSecond;
            }

            if (persistent || OneShot)
            {
                active = true;
            }
            
            if (OneShot)
            {
                // TODO: destroy this modifier after running effects once
            }

            if (ConditionsTrue(target))
            {
                foreach (Effect effect in effects)
                {
                    effect.Execute(target);
                }
            }
        }

        /// <summary>
        /// Checks if every contextual condition evaluates to true.
        /// </summary>
        /// <returns>True if all conditions are met, otherwise false.</returns>
        public bool ConditionsTrue(Actor target)
        {
            if (conditions.Any(c => c.Check(target) == false)) return false;
            if (!active) return false;
            return !ticking || tickFrame;
        }
    }
}