using System;
using Data;
using UnityEngine;
using UnityEngine.Tilemaps;
using Object = UnityEngine.Object;

namespace Logic
{
    public class Field
    {
        private Cell[,] _cells;
        private readonly int _width;
        private readonly int _height;
        private readonly Tilemap _renderField;
        private readonly PlayerData _playerData;

        public Field(int width, int height, Tilemap renderField, PlayerData playerData)
        {
            _width = width;
            _height = height;
            _renderField = renderField;
            _playerData = playerData;
            GenerateEmptyField();
        }

        public void TryPlacePlant(Vector3 mousePosition, Plant plant, Action callback)
        {
            var cellPosition = GetCellCoordinates(mousePosition);

            if (IsOnFieldCriteria(cellPosition) == false)
                return;
            
            if (_cells[cellPosition.x, cellPosition.y].IsEmpty == false)
                return;

            Plant placedPlant = Object
                .Instantiate(plant.gameObject, GetCellCenterCoordinates(mousePosition), Quaternion.identity)
                .GetComponent<Plant>();
            placedPlant.Init(_playerData);
            _cells[cellPosition.x, cellPosition.y].IsEmpty = false;
            callback?.Invoke();
        }

        public float GetCellCenterVerticalPosition(int line)
        {
            return _renderField.GetCellCenterWorld(new Vector3Int(0, line, 0)).y;
        }

        public bool IsPointerOverField(Vector3 pointerPosition)
        {
            var cellPosition = GetCellCoordinates(pointerPosition);

            return IsOnFieldCriteria(cellPosition);
        }

        public Vector3 GetCellCenterCoordinates(Vector3 mousePosition)
        {
            var cellPosition = GetCellCoordinates(mousePosition);
            
            return _renderField.GetCellCenterWorld(cellPosition);
        }
        
        private bool IsOnFieldCriteria(Vector3Int cell)
        {
            return _cells.GetLength(0) > cell.x
                   && _cells.GetLength(1) > cell.y
                   && cell.x >= 0
                   && cell.y >= 0;
        }

        private Vector3Int GetCellCoordinates(Vector3 pointerPosition)
        {
            var worldPoint = Camera.main.ScreenToWorldPoint(pointerPosition);

            return _renderField.WorldToCell(worldPoint);
        }
    
        private void GenerateEmptyField()
        {
            _cells = new Cell[_width, _height];
            for (var i = 0; i < _cells.GetLength(0); i++)
            {
                for (var j = 0; j < _cells.GetLength(1); j++)
                {
                    _cells[i, j] = new Cell();
                }
            }
        }
    }
}