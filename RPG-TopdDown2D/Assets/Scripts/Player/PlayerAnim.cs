using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Player player;
    private Animator anim;
    private Casting casting;
    private House house;
    private bool isHitting;
    private float timeCount;
    [SerializeField] private float recoveryTime = 1f;

    
    [Header("Attack Settings")]
    [SerializeField]private Transform point; 
    [SerializeField] private float radius;
    [SerializeField] private LayerMask enemyLayer;

    


    
    void Start()
    {
    
        anim = GetComponent<Animator>();
        player = GetComponent<Player>();
        casting = FindObjectOfType<Casting>();
        house = FindObjectOfType<House>();
       
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();

        if(isHitting)
        {
         timeCount += Time.deltaTime;
        
        if(timeCount >= recoveryTime)
        {
            isHitting = false;
            timeCount = 0f;
        }
        }

        OnSkills();
        OnAttackPlayer();
    
    }

    #region Movement

    void OnMove()
    {
        if (player.direction.sqrMagnitude > 0 )
        {
            if (player.isRolling) //rolar
            {
                if(!anim.GetCurrentAnimatorStateInfo(0).IsName("player_roll"))
                {
                    anim.SetTrigger("isRoll");
                }
            }
            else
            {   
                anim.SetInteger("Transition", 1); //andar
            }
            
        }
        else
        {
            anim.SetInteger("Transition", 0); //iddle
        }

        if (player.direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0,0); //direcao
        }
        if (player.direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0,180f); //direcao rotacionando
        }
         if(player.isRuning && player.direction.sqrMagnitude > 0) //correr
        {
            anim.SetInteger("Transition", 2);
        }
    }
    #endregion

    #region Skills  
    public void OnSkills()
    {

        if(player.isCutting)
        {
            anim.SetInteger("Transition", 3); //cortar arvore
            
        }

        if(player.isDigging)
        {
            anim.SetInteger("Transition", 4); //escavar
        }

        if(player.isWatering)
        {
            anim.SetInteger("Transition", 5); //encher regador
            
        }

    }

    public void OnCastingStarted() //comecou pescar
    {
        anim.SetTrigger("IsCasting");
        player.isPaused = true;
    }   
    public void OnCastingEndend() //parou de pescar
    {
        casting.OnCasting();
        player.isPaused = false;
    }

    public void OnHammeringStarted() //comecou regar
    {
        anim.SetBool("isHammering", true);
    }
    public void OnHammeringEnded() //parou de regar
    {
        anim.SetBool("isHammering", false);
    }

    #endregion

    #region Attack


    public void OnHurt() //ataque do inimigo
    {
       if(!isHitting)
       {
        anim.SetTrigger("isHurt");
        isHitting = true;
       }
    }

    public void OnAttackPlayer() //ataque do player
    {
        if(player.isAttack)
        {
            anim.SetInteger("Transition", 6);
        }
    }
    public void OnAttack() // ataque do player
    {
        Collider2D hit = Physics2D.OverlapCircle(point.position, radius, enemyLayer);
        
        if(hit != null)
        {
            //atacou o inimigo
           hit.GetComponentInChildren<AnimationControl>().OnHit();
        }
    }
    public void OnDrawGizmosSelected() //esfera de colisao
    {
        Gizmos.DrawWireSphere(point.position, radius);
    }
    #endregion
}
  