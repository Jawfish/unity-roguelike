using System;
using Actors;
using UnityEngine;

namespace Effects
{
    [Serializable]
    public abstract class Effect : ScriptableObject
    {
        public void Execute(Actor actor)
        {
            throw new System.NotImplementedException();
        }
    }
}
