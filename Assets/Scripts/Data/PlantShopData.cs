using System;
using Logic;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class PlantShopData
    {
        [SerializeField] private Sprite _icon;
        [SerializeField] private int _cost;
        [SerializeField] private PlantTemplate _templatePlant;
        [SerializeField] private Plant _plantOnTheField;

        public Sprite Icon => _icon;
        public int Cost => _cost;
        public PlantTemplate TemplatePlant => _templatePlant;

        public Plant PlantOnTheField => _plantOnTheField;
    }
}