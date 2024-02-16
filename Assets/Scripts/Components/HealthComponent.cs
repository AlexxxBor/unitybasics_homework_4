using UnityEngine;

namespace Sample
{
    public sealed class HealthComponent : MonoBehaviour
    {
        public int MaxHealth
        {
            get => this.maxHealth;
            set => this.maxHealth = value;
        }

        public int Health
        {
            get => this.health;
            set => this.health = value;
        }

        [SerializeField]
        private int maxHealth;

        [SerializeField]
        private int health;

        public void TakeDamage(int damage)
        {
            if ((health - damage) < 0)
            {
                health = 0;
                return;
            }

            health -= damage;
        }

        public void RestoreHitPoints(int range)
        {
            health = Mathf.Clamp(health + range, health, maxHealth);
        }
    }
}