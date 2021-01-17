using System;
using UnityEngine;

namespace Logic
{
    public class PlantTemplate : MonoBehaviour
    {
        private Field _field;
        private Plant _fieldPlant;
        private event Action _callback;

        public void Init(Field field, Plant plantOnField, Action callback)
        {
            _fieldPlant = plantOnField;
            _field = field;
            _callback = callback;
        }

        private void Update()
        {
            if(Input.GetMouseButtonUp(0))
                TryPlacePlant();
            if (Input.GetMouseButton(0))
                Drag();
        }

        private void Drag()
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            transform.position = _field.IsPointerOverField(Input.mousePosition)
                ? _field.GetCellCenterCoordinates(Input.mousePosition)
                : mousePosition;
        }

        private void TryPlacePlant()
        {
            _field.TryPlacePlant(Input.mousePosition, _fieldPlant, _callback);
            Destroy(gameObject);
        }
    }
}