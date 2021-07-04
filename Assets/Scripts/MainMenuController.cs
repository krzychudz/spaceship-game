using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    public AudioSource audioSource;

    public void PlayOnClicked()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitOnClicked()
    {
        Application.Quit();
    }

    public void OnHover()
    {
        audioSource.Play();
    }
}
