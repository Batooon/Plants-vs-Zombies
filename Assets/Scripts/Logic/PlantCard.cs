using System;
using Data;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Logic
{
    [RequireComponent(typeof(PlantCardPresenter))]
    public class PlantCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private GameObject _templatePlant;
        
        public void Init(PlantData plantData)
        {
            _templatePlant = plantData.TemplatePlant;
            GetComponent<PlantCardPresenter>().Init(plantData);
        }
        
        public void OnBeginDrag(PointerEventData eventData)
        {
            //Instantiate plant prefab
            GameObject tempPlant = Instantiate(_templatePlant, eventData.position, Quaternion.identity);

            //TODO: Сделать затемнение карточки, и постепенное её восстановление
        }

        public void OnDrag(PointerEventData eventData)
        {
        }

        public void OnEndDrag(PointerEventData eventData)
        {
        }
    }
}