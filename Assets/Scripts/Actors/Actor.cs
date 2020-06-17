using System.Collections.Generic;
using Components;
using Modifiers;
using UnityEngine;

namespace Actors
{
    [RequireComponent(typeof(ModifierHandler))]
    [RequireComponent(typeof(Awareness))]
    [RequireComponent(typeof(Health))]
    public class Actor : MonoBehaviour
    {
        protected string Name;
        private List<Modifier> modifiers = new List<Modifier>();

        public ModifierHandler ModifierHandler { get; private set; }
        public Awareness Awareness { get; private set; }
        public Health Health { get; private set; }


        // Start is called before the first frame update`
        void Start()
        {
            ModifierHandler = gameObject.GetComponent<ModifierHandler>();
            Awareness = gameObject.GetComponent<Awareness>();
            Health = gameObject.GetComponent<Health>();
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}