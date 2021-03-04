using PvZ.Data;
using PvZ.Logic.Plants;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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
            _canvasGroup.alpha = _restoreStartingAlpha;
            _canvasGroup.DOFade(_restoreMaxAlpha, _plantShopData.RestoreTime).OnComplete(_plantCard.OnCardRestored);
        }
    }
}