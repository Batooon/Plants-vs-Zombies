using UnityEngine;

namespace Logic
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class PlantTemplate : MonoBehaviour
    {
        private Vector2 _initialPosition;
        private SpriteRenderer _spriteRenderer;
        private Field _field;
        private Plant _fieldPlant;

        public void Init(Vector2 initialPosition, Field field, Plant plantOnField)
        {
            _fieldPlant = plantOnField;
            _field = field;
            _initialPosition = initialPosition;
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderer.enabled = false;
        }

        private void OnMouseDown()
        {
            _spriteRenderer.enabled = true;
        }

        private void OnMouseDrag()
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            transform.position = _field.IsPointerOverField(Input.mousePosition)
                ? _field.GetCellCenterCoordinates(Input.mousePosition)
                : mousePosition;
        }

        private void OnMouseUp()
        {
            _field.TryPlacePlant(Input.mousePosition, _fieldPlant.gameObject);
            _spriteRenderer.enabled = false;
            transform.position = _initialPosition;
        }
    }
}