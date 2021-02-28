using System;
using PvZ.Logic.Zombies;
using UnityEngine;

namespace PvZ.Logic
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