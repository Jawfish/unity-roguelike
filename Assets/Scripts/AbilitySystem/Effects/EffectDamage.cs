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

        [SerializeField] private DamageTypes damageType;
        [SerializeField] private int amount;

        public EffectDamage(DamageTypes damageType, int amount)
        {
            this.damageType = damageType;
            this.amount = amount;
        }
        public override void Execute(Actor actor)
        {
            actor.Health.ApplyDamage(amount, damageType);
        }
    }
}