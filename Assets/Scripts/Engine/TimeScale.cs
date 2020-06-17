using UnityEngine;

namespace Engine
{
    public class TimeScale : MonoBehaviour
    {
        public static TimeScale Instance { get; private set; }
        public float Current { get; set; }

        private void Awake()
        {
            Current = 0f;
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
