using System.Collections;
using PvZ.Data;
using PvZ.Logic;
using PvZ.Logic.Plants;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PvZ.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class PlantCardPresenter : MonoBehaviour
    {
        [SerializeField] private Image _plantImage;
        [SerializeField] private string _costTemplate;
        [SerializeField] private TextMeshProUGUI _costText;
        [SerializeField] private float _restoreStartingAlpha;
        [SerializeField] private float _restoreMaxAlpha;
        private PlantCard _plantCard;
        private CanvasGroup _canvasGroup;
        private PlantShopData _plantShopData;

        public void Init(PlantShopData plantShopData, PlantCard plantCard)
        {
            _plantCard = plantCard;
            _plantShopData = plantShopData;
            _canvasGroup = GetComponent<CanvasGroup>();
            _plantImage.sprite = plantShopData.Icon;
            _costText.text = string.Format(_costTemplate, plantShopData.Cost);
            _plantCard.PlantBought += StartRestoring;
        }

        private void OnEnable()
        {
            if (_plantCard != null)
                _plantCard.PlantBought += StartRestoring;
        }

        private void OnDisable()
        {
            _plantCard.PlantBought -= StartRestoring;
        }

        private void StartRestoring()
        {
            StartCoroutine(RestoreCard());
        }

        private IEnumerator RestoreCard()
        {
            for (float i = 0; i < _plantShopData.RestoreTime; i+=Time.deltaTime)
            {
                var normalizedTime = i / _plantShopData.RestoreTime;
                _canvasGroup.alpha = Mathf.Lerp(_restoreStartingAlpha, _restoreMaxAlpha, normalizedTime);
                yield return null;
            }
            _plantCard.OnCardRestored();
            _canvasGroup.alpha = _restoreMaxAlpha;
        }
    }
}