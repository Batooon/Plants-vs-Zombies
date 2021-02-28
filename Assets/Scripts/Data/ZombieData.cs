using System;
using PvZ.Logic;
using PvZ.Logic.Zombies;
using UnityEngine;

namespace PvZ.Data
{
    [Serializable]
    public class ZombieData
    {
        [SerializeField] private Zombie _zombieTemplate;
        [SerializeField] private int _lineIndexToSpawn;
        [SerializeField] private float _delaySpawnTime;

        public Zombie ZombieTemplatePrefab => _zombieTemplate;
        public int LineIndexToSpawn => _lineIndexToSpawn;
        public float DelaySpawnTime => _delaySpawnTime;
    }
}