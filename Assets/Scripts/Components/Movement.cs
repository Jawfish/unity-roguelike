using System;
using Engine;
using UnityEngine;
using UnityEngine.Serialization;

namespace Components
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private bool ignoreTimescale;
        
        private Rigidbody2D rb;

        private float MoveSpeed
        {
            get => moveSpeed;
            set => moveSpeed = value;
        }

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public void Move(Vector2 vector)
        {
            if (ignoreTimescale)
            {
                rb.velocity = vector * moveSpeed;
            }
            else
            {
                rb.velocity = vector * (moveSpeed * TimeScale.Instance.Current);
            }
        }
    }
}