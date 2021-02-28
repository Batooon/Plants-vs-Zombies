using System.Collections.Generic;
using PvZ.Data;
using PvZ.Logic;
using PvZ.Logic.GameField;
using PvZ.Logic.Plants;
using UnityEngine;
using UnityEngine.UI;

namespace PvZ.UI
{
    [RequireComponent(typeof(HorizontalLayoutGroup))]
    public class PlantsShop : MonoBehaviour
    {
        [SerializeField] private PlantCard _plantCardPrefab;
        [SerializeField] private Transform _cardsParent;
        [SerializeField] private HorizontalLayoutGroup _layout;

        public void Init(IEnumerable<PlantShopData> plantDatas, Field field, PlayerData playerData, Camera camera)
        {
            _layout = GetComponent<HorizontalLayoutGroup>();
            foreach (var plantData in plantDatas)
            {
                var plantCard = Instantiate(_plantCardPrefab, _cardsParent);
                plantCard.Init(plantData, field, playerData, camera);
            }

            _layout.CalculateLayoutInputHorizontal();
            _layout.CalculateLayoutInputVertical();
            _layout.SetLayoutHorizontal();
            _layout.SetLayoutVertical();
        }
    }
}