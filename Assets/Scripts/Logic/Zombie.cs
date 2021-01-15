using System.Collections;
using UnityEngine;

namespace Logic
{
    [RequireComponent(typeof(Collider2D))]
    public class Zombie : MonoBehaviour
    {
        [SerializeField] private float _delayAttack;
        [SerializeField] private int _damage;

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

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out Plant plant))
            {
                _attacking = true;
                StartCoroutine(Eat(plant));
            }
        }

        private IEnumerator Eat(Plant plant)
        {
            while (plant.Health > 0)
            {
                plant.GetDamage(_damage);
                if (plant.Health <= 0)
                {
                    _attacking = false;
                    yield break;
                }
                yield return new WaitForSecondsRealtime(_delayAttack);
            }
        }
    }
}