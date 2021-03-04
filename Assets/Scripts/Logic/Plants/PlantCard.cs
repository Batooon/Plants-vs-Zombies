using System;
using PvZ.Data;
using PvZ.Logic.GameField;
using PvZ.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PvZ.Logic.Plants
{
    [RequireComponent(typeof(PlantCardPresenter))]
    public class PlantCard : MonoBehaviour, IPointerDownHandler
    {
        public event Action PlantBought;
        private PlantTemplate _templatePlant;
        private bool _isCardAvailable = true;
        private Field _field;
        private PlantShopData _plantShopData;
        private PlayerData _playerData;
        private Camera _camera;
        private RectTransform _rectTransform;
        private GameObject _templatePlantGameObject;

        public void Init(PlantShopData plantShopData, Field field, PlayerData playerData, Camera camera)
        {
            _playerData = playerData;
            _plantShopData = plantShopData;
            _field = field;
            _templatePlant = plantShopData.TemplatePlant;
            _camera = camera;
            GetComponent<PlantCardPresenter>().Init(plantShopData, this);
            _rectTransform = GetComponent<RectTransform>();
            _templatePlantGameObject = SpawnTemplate();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (CanBuyPlant() == false)
                return;
            
            ActivatePlant();
        }

        private GameObject SpawnTemplate()
        {
            var plantTemplate = Instantiate(_templatePlant, _rectTransform.position, Quaternion.identity);
            plantTemplate.Init(_field, _plantShopData.PlantToSpawn, _camera).SetOnPlaced(BuyPlant);
            var plant = plantTemplate.gameObject;
            plant.SetActive(false);
            return plant;
        }

        private void ActivatePlant()
        {
            _templatePlantGameObject.transform.position = _rectTransform.position;
            _templatePlantGameObject.SetActive(true);
        }

        private void BuyPlant()
        {
            _playerData.SunsAmount -= _plantShopData.Cost;
            _isCardAvailable = false;
            PlantBought?.Invoke();
        }
        
        public void OnCardRestored()
        {
            _isCardAvailable = true;
        }
        
        private bool CanBuyPlant()
        {
            return _playerData.SunsAmount >= _plantShopData.Cost && _isCardAvailable;
        }
    }
}