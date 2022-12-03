using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private float treeHealth; //vida da arvore
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject woodPrefab; // toco de madeira
    [SerializeField] private ParticleSystem leafs; //particulas das folhas

    private bool isCut;
    
    public void OnHit()
    {
        treeHealth--; //vida arvore diminuindo

        anim.SetTrigger("isHit");
        leafs.Play(); //particulas das folhas sendo ativadas

        if(treeHealth <= 0)
        {
            //cria o toco e instancia os drops(madeira)
            for(int i = 0; i < Random.Range(1f, 3f); i++)
            {
                
                    Instantiate(woodPrefab, transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f), transform.rotation); //instanciando o toco de madeira
                
            }
            anim.SetTrigger("Cut");
            isCut = true;

        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Axe") && !isCut)
        {
            OnHit();
        }
    }
}
