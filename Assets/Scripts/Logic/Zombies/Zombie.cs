using PvZ.Logic.Plants;
using UnityEngine;

namespace PvZ.Logic.Zombies
{
    [RequireComponent(typeof(ZombieStateMachine))]
    public class Zombie : MonoBehaviour
    {
        [SerializeField] private float _delayAttack;
        [SerializeField] private int _damage;
        [SerializeField] private int _health;
        [SerializeField] private float _speed;

        private ZombieStateMachine _stateMachine;

        public void Init()
        {
            _stateMachine = GetComponent<ZombieStateMachine>();
            _stateMachine.Init();
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
        
        public static bool CollidedWithPlant(out Plant plant, Collision2D other)
        {
            return other.gameObject.TryGetComponent(out plant);
        }
    }
}