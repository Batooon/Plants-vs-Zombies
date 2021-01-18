using UnityEngine;
using Data;

namespace Logic
{
    public class Plant : MonoBehaviour
    {
        [SerializeField] protected PlantData _plantData;
        public int Health => _plantData.Health;
        protected PlayerData _playerData;
        protected Cell _standingCell;
        
        public void Init(PlayerData playerData, Cell standingCell)
        {
            _standingCell = standingCell;
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
            _standingCell.IsEmpty = true;
            Destroy(gameObject);
        }
    }
}