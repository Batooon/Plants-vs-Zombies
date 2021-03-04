using System.Linq;
using PvZ.Logic.Plants;
using UnityEngine;

namespace PvZ.Logic.Zombies
{
    public abstract class ZombieState : MonoBehaviour
    {
        [SerializeField] private ZombieTransition[] _transitions;
        protected Plant Plant;
        protected Animator Animator;

        public void Enter(Animator animator)
        {
            if (enabled)
                return;
            Animator = animator;
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

        public void SetTargetPlant(Plant plant)
        {
            Plant = plant;
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