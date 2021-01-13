using UnityEngine;
using UnityEngine.Tilemaps;

namespace Logic
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class PlantTemplate : MonoBehaviour
    {
        private Vector2 _initialPosition;
        private SpriteRenderer _spriteRenderer;
        private Tilemap _tilemap;

        public void Init(Vector2 initialPosition, Tilemap tilemap)
        {
            _tilemap = tilemap;
            _initialPosition = initialPosition;
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderer.enabled = false;
        }

        private void OnMouseDrag()
        {
            _spriteRenderer.enabled = true;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cellPosition = _tilemap.WorldToCell(mousePosition);
            Vector3 position = _tilemap.GetCellCenterWorld(cellPosition);

            transform.position = position;
        }

        private void OnMouseUp()
        {
            //Если отпустил не над клеткой или над занятой клеткой
            _spriteRenderer.enabled = false;
            transform.position = _initialPosition;
        }
    }
}