using System;
using System.Collections.Generic;
using Data;
using UnityEngine;

namespace UI
{
    public class PlantsShop : MonoBehaviour
    {
        [SerializeField] private GameObject _plantCardPrefab;
        [SerializeField] private List<PlantData> _plantDatas;
        [SerializeField] private GameObject _shopParent;

        public void Init()
        {
            if (_plantCardPrefab.TryGetComponent(out PlantCardPresenter plantCardPresenter))
            {
                foreach (var plantData in _plantDatas)
                {
                    GameObject plantCard = Instantiate(_plantCardPrefab, _shopParent.transform);
                    if (plantCard.TryGetComponent(out PlantCardPresenter plant))
                    {
                        plant.Init(plantData);
                    }
                }
            }
            else
            {
                throw new Exception("Plant card prefab does not contain a PlantCardPresenter.cs");
            }
        }
    }
}