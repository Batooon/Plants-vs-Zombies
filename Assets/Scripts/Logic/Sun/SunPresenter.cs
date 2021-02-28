using System.Collections;
using DG.Tweening;
using PvZ.Data;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PvZ.Logic.Sun
{
    public class SunPresenter : MonoBehaviour
    {
        [SerializeField] private float _moveDuration;
        [SerializeField] private Ease _ease;
        [SerializeField] private float _lifetime;
        private Sun _sun;
        private Sequence _dropping;
        private Transform _transform;

        public void Init(int sunAmount, PlayerData playerData)
        {
            _sun = new Sun(sunAmount, playerData);
            _sun.SunCollected += OnSunCollected;
            _transform = transform;
        }

        public void StartDroppingFromTheSky(float speed, float duration)
        {
            StartCoroutine(DropFromTheSky(duration, speed));
        }

        private void OnDisable()
        {
            _sun.SunCollected -= OnSunCollected;
        }

        private void OnSunCollected()
        {
            _dropping.Kill();
            Destroy(gameObject);
        }

        private void OnMouseDown()
        {
            _sun.Collect();
        }

        public void Drop()
        {
            _dropping = DOTween.Sequence();
            var transformPosition = _transform.position;
            var position = new Vector2(transformPosition.x, transformPosition.y);
            _dropping.Append(transform.DOLocalMove(Random.insideUnitCircle + position, _moveDuration).SetEase(_ease)
                .OnComplete(StartLifetime));
        }

        private IEnumerator DropFromTheSky(float duration, float speed)
        {
            for (float i = 0; i < duration; i += Time.deltaTime)
            {
                _transform.position += Vector3.down * (speed * Time.deltaTime);
                yield return null;
            }
        }

        private void StartLifetime()
        {
            StartCoroutine(DestroyAfterLifetime());
        }
        
        private IEnumerator DestroyAfterLifetime()
        {
            while (_lifetime > 0)
            {
                _lifetime -= Time.deltaTime;
                yield return null;
            }

            Destroy(gameObject);
        }
    }
}