using System;
using UnityEngine;
using Data;

namespace Logic
{
    public class Plant : MonoBehaviour
    {
        [SerializeField] protected PlantData _plantData;
        public int Health => _plantData.Health;
        protected PlayerData _playerData;
        
        public void Init(PlayerData playerData)
        {
            _playerData = playerData;
        }
        
        public void GetDamage(int amount)
        {
            _plantData.Health -= amount;
            if (_plantData.Health <= 0)
                Die();
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}