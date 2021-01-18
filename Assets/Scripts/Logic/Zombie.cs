using System;
using System.Collections;
using UnityEngine;

namespace Logic
{
    [RequireComponent(typeof(Collider2D))]
    public class Zombie : MonoBehaviour
    {
        [SerializeField] private float _delayAttack;
        [SerializeField] private int _damage;
        [SerializeField] private int _health;

        private float _speed;
        private bool _attacking;

        public void Init(float speed)
        {
            _speed = speed;
        }
        
        private void Update()
        {
            if (_attacking)
                return;
            transform.position += Vector3.left * _speed * Time.deltaTime;
        }

        public void GetDamage(int amount)
        {
            _health -= amount;
            if (_health <= 0)
                Die();
        }

        private void Die()
        {
            Destroy(gameObject);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out Plant plant))
            {
                _attacking = true;
                StartCoroutine(Eat(plant));
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out Plant plant))
            {
                _attacking = false;
            }
        }

        private IEnumerator Eat(Plant plant)
        {
            while (_attacking)
            {
                if (plant.Health - _damage <= 0)
                {
                    plant.GetDamage(_damage);
                    _attacking = false;
                    yield break;
                }
                
                plant.GetDamage(_damage);
                yield return new WaitForSecondsRealtime(_delayAttack);
            }
        }
    }
}