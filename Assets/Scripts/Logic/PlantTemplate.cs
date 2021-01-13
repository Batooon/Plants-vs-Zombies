using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Logic
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class PlantTemplate : MonoBehaviour
    {
        private Tilemap _tilemap;
        private Vector2 _initialPosition;
        private SpriteRenderer _spriteRenderer;

        public void Init(Vector2 initialPosition, Tilemap tilemap)
        {
            _tilemap = tilemap;
            _initialPosition = initialPosition;
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderer.enabled = false;
            Debug.Log(_tilemap.origin);
            Debug.Log(_tilemap.cellBounds);
        }

        private void OnMouseDrag()
        {
            _spriteRenderer.enabled = true;
            Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = position;
        }

        private void OnMouseUpAsButton()
        {
            //Если отпустил не над клеткой или над занятой клеткой
            _spriteRenderer.enabled = false;
            transform.position = _initialPosition;
        }
    }
}