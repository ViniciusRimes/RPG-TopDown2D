using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    private Animator anim;
    private PlayerAnim playerAnim;
    private Skeleton skeleton;

    [SerializeField] private Transform point;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask playerLayer;



    private void Start()
    {
        anim = GetComponent<Animator>();
        playerAnim = FindObjectOfType<PlayerAnim>();
        skeleton = FindObjectOfType<Skeleton>();
    }
    public void PlayAnim(int value)
    {
        anim.SetInteger("Transition", value);
    }


    public void Attack()
    {
        Collider2D hit = Physics2D.OverlapCircle(point.position, radius, playerLayer);
    
        if(hit != null)
        {
            //detecta colisao com o player
            playerAnim.OnHurt(); //hit

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(point.position, radius);
    }

    public void OnHit() //hit do skeleton
    {
        anim.SetTrigger("isHurt");
        skeleton.Health -= 20;
    }

}