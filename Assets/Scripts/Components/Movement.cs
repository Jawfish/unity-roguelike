using Actors;
using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 3f;
        [SerializeField] private bool ignoreTimescale = false;
        
        private Rigidbody2D rb;
        private Actor actor;

        private float MoveSpeed
        {
            get => moveSpeed;
            set => moveSpeed = value;
        }

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            actor = GetComponent<Actor>();
            MoveSpeed = moveSpeed;
        }

        public void Move(Vector2 vector)
        {
            if (ignoreTimescale)
            {
                rb.velocity = vector * MoveSpeed;
            }
            else
            {
                rb.velocity = vector * (MoveSpeed * actor.World.TimeScale);
            }
        }
    }
}