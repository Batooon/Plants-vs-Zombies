using System.Collections.Generic;
using Data;
using Logic;
using UI;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private PlantsShop _plantsShop;
    [SerializeField] private ZombieWavesSpawner _zombieWavesSpawner;
    [SerializeField] private List<PlantShopData> _plantDatas;
    [SerializeField] private Tilemap _tilemap;
    [SerializeField] private int _fieldWidth;
    [SerializeField] private int _fieldHeight;

    private Field _plantsField;
    
    private void Awake()
    {
        _plantsField = new Field(_fieldWidth, _fieldHeight, _tilemap);
        
        _plantsShop.Init(_plantDatas, _plantsField);

        _zombieWavesSpawner.Init(_plantsField);
    }
}