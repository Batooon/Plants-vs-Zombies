using PvZ.Data;
using PvZ.Logic.GameField;
using UnityEngine;

namespace PvZ.Logic.Plants
{
    public class Plant : MonoBehaviour
    {
        [SerializeField] protected PlantData _plantData;
        public int Health => _plantData.Health;
        protected PlayerData PlayerData;
        private const int DeathHpLimit = 0;
        private Cell _standingCell;
        
        public void Init(PlayerData playerData, Cell standingCell)
        {
            _standingCell = standingCell;
            PlayerData = playerData;
        }
        
        public void GetDamage(int amount)
        {
            _plantData.Health -= amount;
            if (_plantData.Health <= DeathHpLimit)
                Die();
        }

        private void Die()
        {
            _standingCell.IsEmpty = true;
            Destroy(gameObject);
        }
    }
}