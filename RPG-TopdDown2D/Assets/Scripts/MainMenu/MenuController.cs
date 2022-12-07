using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour

{
    private string nextLvl;
    [SerializeField] private GameObject ExitYesOrNo;
    [SerializeField] private GameObject Options;
    [SerializeField] private GameObject Menu;
    [SerializeField] private GameObject Exit;
    
    public void StartGame(string nextLvl)
    {
        SceneManager.LoadScene(nextLvl);
    }

    public void ExitGame()
    {
       ExitYesOrNo.SetActive(true);
    }

    public void ExitGameYes()
    {
        Application.Quit();
        Debug.Log("Saiu");
        ExitYesOrNo.SetActive(false);
    }
    
    public void ExitGameNo()
    {
        ExitYesOrNo.SetActive(false);
    }

    public void OptionsGame()
    {
        Options.SetActive(true);
        Menu.SetActive(false);
    }

    public void BackMenu()
    {
        Menu.SetActive(true);
        Options.SetActive(false);
    }
}
