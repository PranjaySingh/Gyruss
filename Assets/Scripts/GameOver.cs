using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void RestartBtn()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
