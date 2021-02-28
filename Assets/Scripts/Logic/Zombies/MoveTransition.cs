using UnityEngine;

namespace PvZ.Logic.Zombies
{
    [RequireComponent(typeof(Collider2D))]
    public class MoveTransition : ZombieTransition
    {
        protected override void Enable()
        {
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (Zombie.CollidedWithPlant(out _, other))
                NeedTransit = true;
        }
    }
}