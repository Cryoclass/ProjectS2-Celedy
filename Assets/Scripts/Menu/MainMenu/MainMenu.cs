using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MainCam>().SetPos(0, 0);
        Debug.Log(Application.dataPath);

        PlayerPrefs.SetInt("PlayerCurrentLife", 10);
        SceneManager.LoadScene("Intro");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
