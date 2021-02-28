using PvZ.Data;
using TMPro;
using UnityEngine;

namespace PvZ.Logic
{
    public class PlayerPresenter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _sunsAmount;
        [SerializeField] private string _sunsAmountTemplate;

        private PlayerData _playerData;
    
        public void Init(PlayerData playerData)
        {
            _playerData = playerData;
        }

        private void OnEnable()
        {
            _playerData.SunsAmountChanged += OnSunsAmountChanged;
            OnSunsAmountChanged(_playerData.SunsAmount);
        }

        private void OnDisable()
        {
            _playerData.SunsAmountChanged -= OnSunsAmountChanged;
        }

        private void OnSunsAmountChanged(int newSunsAmount)
        {
            _sunsAmount.text = string.Format(_sunsAmountTemplate, newSunsAmount);
        }
    }
}