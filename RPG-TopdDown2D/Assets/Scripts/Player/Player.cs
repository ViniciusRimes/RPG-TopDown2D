using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]private float speed;
    [SerializeField]private float runSpeed;

    private PlayerItems playeritems;
     
    private Rigidbody2D rig;

    private float initialSpeed;
    private bool _isRuning; //correr
    private bool _isRolling; //rolar
    private bool _isCutting; //cortar arvore
    private Vector2 _direction; //direcao do player
    private bool _isDigging; //escavar
    private bool _isWatering; //regar
    private int handlingObj; //objeto na mão do player

    #region Encapsulation
    public Vector2 direction
    {
        get {return _direction;}
        set {_direction = value;}
    }

    public bool isRuning
    {
        get {return _isRuning;}
        set {_isRuning = value;}
    }

    public bool isRolling
    {
        get {return _isRolling;}
        set {_isRolling = value;}
    }

    public bool isCutting{
        get {return _isCutting;}
        set {_isCutting = value;}
    }
    
    public bool isDigging
    {
        get {return _isDigging;}
        set {_isDigging = value;}
    }

    public bool isWatering
    {
        get {return _isWatering;}
        set {_isWatering = value;}
    }


    #endregion
    
    
    private void Awake()
    {
       playeritems = FindObjectOfType<PlayerItems>();          

    }
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        initialSpeed = speed;
    }
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) //machado
        {
            handlingObj = 1;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2)) //enxada
        {   
            handlingObj = 2;

        }else if(Input.GetKeyDown(KeyCode.Alpha3)) //regador
        {
            handlingObj = 3;
        }

        OnInput();

        OnRun();
        OnRolling();
        
        switch(handlingObj)
        {
            case 1:
                OnCutting();
                break;

            case 2:
                OnDig();
                break;

            case 3:
                OnWatering();
                break;
        
                
        }
    }

    private void FixedUpdate()
    {
       OnMove();
    }

    #region Movement

    void OnInput()
    {
         _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));    
    }

    void OnMove()
    {
         rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
    }

    void OnRun()
    {
       if (Input.GetKeyDown(KeyCode.LeftShift))
       {
            speed = runSpeed;
            _isRuning = true;
       }

       if (Input.GetKeyUp(KeyCode.LeftShift))
       {
            speed = initialSpeed;
            _isRuning = false;
       }
    }

    void OnRolling()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _isRolling = true;
        }
        
        if (Input.GetMouseButtonUp(1))
        {
            _isRolling = false;
        }
    }

    void OnCutting()
    {
        
        if(Input.GetMouseButtonDown(0))
        {
            _isCutting = true;
            speed = 0f;
        }
        
        if(Input.GetMouseButtonUp(0))
        {
            _isCutting = false;
            speed = initialSpeed;
        }
    }

    void OnDig()
    {
       
        if(Input.GetMouseButtonDown(0))
        {
            _isDigging = true;
            speed = 0f;
        }
        
        if(Input.GetMouseButtonUp(0))
        {
            _isDigging = false;
            speed = initialSpeed;
        }
    }

    void OnWatering()
    {
    
         if(Input.GetMouseButtonDown(0) && playeritems.currentWater > 0)
        {
            _isWatering = true;
            speed = initialSpeed;

        }
        
        if(Input.GetMouseButtonUp(0) || playeritems.currentWater < 0)
        {
            _isWatering = false;
            speed = initialSpeed;
            if(playeritems.currentWater < 0)
            {
                playeritems.currentWater = 0;
            }
        }

        if(_isWatering)
        {
            playeritems.currentWater -= 0.01f;
        }

    }


    #endregion 


    





}
