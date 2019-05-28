using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject GameOverUI;
    private bool isEnd = false;
    


    public void EndGame()
    {
        if (isEnd == false)
        {
            Debug.Log("Over");
            isEnd = true;
            GameOverUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
}
