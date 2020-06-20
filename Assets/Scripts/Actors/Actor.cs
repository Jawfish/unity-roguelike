using System.Collections.Generic;
using Components;
using Modifiers;
using UnityEngine;

namespace Actors
{
    [RequireComponent(typeof(Awareness))]
    [RequireComponent(typeof(Health))]
    public class Actor : MonoBehaviour
    {
        public string Name { get; set; }
        private List<Modifier> modifiers = new List<Modifier>();

        public Awareness Awareness { get; private set; }
        public Health Health { get; private set; }
        public AbilityManager AbilityManager { get; set; }
        public World World { get; set; }


        // Start is called before the first frame update`
        void Start()
        {
            Awareness = gameObject.GetComponent<Awareness>();
            Health = gameObject.GetComponent<Health>();
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}