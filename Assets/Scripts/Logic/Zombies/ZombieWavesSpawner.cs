using System.Collections;
using System.Collections.Generic;
using PvZ.Data;
using PvZ.Logic.GameField;
using UnityEngine;

namespace PvZ.Logic.Zombies
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
            foreach (var currentWave in _zombieWaves)
            {
                yield return new WaitForSecondsRealtime(currentWave.DelayStartTime);

                foreach (var currentZombie in currentWave.Zombies)
                {
                    yield return new WaitForSecondsRealtime(currentZombie.DelaySpawnTime);
                    var spawnedZombie = Spawn(currentZombie.ZombieTemplatePrefab, currentZombie.LineIndexToSpawn);
                    spawnedZombie.Init();
                }
            }
        }

        private Zombie Spawn(Zombie zombie, int line)
        {
            var spawnPosition = new Vector3(_spawnLine.position.x, _field.GetCellCenterVerticalPosition(line), 0);
            return Instantiate(zombie, spawnPosition, Quaternion.identity);
        }
    }
}