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
            health = Mathf.Clamp(health - damage, 0, maxHealth);
        }

        public void RestoreHitPoints(int range)
        {
            health = Mathf.Clamp(health + range, health, maxHealth);
        }
    }
}