using System.Collections.Generic;
using PvZ.Data;
using PvZ.Logic;
using PvZ.Logic.GameField;
using PvZ.Logic.Sun;
using PvZ.Logic.Zombies;
using PvZ.UI;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace PvZ
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private PlayerData _playerData;
        [SerializeField] private PlantsShop _plantsShop;
        [SerializeField] private ZombieWavesSpawner _zombieWavesSpawner;
        [SerializeField] private List<PlantShopData> _plantDatas;
        [SerializeField] private Tilemap _tilemap;
        [SerializeField] private PlayerPresenter _playerPresenter;
        [SerializeField] private SkySunSpawner _sunSkySpawner;
        [SerializeField] private HouseZone _houseZone;
        [SerializeField] private GameStatePresenter _gameStatePresenter;
        [SerializeField] private int _fieldWidth;
        [SerializeField] private int _fieldHeight;

        private Field _plantsField;
    
        private void Awake()
        {
            _plantsField = new Field(_fieldWidth, _fieldHeight, _tilemap, _playerData, _camera);

            _plantsShop.Init(_plantDatas, _plantsField, _playerData, _camera);

            _zombieWavesSpawner.Init(_plantsField);

            _playerPresenter.Init(_playerData);

            _sunSkySpawner.Init(_playerData);

            _gameStatePresenter.Init(_houseZone);
        }
    }
}