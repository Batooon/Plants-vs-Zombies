using UnityEngine;

namespace PvZ.Logic.Zombies
{
    public class MoveZombieState : ZombieState
    {
        [SerializeField] private float _speed;
        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        private void Update()
        {
            _transform.position += Vector3.left * (_speed * Time.deltaTime);
        }
    }
}