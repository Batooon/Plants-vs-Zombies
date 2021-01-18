using Data;
using UnityEngine;

namespace Logic
{
    public class SkySunSpawner : MonoBehaviour
    {
        [SerializeField] private SunPresenter _sun;
        [SerializeField] private float _leftBorder;
        [SerializeField] private float _rightBorder;
        [SerializeField] private Transform _spawnPosition;
        [SerializeField] private float _duration;
        [SerializeField] private float _speed;
        [SerializeField] private float _periodTime;
        [SerializeField] private int _sunsAmount;
        private PlayerData _playerData;

        public void Init(PlayerData playerData)
        {
            _playerData = playerData;
            InvokeRepeating(nameof(SpawnSun), 1.5f, _periodTime);
        }
        
        private void SpawnSun()
        {
            SunPresenter sunPresenter = Instantiate(_sun.gameObject,
                new Vector2(Random.Range(_leftBorder, _rightBorder), _spawnPosition.position.y),
                Quaternion.identity).GetComponent<SunPresenter>();
            sunPresenter.Init(_sunsAmount, _playerData);
            sunPresenter.StartDroppingFromTheSky(_speed, _duration);
        }
    }
}