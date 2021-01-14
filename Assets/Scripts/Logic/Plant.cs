using System;
using UnityEngine;
using Data;

namespace Logic
{
    public class Plant : MonoBehaviour
    {
        private int _health;

        /*public void Init(PlantData plantData)
        {
            _health = plantData.Health;
        }*/

        private void Awake()
        {
            _health = 100;
        }

        public void GetDamage(int amount)
        {
            _health -= amount;
            if(_health<=0)
                Die();
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}