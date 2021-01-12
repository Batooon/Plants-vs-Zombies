﻿using System.Collections;
using System.Collections.Generic;
using Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlantCardPresenter : MonoBehaviour
{
    [SerializeField] private Image _plantImage;
    [SerializeField] private string _costTemplate;
    [SerializeField] private TextMeshProUGUI _costText;

    public void Init(PlantData plantData)
    {
        _plantImage.sprite = plantData._icon;
        _costText.text = string.Format(_costTemplate, plantData._cost);
    }
}