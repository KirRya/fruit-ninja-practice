using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject foodObject;

    public float interval;

    public Sprite[] sprites;


    public Vector2 startPosition;
    public Vector2 endPosition;
    public float step;
    private float progress;



    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPosition;
        InvokeRepeating("Spawn", interval, interval);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spawn()
    {
        GameObject food = Instantiate(foodObject);

        transform.position = Vector2.Lerp(startPosition, endPosition, progress);
        progress += step;

        Sprite randomFoodSprite = sprites[Random.Range(0, sprites.Length)];
        food.GetComponent<SpriteRenderer>().sprite = randomFoodSprite;

    }
}
