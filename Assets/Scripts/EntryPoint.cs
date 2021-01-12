using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private PlantsShop _plantsShop;
    
    private void Awake()
    {
        _plantsShop.Init();
    }
}
