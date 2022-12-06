using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private string nextLvl;
    [Header("Menu Initial")]
    [SerializeField] private GameObject MenuInitial;
    // Start is called before the first frame update
    void Start()
    {
        MenuInitial.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void NewGame(string nextLvl)
    {
        SceneManager.LoadScene(nextLvl);
    }
}
