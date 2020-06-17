using Actors;
using UnityEngine;

namespace Effects
{
    [CreateAssetMenu(fileName = "DamageEffect", menuName = "Effect/Damage Effect", order = 0)]
    public class EffectDamage : Effect
    {
        public enum DamageTypes
        {
            Normal,
            Fire,
            Ice
        }

        private DamageTypes damageType;
        private int amount;

        public EffectDamage(DamageTypes damageType, int amount)
        {
            this.damageType = damageType;
            this.amount = amount;
        }
        public void Execute(Actor actor)
        {
            actor.Health.ApplyDamage(amount, damageType);
        }
    }
}