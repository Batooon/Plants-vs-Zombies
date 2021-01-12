using Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PlantCardPresenter : MonoBehaviour
    {
        [SerializeField] private Image _plantImage;
        [SerializeField] private string _costTemplate;
        [SerializeField] private TextMeshProUGUI _costText;

        public void Init(PlantData plantData)
        {
            _plantImage.sprite = plantData.Icon;
            _costText.text = string.Format(_costTemplate, plantData.Cost);
        }
    }
}