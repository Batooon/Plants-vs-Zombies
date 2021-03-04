using System;
using UnityEngine;

namespace PvZ.Logic.Zombies
{
    public class MoveZombieState : ZombieState
    {
        [SerializeField] private float _speed;
        private Transform _transform;
        private readonly int Walk = Animator.StringToHash("walk");

        private void Awake()
        {
            _transform = transform;
        }

        private void OnEnable()
        {
            if (Animator != null)
                Animator.SetTrigger(Walk);
        }

        private void OnDisable()
        {
            if (Animator != null)
                Animator.ResetTrigger(Walk);
        }

        private void Update()
        {
            _transform.position += Vector3.left * (_speed * Time.deltaTime);
        }
    }
}