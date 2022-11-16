using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    [SerializeField] private int _totalWood; //valor dos tocos de madeira
    [SerializeField] private float _currentWater; //valor da agua no regador
    private int waterLimit = 50; //limite do regador

    public int totalWood
    {
        get {return _totalWood;}
        set {_totalWood = value;}
    }

     public float currentWater
    {
        get {return _currentWater;}
        set {_currentWater= value;}
    }
    
    public void WaterLimit(float water)
    {

        if(_currentWater < waterLimit)
        {
            _currentWater += water;
        }
    }
}
