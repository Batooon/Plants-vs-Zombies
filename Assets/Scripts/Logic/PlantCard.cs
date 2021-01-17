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
        public event Action PlantBuyed;
        
        private PlantTemplate _templatePlant;
        private bool _isCardAvailable = true;
        private Field _field;
        private PlantShopData _plantShopData;
        private PlayerData _playerData;

        public void Init(PlantShopData plantShopData, Field field, PlayerData playerData)
        {
            _playerData = playerData;
            _plantShopData = plantShopData;
            _field = field;
            _templatePlant = plantShopData.TemplatePlant;
            GetComponent<PlantCardPresenter>().Init(plantShopData, this);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (_playerData.SunsAmount < _plantShopData.Cost || _isCardAvailable == false)
                return;
            
            SpawnTemplate();
        }
        
        private void SpawnTemplate()
        {
            RectTransform rectTransform = GetComponent<RectTransform>();

            Vector2 spawnPosition = rectTransform.position;
            PlantTemplate plantTemplate = Instantiate(_templatePlant.gameObject, spawnPosition, Quaternion.identity)
                .GetComponent<PlantTemplate>();
            plantTemplate.Init(_field, _plantShopData.PlantToSpawn, BuyPlant);
        }

        private void BuyPlant()
        {
            _playerData.SunsAmount -= _plantShopData.Cost;
            _isCardAvailable = false;
            PlantBuyed?.Invoke();
        }
        
        //TODO: Сделать затемнение карточки, и постепенное её восстановление

        public void OnCardRestored()
        {
            _isCardAvailable = true;
        }
    }
}