using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stain : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private Sprite[] sprites;
    private float stainLifetime = 3.0f;

    private const float slowingAlphaDecrease = 5.0f;

    public void StainCreate(Vector2 stainPosition)
    {
        GameObject stain = Instantiate(prefab);
        stain.transform.position = stainPosition;
        stain.name = "stain";

        Sprite randomStainSprite = sprites[Random.Range(0, sprites.Length)];
        stain.GetComponent<SpriteRenderer>().sprite = randomStainSprite;

        StartCoroutine(destroyWithDelay(stain));
        StartCoroutine(decreaseAlpha(stain));
    }

    IEnumerator destroyWithDelay(GameObject stain)
    {
        yield return new WaitForSeconds(stainLifetime);
        Destroy(stain);
    }

    IEnumerator decreaseAlpha(GameObject stain)
    {
        SpriteRenderer stainSprite = stain.GetComponent<SpriteRenderer>();
        float alpha = 1f;
        while(alpha > 0f)
        {
            alpha -= Time.deltaTime / slowingAlphaDecrease;
            stainSprite.color = new Color(stainSprite.color.r, stainSprite.color.g, stainSprite.color.b, alpha);

            yield return 0;
        }   
    }

}
