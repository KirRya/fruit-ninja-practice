using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("Prefab config")]
    [SerializeField]
    public GameObject prefab;
    [SerializeField]
    private Sprite[] sprites;

    [SerializeField]
    private Camera mainCamera;

    [Header("Spawn config")]
    private float spawnInterval = 3;
    private int amountUnits = 1;

    [SerializeField]
    public GameOverScript gameOverScript;

    void Start()
    {
        transform.position = new Vector2(
            Random.Range(DefineScreenBorder.GameZone.startWidth, DefineScreenBorder.GameZone.endWidth),
            DefineScreenBorder.GameZone.startHeight);

        
        InvokeRepeating("SpawnUnitsPack", spawnInterval, spawnInterval);
    }

    public void GameOver()
    {
        gameOverScript.Setup();
    }

    public void SpawnUnitsPack()
    {
        if(!ParabolicMovement.isGameInProgress)
        {
            CancelInvoke();

            GameOver();
        }
        else
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
}
