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

    private ScreenBorder border;
    public Camera mainCamera;


    // Start is called before the first frame update
    void Start()
    {
        //Изменяю это
        //transform.position = startPosition;

        transform.position = new Vector2(
            Random.Range(DefineScreenBorder.startWidth, DefineScreenBorder.endWidth),
            DefineScreenBorder.startHeight);

        InvokeRepeating("Spawn", interval, interval);
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Spawn()
    {
        //Basic movement
        GameObject unit = Instantiate(prefab);
        unit.name = "unit";

        //Sprite generating
        Sprite randomFoodSprite = sprites[Random.Range(0, sprites.Length)];
        unit.GetComponent<SpriteRenderer>().sprite = randomFoodSprite;

        //Despawning per lifetime
        //Изменяю
        //Destroy(unit, lifetime);

        //InvokeRepeating("CheckForDestroy(unit)", interval, interval);

    }

    //public void checkForDestroy(GameObject _unit)
    //{
    //    if (true)
    //        Destroy(_unit);
    //    if (endPosition.x >= new Vector2(border.endWidth, border.endHeight).x || endPosition.y >= new Vector2(border.endWidth, border.endHeight).y)
    //        Destroy(_unit);
    //}


}
