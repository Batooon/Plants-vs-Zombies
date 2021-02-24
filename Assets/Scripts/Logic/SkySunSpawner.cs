using Data;
using UnityEngine;

namespace Logic
{
    public class SkySunSpawner : MonoBehaviour
    {
        [SerializeField] private float _spawnDelay = 1.5f;
        [SerializeField] private SunPresenter _sun;
        [SerializeField] private Transform _leftBorder;
        [SerializeField] private Transform _rightBorder;
        [SerializeField] private Transform _spawnPosition;
        [SerializeField] private float _duration;
        [SerializeField] private float _speed;
        [SerializeField] private float _periodTime;
        [SerializeField] private int _sunsAmount;
        private float _leftBorderXPosition;
        private float _rightBorderXPosition;
        private PlayerData _playerData;
        private Vector2 _sunSpawnCurrentPosition;

        public void Init(PlayerData playerData)
        {
            _leftBorderXPosition = _leftBorder.position.x;
            _rightBorderXPosition = _rightBorder.position.x;
            _playerData = playerData;
            _sunSpawnCurrentPosition = new Vector2(0, _spawnPosition.position.y);
            InvokeRepeating(nameof(SpawnSun), _spawnDelay, _periodTime);
        }
        
        private void SpawnSun()
        {
            _sunSpawnCurrentPosition.x = Random.Range(_leftBorderXPosition, _rightBorderXPosition);
            var sunPresenter = Instantiate(_sun, _sunSpawnCurrentPosition, Quaternion.identity);
            sunPresenter.Init(_sunsAmount, _playerData);
            sunPresenter.StartDroppingFromTheSky(_speed, _duration);
        }
    }
}