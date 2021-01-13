using System;
using System.Collections.Generic;
using Data;
using Logic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

namespace UI
{
    public class PlantsShop : MonoBehaviour
    {
        [SerializeField] private GameObject _plantCardPrefab;
        [SerializeField] private Transform _cardsParent;

        public void Init(IEnumerable<PlantShopData> plantDatas, Tilemap tilemap)
        {
            if (_plantCardPrefab.TryGetComponent(out PlantCard plant))
            {
                foreach (var plantData in plantDatas)
                {
                    var plantCard = Instantiate(_plantCardPrefab, _cardsParent)
                        .GetComponent<PlantCard>();
                    plantCard.Init(plantData,tilemap);
                }
                LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
            }
            else
            {
                throw new Exception("Plant card prefab does not contain a PlantCard.cs");
            }
        }
    }
}