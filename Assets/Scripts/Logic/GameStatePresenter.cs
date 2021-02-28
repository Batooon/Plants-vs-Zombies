using TMPro;
using UnityEngine;

namespace PvZ.Logic
{
    public class GameStatePresenter : MonoBehaviour
    {
        [SerializeField] private float _pauseTimeScale = 0f;
        [SerializeField] private string _gameOverText;
        [SerializeField] private TextMeshProUGUI _finalText;
        [SerializeField] private GameObject _gameOverScreen;
        private HouseZone _house;

        public void Init(HouseZone house)
        {
            _house = house;
            _house.ZombieEntersHouse += GameOver;
        }

        private void OnDisable()
        {
            _house.ZombieEntersHouse -= GameOver;
        }

        private void GameOver()
        {
            Time.timeScale = _pauseTimeScale;
            _gameOverScreen.SetActive(true);
            _finalText.text = _gameOverText;
        }
    }
}