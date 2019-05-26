﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MainCam>().SetPos(0, 0);
        SceneManager.LoadScene("Mouvement 1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
