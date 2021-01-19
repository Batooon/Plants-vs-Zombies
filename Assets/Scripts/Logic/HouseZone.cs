using System;
using UnityEngine;

namespace Logic
{
    [RequireComponent(typeof(Collider2D))]
    public class HouseZone : MonoBehaviour
    {
        public event Action ZombieEntersHouse;

        public void Init()
        {
            GetComponent<Collider2D>().isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Zombie zombie))
            {
                ZombieEntersHouse?.Invoke();
            }
        }
    }
}