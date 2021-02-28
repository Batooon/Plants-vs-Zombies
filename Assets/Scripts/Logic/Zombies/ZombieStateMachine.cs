using UnityEngine;

namespace PvZ.Logic.Zombies
{
    public class ZombieStateMachine : MonoBehaviour
    {
        [SerializeField] private ZombieState _firstState;
        private ZombieState _currentState;

        public void Init()
        {
            _currentState = _firstState;
            _currentState.Enter();
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

            _currentState.Enter();
        }
    }
}