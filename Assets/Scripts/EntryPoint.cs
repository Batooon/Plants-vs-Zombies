using System.Collections.Generic;
using Data;
using Logic;
using UI;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private PlantsShop _plantsShop;
    [SerializeField] private ZombieWavesSpawner _zombieWavesSpawner;
    [SerializeField] private List<PlantShopData> _plantDatas;
    [SerializeField] private Tilemap _tilemap;
    [SerializeField] private PlayerPresenter _playerPresenter;
    [SerializeField] private SkySunSpawner _sunSkySpawner;
    [SerializeField] private int _fieldWidth;
    [SerializeField] private int _fieldHeight;

    private Field _plantsField;
    
    private void Awake()
    {
        _plantsField = new Field(_fieldWidth, _fieldHeight, _tilemap, _playerData);

        _plantsShop.Init(_plantDatas, _plantsField, _playerData);

        _zombieWavesSpawner.Init(_plantsField);

        _playerPresenter.Init(_playerData);

        _sunSkySpawner.Init(_playerData);
    }
}