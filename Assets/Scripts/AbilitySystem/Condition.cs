using System;
using Actors;
using UnityEngine;

namespace Conditions
{
    [Serializable]
    public abstract class Condition : ScriptableObject
    {
        public virtual bool Check(Actor target)
        {
            throw new NotImplementedException();
        }
    }
}