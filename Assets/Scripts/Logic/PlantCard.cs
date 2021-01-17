using System;
using Data;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Logic
{
    [RequireComponent(typeof(PlantCardPresenter))]
    public class PlantCard : MonoBehaviour, IPointerDownHandler
    {
        private PlantTemplate _templatePlant;
        private bool _isCardAvailable = true;
        private Field _field;
        private PlantShopData _plantShopData;

        public void Init(PlantShopData plantShopData, Field field)
        {
            _plantShopData = plantShopData;
            _field = field;
            _templatePlant = plantShopData.TemplatePlant;
            GetComponent<PlantCardPresenter>().Init(plantShopData);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            SpawnTemplate();
        }
        
        private void SpawnTemplate()
        {
            RectTransform rectTransform = GetComponent<RectTransform>();

            Vector2 spawnPosition = rectTransform.position;
            PlantTemplate plantTemplate = Instantiate(_templatePlant.gameObject, spawnPosition, Quaternion.identity)
                .GetComponent<PlantTemplate>();
            plantTemplate.Init(_field, _plantShopData.PlantToSpawn);
        }
        
        //TODO: Сделать затемнение карточки, и постепенное её восстановление

        private void OnCardRestored()
        {
            _isCardAvailable = true;
        }
    }
}