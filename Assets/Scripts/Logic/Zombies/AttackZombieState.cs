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
        private bool _attacking;

        private void Update()
        {
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (Zombie.CollidedWithPlant(out var plant, other))
            {
                StartCoroutine(Eat(plant));
            }
        }

        private IEnumerator Eat(Plant plant)
        {
            while (enabled)
            {
                if (plant.Health - _damage <= 0)
                {
                    ApplyDamageTo(plant);
                    yield break;
                }

                ApplyDamageTo(plant);
                yield return new WaitForSecondsRealtime(_delayAttack);
            }
        }

        private void ApplyDamageTo(Plant plant)
        {
            plant.GetDamage(_damage);
        }
    }
}