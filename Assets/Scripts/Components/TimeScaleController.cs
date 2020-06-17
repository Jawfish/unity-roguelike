using Engine;
using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(Movement))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class TimeScaleController : MonoBehaviour
    {
        private Rigidbody2D Rb { set; get; }
        private void Awake()
        {
            Rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
        TimeScale.Instance.Current = Rb.velocity.magnitude / 3;
        }
    }
}
