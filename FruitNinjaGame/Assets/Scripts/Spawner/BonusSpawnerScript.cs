using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawnerScript : MonoBehaviour
{
    [SerializeField]
    public GameObject prefab;

    [SerializeField]
    private Sprite[] sprites;

    private float spawnInterval = 3f;
    void Start()
    {
        InvokeRepeating("Spawn", spawnInterval, spawnInterval);
    }

    void Update()
    {
        
    }

    public void Spawn()
    {
        GameObject bonus = Instantiate(prefab);
        
        switch(Random.Range(0, 2))
        {
            case 0:
                {
                    bonus.name = "bomb";
                    bonus.GetComponent<SpriteRenderer>().sprite = sprites[0];

                    BladeCut.InitBonus(bonus, 0);
                    break;
                }
            case 1:
                {
                    bonus.name = "hearth";
                    bonus.GetComponent<SpriteRenderer>().sprite = sprites[1];

                    BladeCut.InitBonus(bonus, 1);
                    break;
                }
        }   
    }
}
