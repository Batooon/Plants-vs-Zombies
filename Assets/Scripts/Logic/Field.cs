using UnityEngine;
using UnityEngine.Tilemaps;

public class Field
{
    private Cell[,] _cells;
    private int _width;
    private int _height;
    private Tilemap _renderField;
    
    public Field(int width, int height, Tilemap renderField)
    {
        _width = width;
        _height = height;
        _renderField = renderField;
        GenerateEmptyField();
    }

    public void PlacePlant(Vector3 mousePosition, GameObject plant)
    {
        Vector3Int cellPosition = GetCellCoordinates(mousePosition);

        if (_cells[cellPosition.x, cellPosition.y].IsEmpty == false)
            return;

        GameObject instantiatedPlant = Object.Instantiate(plant, cellPosition, Quaternion.identity);
    }

    private Vector3Int GetCellCoordinates(Vector3 mousePosition)
    {
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector3Int cellPosition = _renderField.WorldToCell(worldPoint);
        return cellPosition;
    }
    
    private void GenerateEmptyField()
    {
        _cells = new Cell[_width, _height];
        for (int i = 0; i < _cells.GetLength(0); i++)
        {
            for (int j = 0; j < _cells.GetLength(1); j++)
            {
                _cells[i, j] = new Cell();
            }
        }
    }
}