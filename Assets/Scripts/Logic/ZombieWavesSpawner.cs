using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;

namespace Logic
{
    public class ZombieWavesSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _spawnLine;
        [SerializeField] private List<ZombieWaveData> _zombieWaves;
        private Field _field;

        public void Init(Field field)
        {
            _field = field;
        }

        private void Start()
        {
            StartCoroutine(StartWaveSpawning());
        }

        private IEnumerator StartWaveSpawning()
        {
            for (int i = 0; i < _zombieWaves.Count; i++)
            {
                ZombieWaveData currentWave = _zombieWaves[i];

                yield return new WaitForSecondsRealtime(currentWave.DelayStartTime);

                for (int j = 0; j < currentWave.Zombies.Count; j++)
                {
                    ZombieData currentZombie = currentWave.Zombies[j];
                    yield return new WaitForSecondsRealtime(currentZombie.DelaySpawnTime);
                    Zombie spawnedZombie = Spawn(currentZombie.ZombiePrefab, currentZombie.LineIndexToSpawn);
                    spawnedZombie.Init(currentZombie.Speed);
                }
            }
        }

        private Zombie Spawn(Zombie zombie, int line)
        {
            Vector3 spawnPosition = new Vector3(_spawnLine.position.x, _field.GetCellCenterVerticalPosition(line), 0);
            return Instantiate(zombie.gameObject, spawnPosition, Quaternion.identity).GetComponent<Zombie>();
        }
    }
}