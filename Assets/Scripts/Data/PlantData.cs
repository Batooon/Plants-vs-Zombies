using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Data
{
    [Serializable]
    public class PlantData
    {
        [SerializeField] private Sprite _icon;
        [SerializeField] private int _cost;
        [SerializeField] private GameObject _templatePlant;

        public Sprite Icon => _icon;
        public int Cost => _cost;
        public GameObject TemplatePlant => _templatePlant;
    }
}