using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void MainMenuBad()
    {
        SceneManager.LoadScene("MainMenuBad");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void CreditsBad()
    {
        SceneManager.LoadScene("CreditsForBadTitle");
    }

    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
