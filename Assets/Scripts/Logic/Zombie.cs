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
        [SerializeField] private float _speed;
        private bool _attacking;
        private Transform _transform;

        public void Init()
        {
            _transform = transform;
        }
        
        private void Update()
        {
            if (_attacking)
                return;
            
            _transform.position += Vector3.left * (_speed * Time.deltaTime);
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
            if (CollidedWithPlant(out var plant, other) == false)
                return;
            
            _attacking = true;
            StartCoroutine(Eat(plant));
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (CollidedWithPlant(out _, other) == false)
                return;
            
            _attacking = false;
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
        
        private bool CollidedWithPlant(out Plant plant, Collision2D other)
        {
            return other.gameObject.TryGetComponent(out plant);
        }
    }
}