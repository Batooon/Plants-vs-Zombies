using System;
using System.Collections;
using Data;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Logic
{
    public class SunPresenter : MonoBehaviour
    {
        [SerializeField] private float _moveDuration;
        [SerializeField] private Ease _ease;
        [SerializeField] private float _lifetime;
        private Sun _sun;
        private Sequence _dropping;

        public void Init(int sunAmount, PlayerData playerData)
        {
            _sun = new Sun(sunAmount, playerData);
            _sun.SunCollected += OnSunCollected;
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
            Vector2 position = new Vector2(transform.position.x, transform.position.y);
            _dropping.Append(transform.DOLocalMove(Random.insideUnitCircle + position, _moveDuration).SetEase(_ease)
                .OnComplete(StartLifetime));
        }

        private IEnumerator DropFromTheSky(float duration, float speed)
        {
            for (float i = 0; i < duration; i += Time.deltaTime)
            {
                transform.position += Vector3.down * speed * Time.deltaTime;
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