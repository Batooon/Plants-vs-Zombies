using System;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class ZombieWaveData
    {
        [SerializeField] private float _delayStartTime;
        [SerializeField] private List<ZombieData> _zombies;

        public float DelayStartTime => _delayStartTime;
        public List<ZombieData> Zombies => _zombies;
    }
}