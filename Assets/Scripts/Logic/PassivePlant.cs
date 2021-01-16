using UnityEngine;

namespace Logic
{
    public class PassivePlant : Plant
    {
        [SerializeField] private float _delayAction;
        [SerializeField] private SunPresenter _objectToInstantiate;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private int _sunAmount;

        private void Start()
        {
            InvokeRepeating(nameof(Spawn), _delayAction, _delayAction);
        }

        private void Spawn()
        {
            SunPresenter spawnedSun = Instantiate(_objectToInstantiate.gameObject, _spawnPoint.position, Quaternion.identity)
                .GetComponent<SunPresenter>();
            spawnedSun.Init(_sunAmount, _playerData);
        }
    }
}