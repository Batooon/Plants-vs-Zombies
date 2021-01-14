using UnityEngine;
using UnityEngine.Tilemaps;

namespace Logic
{
    public class Field
    {
        private Cell[,] _cells;
        private readonly int _width;
        private readonly int _height;
        private readonly Tilemap _renderField;
    
        public Field(int width, int height, Tilemap renderField)
        {
            _width = width;
            _height = height;
            _renderField = renderField;
            GenerateEmptyField();
        }

        public void TryPlacePlant(Vector3 mousePosition, GameObject plant)
        {
            var cellPosition = GetCellCoordinates(mousePosition);

            if (IsOnFieldCriteria(cellPosition) == false)
                return;
            
            if (_cells[cellPosition.x, cellPosition.y].IsEmpty == false)
                return;

            Object.Instantiate(plant, GetCellCenterCoordinates(mousePosition), Quaternion.identity);
            _cells[cellPosition.x, cellPosition.y].IsEmpty = false;
        }

        public bool IsPointerOverField(Vector3 pointerPosition)
        {
            var cellPosition = GetCellCoordinates(pointerPosition);

            return IsOnFieldCriteria(cellPosition);
        }

        private bool IsOnFieldCriteria(Vector3Int cell)
        {
            return _cells.GetLength(0) > cell.x
                   && _cells.GetLength(1) > cell.y
                   && cell.x >= 0
                   && cell.y >= 0;
        }

        public Vector3 GetCellCenterCoordinates(Vector3 mousePosition)
        {
            var cellPosition = GetCellCoordinates(mousePosition);
            
            return _renderField.GetCellCenterWorld(cellPosition);
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