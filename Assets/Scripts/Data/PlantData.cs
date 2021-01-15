using System;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class PlantData
    {
        [SerializeField] private int _health;

        public int Health
        {
            get => _health;
            set => _health = value;
        }
    }
}