using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    [Header("Limits")]
    [SerializeField]private float _woodLimit = 5; //limite de coleta de madeira
    [SerializeField]private float _waterLimit = 50; //limite do regador
    [SerializeField]private float _carrotLimit = 10; //limite de coleta da cenoura
    [SerializeField]private float _fishesLimit = 10; //limite dos peixes

    
    [Header("Amounts")]
    [SerializeField] private float _totalWood; //valor dos tocos de madeira coletados
    [SerializeField] private float _currentWater; //valor da agua no regador
    [SerializeField] private float _totalCarrot; //valor das cenouras coletadas
    [SerializeField] private float _totalfishes; //valor total dos peixes
  

    public float totalWood
    {
        get {return _totalWood;}
        set {_totalWood = value;}
    }
    public float totalCarrot
    {
        get {return _totalCarrot;}
        set {_totalCarrot = value;}
    }

    
    public float currentWater{get {return _currentWater;} set {_currentWater= value;}}
    public float waterLimit { get => _waterLimit; set => _waterLimit = value; }
    public float carrotLimit { get => _carrotLimit; set => _carrotLimit = value; }
    public float woodLimit { get => _woodLimit; set => _woodLimit = value; }
    public float totalfishes { get => _totalfishes; set => _totalfishes = value; }
    public float fishesLimit { get => _fishesLimit; set => _fishesLimit = value; }

    public void WaterLimit(float water)
    {

        if(_currentWater < waterLimit)
        {
            _currentWater += water;
        }
    }
}
