using System;
using PvZ.Logic;
using PvZ.Logic.Plants;
using UnityEngine;

namespace PvZ.Data
{
    [Serializable]
    public class PlantShopData
    {
        [SerializeField] private Sprite _icon;
        [SerializeField] private int _cost;
        [SerializeField] private PlantTemplate _templatePlant;
        [SerializeField] private Plant _plantToSpawn;
        [SerializeField] private float _restoreTime;

        public Sprite Icon => _icon;
        public int Cost => _cost;
        public PlantTemplate TemplatePlant => _templatePlant;
        public Plant PlantToSpawn => _plantToSpawn;
        public float RestoreTime => _restoreTime;
    }
}