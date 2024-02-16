using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        print("Hello");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
