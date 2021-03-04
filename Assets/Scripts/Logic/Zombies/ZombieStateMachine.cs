using UnityEngine;

namespace PvZ.Logic.Zombies
{
    public class ZombieStateMachine : MonoBehaviour
    {
        [SerializeField] private ZombieState _firstState;
        private ZombieState _currentState;
        private Animator _animator;

        public void Init(Animator animator)
        {
            _animator = animator;
            _currentState = _firstState;
            _currentState.Enter(_animator);
        }

        private void Update()
        {
            if (_currentState == null)
                return;
            var nextState = _currentState.GetNextState();
            if (nextState != null)
                Transit(nextState);
        }

        private void Transit(ZombieState nextState)
        {
            _currentState.Exit();

            _currentState = nextState;

            _currentState.Enter(_animator);
        }
    }
}