using System;
using UnityEngine;

namespace Logic
{
    public class ActivePlant : Plant
    {
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private float _delayShoot;
        [SerializeField] private Bullet _bullet;

        private void Start()
        {
            InvokeRepeating(nameof(Shoot), _delayShoot, _delayShoot);
        }

        private void Shoot()
        {
            Instantiate(_bullet.gameObject, _shootPoint.position, Quaternion.identity);
        }
    }
}