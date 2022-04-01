using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void startClick()
    {
        if (SceneManager.GetActiveScene().name != "Menu")
        {
            GameManager.instance.gameOver = false;
            GameManager.instance.score = 0;
            GameManager.instance.speed = 1;
        }
        SceneManager.LoadScene("Main");
    }

    public void exitClick()
    {
#if UNITY_EDITOR

        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
