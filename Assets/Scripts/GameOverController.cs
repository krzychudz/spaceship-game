using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverController : MonoBehaviour
{

    public AudioSource audioSource;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText.SetText("Score: " + GameManager.score.ToString());
        GameManager.ResetState();
    }

    public void OkOnClicked()
    {
        SceneManager.LoadScene(0);
    }

    public void OnHover()
    {
        audioSource.Play();
    }
}
