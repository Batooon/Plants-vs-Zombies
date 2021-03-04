using UnityEngine;

namespace PvZ.Logic.Zombies
{
    public class AttackTransition : ZombieTransition
    {
        protected override void Enable()
        {
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (Zombie.CollidedWithPlant(out var plant, other) == false)
                return;
            TargetState.SetTargetPlant(plant);
            NeedTransit = true;
        }
    }
}