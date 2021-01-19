using TMPro;
using UnityEngine;

namespace Logic
{
    public class GameStatePresenter : MonoBehaviour
    {
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
            Time.timeScale = 0f;
            _gameOverScreen.SetActive(true);
            _finalText.text = "GAME OVER";
        }
    }
}