using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void GameScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void ControlsScreen(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
