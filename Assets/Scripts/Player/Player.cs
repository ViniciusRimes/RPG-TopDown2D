using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public bool isPaused;
    [SerializeField]private float speed;
    [SerializeField]private float runSpeed;

    private PlayerItems playeritems;
    private PlayerAnim playerAnim;
    [HideInInspector] public int handlingObj; //objeto na mão do player
     
    private Rigidbody2D rig;
    [HideInInspector]public float Damage;

    #region Varibles privates
    private float initialSpeed;
    private bool _isRuning; //correr
    private bool _isRolling; //rolar
    private bool _isCutting; //cortar arvore
    private Vector2 _direction; //direcao do player
    private bool _isDigging; //escavar
    private bool _isWatering; //regar
    private bool _isAttack;
    #endregion

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

    public bool isAttack { get => _isAttack; set => _isAttack = value; }


    #endregion


    private void Awake()
    {
       
    }
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        initialSpeed = speed;
        playeritems = FindObjectOfType<PlayerItems>();  
        playerAnim = FindObjectOfType<PlayerAnim>();

    }
    
    private void Update()
    {
        if(!isPaused)
        {
            if(Input.GetKeyDown(KeyCode.Alpha1)) //machado
            {
            handlingObj = 0;
            }
            
            else if(Input.GetKeyDown(KeyCode.Alpha2)) //enxada
            {   
            handlingObj = 1;
            }
            
            else if(Input.GetKeyDown(KeyCode.Alpha3)) //regador
            {
            handlingObj = 2;
            }

            else if(Input.GetKeyDown(KeyCode.Alpha4)) //espada
            {
            handlingObj = 3;
            }

        OnInput();

        OnRun();
        OnRolling();
        OnCutting();
        OnDig();
        OnAttack();
        OnWatering();

        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("test");
        }
    
    }
        
    private void FixedUpdate()
    {
        if(!isPaused)
        {
        OnMove();
        }
    
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
        if(handlingObj == 0)
        {
            if(Input.GetMouseButtonDown(0))
            {
            _isCutting = true;
            speed = 0f;
            Damage = 10f;
            }
        
            if(Input.GetMouseButtonUp(0))
            {
            _isCutting = false;
            speed = initialSpeed;
            }
        }
        else
        {
            _isCutting = false;
        }
    }

    void OnDig()
    {
       if(handlingObj == 1)
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
       else
       {
            _isDigging =false;
       }
        
    }

    void OnWatering()
    {
        if(handlingObj == 2)
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
        else
        {
            _isWatering = false;
        }

    }



    #endregion 

    #region Combat

    public void OnAttack()
    {
        if(handlingObj == 3)
        {
            if(Input.GetMouseButtonDown(0))
            {
            _isAttack = true;
            Damage = 40f;
            }

            if(Input.GetMouseButtonUp(0))
            {
            _isAttack = false;
            }
        }
        else
        {
            _isAttack = false;
        }


    }

    #endregion


    





}
