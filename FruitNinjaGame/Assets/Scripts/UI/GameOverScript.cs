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

    private Vector3 initScale;
    private Vector3 endScale;

    [SerializeField]
    private GameObject screen;


    [SerializeField]
    private SpriteRenderer heartImage;

    [SerializeField]
    private Sprite[] heartSprites;

    private int currentScoreValue;
    private int maxScoreValue;
    public void Setup() {
        
        gameObject.SetActive(true);

        heartImage.sprite = heartSprites[0];

        endScale = screen.transform.localScale;
        StartCoroutine(LerpScale());

        currScore.text = gameScoreText.text.Split(' ')[1];
        currentScoreValue = int.Parse(currScore.text);
        maxScoreValue = PlayerPrefs.GetInt("MaxScore", 0);
        
        if(currentScoreValue > maxScoreValue) {
            PlayerPrefs.SetInt("MaxScore", currentScoreValue);
        }

        maxScore.text = PlayerPrefs.GetInt("MaxScore", 0).ToString();
    }

    public void RestartButton() {
        StartCoroutine(restartWithDelay());
    }

    public void MainMenuButton() {
        StartCoroutine(mainMenuDelay());
    }

    IEnumerator restartWithDelay()
    {
        yield return new WaitForSeconds(1.2f);

        SceneManager.LoadScene("game");
        ParabolicMovement.isGameInProgress = true;
        heartImage.sprite = heartSprites[1];
    }

    IEnumerator mainMenuDelay()
    {
        yield return new WaitForSeconds(1.2f);

        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator LerpScale()
    {
        float progress = 0;

        while (progress <= 1)
        {
            screen.transform.localScale = Vector3.Lerp(Vector3.zero, endScale, progress);
            progress += Time.deltaTime * Time.timeScale;
            yield return null;
        }

        screen.transform.localScale = endScale;
    }
}
