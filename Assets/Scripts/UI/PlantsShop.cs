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
            if (_plantCardPrefab.TryGetComponent(out PlantCardPresenter plantCard))
            {
                foreach (var plantData in _plantDatas)
                {
                    var plantCardPresenter = Instantiate(_plantCardPrefab, _shopParent.transform)
                        .GetComponent<PlantCardPresenter>();
                    plantCardPresenter.Init(plantData);
                }
            }
            else
            {
                throw new Exception("Plant card prefab does not contain a PlantCardPresenter.cs");
            }
        }
    }
}