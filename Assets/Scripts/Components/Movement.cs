using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Components
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
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
            rb.velocity = vector * moveSpeed;
        }
    }
}