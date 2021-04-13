using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("Prefab config")]
    public GameObject prefab;
    public float interval;
    public Sprite[] sprites;

    private ScreenBorder border;
    public Camera mainCamera;

    [Header("Spawn config")]
    private float spawnInterval = 2;
    private int amountUnits = 1;

    void Start()
    {
        transform.position = new Vector2(
            Random.Range(DefineScreenBorder.startWidth, DefineScreenBorder.endWidth),
            DefineScreenBorder.startHeight);

        //InvokeRepeating("Spawn", interval, interval);

        InvokeRepeating("SpawnUnitsPack", spawnInterval, spawnInterval);
        
    }

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
    }


    //Without delay already 
    public void SpawnUnitsPack()
    {
        for (int i = 0; i < amountUnits; i++)
        {
            GameObject unit = Instantiate(prefab);
            unit.name = "unit";

            Sprite randomFoodSprite = sprites[Random.Range(0, sprites.Length)];
            unit.GetComponent<SpriteRenderer>().sprite = randomFoodSprite;

            BladeCut.InitiateUnit(unit);
        }
    }

}
