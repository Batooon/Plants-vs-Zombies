using System;
using Logic;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class ZombieData
    {
        [SerializeField] private Zombie _zombie;
        [SerializeField] private float _speed;
        [SerializeField] private int _lineIndexToSpawn;
        [SerializeField] private float _delaySpawnTime;

        public Zombie ZombiePrefab => _zombie;
        public float Speed => _speed;
        public int LineIndexToSpawn => _lineIndexToSpawn;
        public float DelaySpawnTime => _delaySpawnTime;
    }
}