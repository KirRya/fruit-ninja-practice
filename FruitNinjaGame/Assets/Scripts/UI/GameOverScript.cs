using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverScript : MonoBehaviour
{
    [SerializeField]
    public Text currScore;
    [SerializeField]
    public Text maxScore;

    [SerializeField]
    public Text gameScoreText;


    private float scaleIncrease = 25f;

    public void Setup() {
        gameObject.SetActive(true);
        currScore.text = gameScoreText.text.Split(' ')[1];
    }

    public void RestartButton() {
        StartCoroutine(restartWithDelay());
        
    }

    public void MainMenuButton() {
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator restartWithDelay()
    {
        yield return new WaitForSeconds(1.2f);

        SceneManager.LoadScene("Game");
        ParabolicMovement.isGameInProgress = true;
    }
}
