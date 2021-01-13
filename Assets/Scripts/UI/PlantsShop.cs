using System;
using System.Collections.Generic;
using Data;
using Logic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(HorizontalLayoutGroup))]
    public class PlantsShop : MonoBehaviour
    {
        [SerializeField] private GameObject _plantCardPrefab;
        [SerializeField] private Transform _cardsParent;
        [SerializeField] private HorizontalLayoutGroup _layout;
        
        public void Init(IEnumerable<PlantShopData> plantDatas, Tilemap tilemap)
        {
            _layout = GetComponent<HorizontalLayoutGroup>();
            if (_plantCardPrefab.TryGetComponent(out PlantCard plant))
            {
                foreach (var plantData in plantDatas)
                {
                    var plantCard = Instantiate(_plantCardPrefab, _cardsParent)
                        .GetComponent<PlantCard>();
                    plantCard.Init(plantData, tilemap);
                }
                
                _layout.CalculateLayoutInputHorizontal();
                _layout.CalculateLayoutInputVertical();
                _layout.SetLayoutHorizontal();
                _layout.SetLayoutVertical();
            }
            else
            {
                throw new Exception("Plant card prefab does not contain a PlantCard.cs");
            }
        }
    }
}