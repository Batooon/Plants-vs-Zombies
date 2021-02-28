using System;
using System.Linq;
using PvZ.Logic.Plants;
using UnityEngine;

namespace PvZ.Logic.Zombies
{
    public abstract class ZombieState : MonoBehaviour
    {
        [SerializeField] private ZombieTransition[] _transitions;

        private void Update()
        {
        }

        public void Enter()
        {
            if (enabled)
                return;
            ChangeComponentStates(true);
        }

        public void Exit()
        {
            if (enabled == false)
                return;
            ChangeComponentStates(false);
        }

        public ZombieState GetNextState()
        {
            return (from transition in _transitions where transition.NeedTransit select transition.TargetState)
                .FirstOrDefault();
        }

        private void ChangeComponentStates(bool active)
        {
            enabled = active;
            foreach (var transition in _transitions)
            {
                transition.enabled = active;
            }
        }
    }
}