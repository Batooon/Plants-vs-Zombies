using Data;
using UI;
using UnityEngine;

namespace Logic
{
    [RequireComponent(typeof(PlantCardPresenter))]
    public class PlantCard : MonoBehaviour
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

        private void Start()
        {
            SpawnTemplate();
        }

        private void SpawnTemplate()
        {
            RectTransform rectTransform = GetComponent<RectTransform>();

            Vector2 spawnPosition = rectTransform.position;
            PlantTemplate plantTemplate = Instantiate(_templatePlant.gameObject, spawnPosition, Quaternion.identity)
                .GetComponent<PlantTemplate>();
            plantTemplate.Init(spawnPosition, _field, _plantShopData.PlantOnTheField);
        }
        
        //TODO: Сделать затемнение карточки, и постепенное её восстановление

        private void OnCardRestored()
        {
            _isCardAvailable = true;
        }
    }
}