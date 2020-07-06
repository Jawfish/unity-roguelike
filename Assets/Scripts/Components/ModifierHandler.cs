using System;
using System.Collections.Generic;
using Actors;
using Modifiers;
using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(Actor))]
    public class ModifierHandler : MonoBehaviour
    {
        private readonly List<Modifier> modifiers = new List<Modifier>();
        private Actor actor;
        
        public void AddEntry(Modifier m) => modifiers.Add(m);

        private void Start()
        {
            actor = gameObject.GetComponent<Actor>();
        }

        private void Update()
        {
            foreach (Modifier modifier in modifiers)
            {
                modifier.Execute(actor);
            }
        }
    }
}
