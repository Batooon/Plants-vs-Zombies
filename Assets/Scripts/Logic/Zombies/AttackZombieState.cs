using System;
using System.Collections;
using PvZ.Logic.Plants;
using UnityEngine;

namespace PvZ.Logic.Zombies
{
    [RequireComponent(typeof(Collider2D))]
    public class AttackZombieState : ZombieState
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _delayAttack;
        private WaitForSecondsRealtime _delay;
        private readonly int Attack = Animator.StringToHash("attack");

        private void Awake()
        {
            _delay = new WaitForSecondsRealtime(_delayAttack);
        }

        private void OnEnable()
        {
            if (Animator != null)
                Animator.SetTrigger(Attack);
            StartCoroutine(EatPlant());
        }

        private void OnDisable()
        {
            if (Animator != null)
                Animator.ResetTrigger(Attack);
        }

        private IEnumerator EatPlant()
        {
            while (enabled)
            {
                if (Plant.Health - _damage <= 0)
                {
                    ApplyDamageTo(Plant);
                    yield break;
                }

                ApplyDamageTo(Plant);
                yield return _delay;
            }
        }

        private void ApplyDamageTo(Plant plant)
        {
            plant.GetDamage(_damage);
        }
    }
}