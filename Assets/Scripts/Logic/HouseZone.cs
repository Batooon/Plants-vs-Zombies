using System;
using UnityEngine;

namespace Logic
{
    [RequireComponent(typeof(Collider2D))]
    public class HouseZone : MonoBehaviour
    {
        public event Action ZombieEntersHouse;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Zombie _))
            {
                ZombieEntersHouse?.Invoke();
            }
        }
    }
}