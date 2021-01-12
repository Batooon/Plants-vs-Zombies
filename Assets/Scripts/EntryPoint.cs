using System.Collections;
using System.Collections.Generic;
using Data;
using UI;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private PlantsShop _plantsShop;
    [SerializeField] private List<PlantData> _plantDatas;
    
    private void Awake()
    {
        _plantsShop.Init(_plantDatas);
    }
}
