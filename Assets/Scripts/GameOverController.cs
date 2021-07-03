using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{

    public AudioSource audioSource;

    public void OkOnClicked()
    {
        SceneManager.LoadScene(0);
    }

    public void OnHover()
    {
        audioSource.Play();
    }
}
