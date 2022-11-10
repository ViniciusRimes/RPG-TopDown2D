using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Player player;
    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
        OnRun();
        

    }

    #region Movement
    
    void OnMove()
    {
        if (player.direction.sqrMagnitude > 0 )
        {
            if (player.isRolling)
            {
                anim.SetTrigger("isRoll");
            }
            else
            {   
                anim.SetInteger("Transition", 1);
            }
            
        }
        else
        {
            anim.SetInteger("Transition", 0);
        }

        if (player.direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0,0);
        }
        if (player.direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0,180f);
        }
    }

    void OnRun()
    {
        if(player.isRuning == true)
        {
            anim.SetInteger("Transition", 2);
        }
    }



    #endregion


}
