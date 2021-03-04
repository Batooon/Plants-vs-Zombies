using PvZ.Logic.Plants;
using UnityEngine;

namespace PvZ.Logic.Zombies
{
    [RequireComponent(typeof(ZombieStateMachine))]
    public class Zombie : MonoBehaviour, IDamageable
    {
        [SerializeField] private float _delayAttack;
        [SerializeField] private int _damage;
        [SerializeField] private int _health;
        [SerializeField] private float _speed;
        [SerializeField] private Animator _animator;

        private ZombieStateMachine _stateMachine;

        public void Init()
        {
            _stateMachine = GetComponent<ZombieStateMachine>();
            _stateMachine.Init(_animator);
        }

        private void Die()
        {
            Destroy(gameObject);
        }
        
        public static bool CollidedWithPlant(out Plant plant, Collision2D other)
        {
            return other.gameObject.TryGetComponent(out plant);
        }

        public void ApplyDamage(int damage)
        {
            _health -= damage;
            if(_health<=0)
                Die();
        }
    }
}