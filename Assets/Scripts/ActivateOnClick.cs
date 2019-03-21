using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivateOnClick : MonoBehaviour
{
    [Tooltip("Int for sceneIndex to new scene")]
    [SerializeField]
    private int sceneSelected = 1;

    public void GoToScene()
    {
        SceneManager.LoadScene(sceneSelected);
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
