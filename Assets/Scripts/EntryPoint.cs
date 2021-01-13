using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using UI;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private PlantsShop _plantsShop;
    [SerializeField] private List<PlantShopData> _plantDatas;
    [SerializeField] private Tilemap _tilemap;
    
    private void Awake()
    {
        _plantsShop.Init(_plantDatas, _tilemap);
    }
}