using System;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class PlantData
    {
        [SerializeField] private int _health;

        public int Health => _health;
    }
}