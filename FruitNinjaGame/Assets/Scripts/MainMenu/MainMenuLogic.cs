using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuLogic : MonoBehaviour
{
    [SerializeField]
    private GameObject unit;

    [SerializeField]
    private SpriteRenderer unitSprite;

    [SerializeField]
    private Text maxScore;

    [SerializeField]
    private Sprite[] sprites;

    public bool isGameOn = false;

    private int rotationSpeed;

    private Vector3 startScale;
    private Vector3 endScale;
    private const float scaleValue = 2.0f;
    void Start()
    {
        startScale = unit.transform.localScale;
        endScale = Vector3.zero;

        isGameOn = false;

        maxScore.text = PlayerPrefs.GetInt("MaxScore", 0).ToString();
    }

    void FixedUpdate()
    {
        if (isGameOn)
        {
            unitRotate();
        }
    }

    public void btnPlay_Click()
    {
        unitChangeSprite();
        isGameOn = true;
        StartCoroutine(LerpScale());
        ParabolicMovement.isGameInProgress = true;
    }

    private void unitRotate()
    {
        rotationSpeed = Random.Range(5, 11);
        unit.transform.Rotate(Vector3.forward, rotationSpeed);
    }

    private void unitChangeSprite()
    {
        unitSprite.sprite = sprites[1];
    }

    IEnumerator LerpScale()
    {
        float scaleProgress = 0;

        while (scaleProgress <= 1)
        {
            unit.transform.localScale = Vector3.Lerp(startScale, endScale, scaleProgress);
            scaleProgress += Time.deltaTime / scaleValue;
            yield return null;
        }

        unit.transform.localScale = endScale;
    }
}
