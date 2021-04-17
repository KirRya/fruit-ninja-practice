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

    public void Setup() {
        

        gameObject.SetActive(true);

        heartImage.sprite = heartSprites[0];

        endScale = screen.transform.localScale;
        StartCoroutine(LerpScale());
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
        heartImage.sprite = heartSprites[1];
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
