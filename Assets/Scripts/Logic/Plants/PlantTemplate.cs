using System;
using PvZ.Logic.GameField;
using UnityEngine;

namespace PvZ.Logic.Plants
{
    public class PlantTemplate : MonoBehaviour
    {
        private const int LeftMouseButtonIndex = 0;
        private Camera _camera;
        private Field _field;
        private Plant _fieldPlant;
        private event Action _onPlanted;
        private Transform _transform;

        public PlantTemplate Init(Field field, Plant plantOnField, Camera camera)
        {
            _fieldPlant = plantOnField;
            _field = field;
            _camera = camera;
            _transform = transform;
            return this;
        }

        public void SetOnPlaced(Action onPlaced)
        {
            _onPlanted = onPlaced;
        }

        private void Update()
        {
#if UNITY_EDITOR || UNITY_WEBGL
            var worldMousePosition = Input.mousePosition;
            if(Input.GetMouseButtonUp(LeftMouseButtonIndex))
                TryPlacePlant(worldMousePosition);
            if (Input.GetMouseButton(LeftMouseButtonIndex))
                Drag(worldMousePosition);
#endif
        }

        private void Drag(Vector3 worldMousePosition)
        {
            var mousePosition = _camera.ScreenToWorldPoint(worldMousePosition);
            mousePosition.z = 0;
            _transform.position = _field.IsPointerOverField(worldMousePosition)
                ? _field.GetCellCenterCoordinates(worldMousePosition)
                : mousePosition;
        }

        private void TryPlacePlant(Vector3 worldMousePosition)
        {
            _field.TryPlacePlant(worldMousePosition, _fieldPlant, _onPlanted);
            gameObject.SetActive(false);
        }
    }
}