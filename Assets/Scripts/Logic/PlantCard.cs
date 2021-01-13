using Data;
using UI;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Logic
{
    [RequireComponent(typeof(PlantCardPresenter))]
    public class PlantCard : MonoBehaviour
    {
        private PlantTemplate _templatePlant;
        private bool _isCardAvailable = true;
        private Tilemap _tilemap;

        public void Init(PlantShopData plantShopData, Tilemap tilemap)
        {
            _tilemap = tilemap;
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
            plantTemplate.Init(spawnPosition, _tilemap);
        }
        
        //TODO: Сделать затемнение карточки, и постепенное её восстановление

        private void OnCardRestored()
        {
            _isCardAvailable = true;
        }
    }
}