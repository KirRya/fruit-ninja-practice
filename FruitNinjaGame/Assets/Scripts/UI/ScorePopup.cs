using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class ScorePopup : MonoBehaviour
{
    [SerializeField]
    private Transform scorePopup;

    private float lifetimeScorePopup = 0.5f;

    private Transform score;

    private float scaleIncrease = 1f;
    private float scoreSpeed = 0.03f;
    public void showScorePopup(Vector2 position)
    {
        score = Instantiate(scorePopup, position, Quaternion.identity);
    }

    void Update()
    {
        if (score != null)
        {
            scoreMoveUp();
            scoreScaling();
        }
    }

    private void scoreMoveUp()
    {
        score.transform.position += new Vector3(0, scoreSpeed, 0);
        scoreScaling();
    }

    private void scoreScaling()
    {
        score.transform.localScale += new Vector3(scaleIncrease, scaleIncrease, scaleIncrease) * Time.deltaTime;
    }


}
