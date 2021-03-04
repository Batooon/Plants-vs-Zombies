using UnityEngine;

namespace PvZ.Logic
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private int _damage;

        private void Update()
        {
            transform.position += Vector3.right * (_speed * Time.deltaTime);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out IDamageable damageable) == false) 
                return;
            
            damageable.ApplyDamage(_damage);
            Destroy(gameObject);
        }
    }
}