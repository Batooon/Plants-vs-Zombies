using System;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class PlayerData
    {
        [SerializeField] private int _sunsAmount;
        public event Action<int> SunsAmountChanged; 

        public int SunsAmount
        {
            get => _sunsAmount;
            set
            {
                _sunsAmount = value;
                SunsAmountChanged?.Invoke(_sunsAmount);
            }
        }
    }
}