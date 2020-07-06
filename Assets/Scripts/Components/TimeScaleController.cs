using Actors;
using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(Actor))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class TimeScaleController : MonoBehaviour
    {
        private Rigidbody2D Rb { set; get; }
        private Actor Actor { set; get; }

        private void Awake()
        {
            Rb = GetComponent<Rigidbody2D>();
            Actor = GetComponent<Actor>();
        }

        private void Update()
        {
        Actor.World.TimeScale = Rb.velocity.magnitude / 3;
        }
    }
}
