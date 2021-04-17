using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    [SerializeField]
    public Text currScore;
    [SerializeField]
    public Text maxScore;

    public void Setup(int score) {
        gameObject.SetActive(true);
        currScore.text = score.ToString();
    }

    public void RestartButton() {
        SceneManager.LoadScene("Game");
    }

    public void MainMenuButton() {
        SceneManager.LoadScene("MainMenu");
    }
}
