using System;
using PvZ.Data;
using PvZ.Logic.Plants;
using UnityEngine;
using UnityEngine.Tilemaps;
using Object = UnityEngine.Object;

namespace PvZ.Logic.GameField
{
    public class Field
    {
        private const int WidthDimension = 0;
        private const int HeightDimension = 1;
        private const int HeightMinimumBorderCoordinate = 0;
        private const int WidthMinimumBorderCoordinate = 0;
        private Cell[,] _cells;
        private readonly int _width;
        private readonly int _height;
        private readonly Tilemap _renderField;
        private readonly PlayerData _playerData;
        private readonly Camera _camera;

        public Field(int width, int height, Tilemap renderField, PlayerData playerData, Camera camera)
        {
            _width = width;
            _height = height;
            _renderField = renderField;
            _playerData = playerData;
            _camera = camera;
            GenerateEmptyField();
        }

        public void TryPlacePlant(Vector3 mousePosition, Plant plant, Action callback = null)
        {
            var cellPosition = GetCellCoordinates(mousePosition);

            if (IsOnFieldCriteria(cellPosition) == false)
                return;
            
            if (IsCellEmpty(cellPosition) == false)
                return;
            
            InitPlant(plant, cellPosition, mousePosition);
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
            return _cells.GetLength(WidthDimension) > cell.x
                   && _cells.GetLength(HeightDimension) > cell.y
                   && cell.x >= HeightMinimumBorderCoordinate
                   && cell.y >= WidthMinimumBorderCoordinate;
        }

        private Vector3Int GetCellCoordinates(Vector3 pointerPosition)
        {
            var worldPoint = _camera.ScreenToWorldPoint(pointerPosition);

            return _renderField.WorldToCell(worldPoint);
        }
    
        private void GenerateEmptyField()
        {
            _cells = new Cell[_width, _height];
            for (var i = 0; i < _cells.GetLength(WidthDimension); i++)
            {
                for (var j = 0; j < _cells.GetLength(HeightDimension); j++)
                {
                    _cells[i, j] = new Cell();
                }
            }
        }
        
        private void InitPlant(Plant plant, Vector3Int cellPosition, Vector3 mousePosition)
        {
            var placedPlant = Object.Instantiate(plant, GetCellCenterCoordinates(mousePosition), Quaternion.identity);
            placedPlant.Init(_playerData, _cells[cellPosition.x, cellPosition.y]);
            _cells[cellPosition.x, cellPosition.y].IsEmpty = false;
        }
        
        private bool IsCellEmpty(Vector3Int cellPosition)
        {
            return _cells[cellPosition.x, cellPosition.y].IsEmpty;
        }
    }
}