using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text;

public class GameOverScript : MonoBehaviour
{
    [SerializeField]
    public Text currScore;
    [SerializeField]
    public Text maxScore;

    [SerializeField]
    public Text gameScoreText;

    public void Setup() {
        gameObject.SetActive(true);
        currScore.text = gameScoreText.text.Split(' ')[1];
    }

    public void RestartButton() {
        SceneManager.LoadScene("Game");
        ParabolicMovement.isGameInProgress = true;
    }

    public void MainMenuButton() {
        SceneManager.LoadScene("MainMenu");
    }
}
