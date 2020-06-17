using System;
using Actors;
using Engine;
using Modifiers;
using UnityEngine;

namespace Abilities
{
    [CreateAssetMenu(fileName = "Ability", menuName = "Abilities/Empty Ability", order = 0)]
    public class Ability : ScriptableObject
    {
        public enum Targets
        {
            Sender,
            Receiver,
            Both
        }

        public Sprite icon;
        public new string name;
        public string description;
        public float range;
        public float warmup;
        public float cooldown;
        public bool passive;
        public Targets target;
        public Modifier[] modifiers;

        private float castTimer;
        private float remainingCooldown = 0f;
        private bool casting = false;

        
        public void Execute(Actor sender)
        {
            Debug.Log($"Executed {name}");
            if (passive)
            {
                // TODO: send modifiers to the targets when the ability
                // begins to exist, but don't send additional modifiers
                return;
            }

            if (casting && castTimer > 0)
            {
                castTimer -= Time.deltaTime * TimeScale.Instance.Current;
            }
            else if (casting && castTimer <= 0)
            {
                casting = false;
                SendModifiers(sender);
                remainingCooldown = cooldown;
            }

            if (remainingCooldown > 0)
            {
                remainingCooldown -= Time.deltaTime * TimeScale.Instance.Current;
            }
        }

        public void Cast()
        {
            if (passive || remainingCooldown > 0 || casting)
            {
                return;
            }

            casting = true;
        }

        private void SendModifiers(Actor sender)
        {
            foreach (var modifier in modifiers)
            {
                switch (target)
                {
                    case Targets.Sender:
                        sender.ModifierHandler.AddEntry(modifier);
                        break;
                    case Targets.Receiver:
                        sender.Awareness.target.ModifierHandler.AddEntry(modifier);
                        break;
                    case Targets.Both:
                        sender.ModifierHandler.AddEntry(modifier);
                        sender.Awareness.target.ModifierHandler.AddEntry(modifier);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}