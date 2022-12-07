using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    private Animator anim;
    private PlayerAnim playerAnim;
    private Skeleton skeleton;
    private Player player;

    [SerializeField] private Transform point;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask playerLayer;



    private void Start()
    {
        anim = GetComponent<Animator>();
        playerAnim = FindObjectOfType<PlayerAnim>();
        skeleton = GetComponentInParent<Skeleton>();
        player = FindObjectOfType<Player>();
    
    }
    public void PlayAnim(int value)
    {
        anim.SetInteger("Transition", value);
    }


    public void Attack()
    {
        if(!skeleton.isDead)
        {
            Collider2D hit = Physics2D.OverlapCircle(point.position, radius, playerLayer);
    
            if(hit != null)
            {
            //detecta colisao com o player
            playerAnim.OnHurt(); //hit
            

            }
        }
        
    
    }

    private void OnDrawGizmosSelected()
    {
         Gizmos.DrawWireSphere(point.position, radius);
    }

    public void OnHit() //hit do skeleton
    {
        if(skeleton.currentHealth <= 0)
        {
            skeleton.isDead = true;
            anim.SetTrigger("isDeath");
            Destroy(skeleton.gameObject, 0.83f);
        }

        else
        {
           
            anim.SetTrigger("isHurt");
            skeleton.currentHealth -= player.Damage;

            skeleton.HealthBar.fillAmount = skeleton.currentHealth / skeleton.totalHealth;

        }

    }

}
