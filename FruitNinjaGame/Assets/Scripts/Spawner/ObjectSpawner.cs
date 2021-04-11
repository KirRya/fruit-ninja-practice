using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("Prefab config")]
    public GameObject prefab;
    public float interval;
    public Sprite[] sprites;
    private float progress;
    public float lifetime;

    [Header("Movement config")]
    public Vector2 startPosition;
    public Vector2 endPosition;
    public float step;
    



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
        //Basic movement
        GameObject unit = Instantiate(prefab);

        transform.position = Vector2.Lerp(startPosition, endPosition, progress);
        progress += step;

        //Sprite generating
        Sprite randomFoodSprite = sprites[Random.Range(0, sprites.Length)];
        unit.GetComponent<SpriteRenderer>().sprite = randomFoodSprite;

        //Despawning per lifetime
        Destroy(unit, lifetime);
    }


}
