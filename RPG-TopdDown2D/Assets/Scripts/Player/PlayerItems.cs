using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    [Header("Limits")]
    [SerializeField]private int _woodLimit = 10; //limite de coleta de madeira
    [SerializeField]private int _waterLimit = 50; //limite do regador
    [SerializeField]private int _carrotLimit = 20; //limite de coleta da cenoura
    
    [Header("Amounts")]
    [SerializeField] private int _totalWood; //valor dos tocos de madeira coletados
    [SerializeField] private float _currentWater; //valor da agua no regador
    [SerializeField] private int _totalCarrot; //valor das cenouras coletadas
  

    public int totalWood
    {
        get {return _totalWood;}
        set {_totalWood = value;}
    }
    public int totalCarrot
    {
        get {return _totalCarrot;}
        set {_totalCarrot = value;}
    }

     public float currentWater
    {
        get {return _currentWater;}
        set {_currentWater= value;}
    }

    public int waterLimit { get => _waterLimit; set => _waterLimit = value; }
    public int carrotLimit { get => _carrotLimit; set => _carrotLimit = value; }
    public int woodLimit { get => _woodLimit; set => _woodLimit = value; }

    public void WaterLimit(float water)
    {

        if(_currentWater < waterLimit)
        {
            _currentWater += water;
        }
    }
}
