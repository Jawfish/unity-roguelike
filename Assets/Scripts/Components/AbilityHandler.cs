using System;
using System.Collections.Generic;
using Abilities;
using Actors;
using Modifiers;
using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(Awareness))]
    [RequireComponent(typeof(Actor))]
    public class AbilityHandler : MonoBehaviour
    {
        [SerializeField] private List<Ability> abilities = new List<Ability>();
        private Actor owner;

        private void Awake()
        {
            owner = GetComponent<Actor>();
        }

        void Start()
        {
        }

        void Update()
        {
            foreach (Ability ability in abilities)
            {
                ability.Execute(owner);
            }
        }

        void AddAbility()
        {
            
        }
    }
}