using UnityEngine;

namespace Logic
{
    public class PassivePlant : Plant
    {
        [SerializeField] private float _delayAction;
        [SerializeField] private GameObject _objectToInstantiate;
        [SerializeField] private Transform _spawnPoint;

        private void Start()
        {
            InvokeRepeating(nameof(Spawn), _delayAction, _delayAction);
        }

        private void Spawn()
        {
            
        }
    }
}