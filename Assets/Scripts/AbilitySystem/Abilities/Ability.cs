using System;
using System.Collections.Generic;
using Actors;
using Components;
using Modifiers;
using UnityEngine;
using UnityEngine.Serialization;

namespace Abilities
{
    [CreateAssetMenu]
    public class Ability : ScriptableObject
    {
        public Sprite icon;
        public new string name;
        public string description;
        public float range;
        public float warmup;
        public float cooldown;
        public float castTimer { get; set; }
        public float remainingCooldown { get; set; }
        public bool casting { get; set; }
        public Modifier[] modifiers;
    }
}