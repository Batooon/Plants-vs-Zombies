using System;
using PvZ.Logic.GameField;
using UnityEngine;

namespace PvZ.Logic.Plants
{
    public class PlantTemplate : MonoBehaviour
    {
        private Camera _camera;
        private Field _field;
        private Plant _fieldPlant;
        private event Action _callback;
        private Transform _transform;

        public void Init(Field field, Plant plantOnField, Camera camera, Action callback)
        {
            _fieldPlant = plantOnField;
            _field = field;
            _camera = camera;
            _transform = transform;
            _callback = callback;
        }

        private void Update()
        {
#if UNITY_EDITOR || UNITY_WEBGL
            var worldMousePosition = Input.mousePosition;
            if(Input.GetMouseButtonUp(0))
                TryPlacePlant(worldMousePosition);
            if (Input.GetMouseButton(0))
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
            _field.TryPlacePlant(worldMousePosition, _fieldPlant, _callback);
            gameObject.SetActive(false);
        }
    }
}