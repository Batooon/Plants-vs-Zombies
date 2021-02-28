using UnityEngine;

namespace PvZ.Logic.Zombies
{
    public abstract class ZombieTransition : MonoBehaviour
    {
        [SerializeField] private ZombieState _targetState;
        public ZombieState TargetState => _targetState;
        public bool NeedTransit { get; protected set; }

        private void OnEnable()
        {
            NeedTransit = false;
            Enable();
        }

        protected abstract void Enable();
    }
}