using UnityEngine;

namespace Components
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int maxHealth;
        private int currentHealth;

        public int CurrentHealth
        {
            get => currentHealth;
            set
            {
                if (value < 0 || value > MaxHealth)
                {
                    Debug.LogError("Tried to set health to an invalid amount");
                }
                else
                {
                    currentHealth = value;
                }

                if (currentHealth <= 0)
                {
                    // TODO: handle death
                    Debug.Log($"{name} died");
                }
            }
        }


        private int MaxHealth
        {
            get => maxHealth;
            set => maxHealth = value;
        }

        private void Awake()
        {
            if ( MaxHealth <= 0)
            {
                Debug.LogError($"Instantiated actor {name} with {MaxHealth} health");
            }
            CurrentHealth = MaxHealth;
        }

        public void Increase(int amount)
        {
            if (amount <= 0)
            {
                Debug.LogError($"Tried to increase {name}'s health by {amount}");
            }

            if (CurrentHealth - amount < MaxHealth)
            {
                CurrentHealth += amount;
            }
            else
            {
                CurrentHealth = MaxHealth;
            }
        }

        public void Decrease(int amount)
        {
            if (amount <= 0)
            {
                Debug.LogError($"Tried to decrease {name}'s health by {amount}");
            }

            if (CurrentHealth - amount > 0)
            {
                CurrentHealth -= amount;
            }
            else
            {
                CurrentHealth = 0;
            }
        }
    }
}