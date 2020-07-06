using Actors;
using UnityEngine;

namespace Conditions
{
    [CreateAssetMenu(fileName = "HasTag", menuName = "Conditions/Has Tag", order = 0)]
    public class ConditionHasTag : Condition
    {
        public string tag;
        public bool invert;

        public override bool Check(Actor target) => target.gameObject.CompareTag(tag) && !invert;

    }
}