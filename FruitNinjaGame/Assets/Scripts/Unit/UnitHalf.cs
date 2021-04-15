using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHalf : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites;
    [SerializeField]
    private GameObject prefab;

    private Vector2 firstOffset;
    private Vector2 secondOffset;

    private float lifetime = 3.0f;
    void Start()
    {
       
    }

    void Update()
    {
        
    }

    public void UnitSlice(Vector2 startPosition, GameObject unit)
    {
        GameObject firstHalf  = Instantiate(prefab);
        GameObject secondHalf = Instantiate(prefab);

        firstHalf. name = "firstHalf";
        secondHalf.name = "secondHalf";

        firstOffset  = new Vector2(Random.Range(-1, 1), 0);
        secondOffset = new Vector2(0, Random.Range(-1, 1));

        firstHalf. transform.position = startPosition + firstOffset;
        secondHalf.transform.position = startPosition + secondOffset;

        Sprite unitSprite = getUnitSprite(unit);

        firstHalf .GetComponent<SpriteRenderer>().sprite.name = setSprite(unitSprite);
        secondHalf.GetComponent<SpriteRenderer>().sprite.name = setSprite(unitSprite);
    }

    private Sprite getUnitSprite(GameObject unit)
    {
        return unit.GetComponent<SpriteRenderer>().sprite;
    }

    private string setSprite(Sprite unitSprite)
    {
        return unitSprite.name + "Arm";
    }

    private Sprite findSprite(Sprite unitSprite, string spriteName)
    {
        foreach(Sprite item in sprites)
        {
            if (item.name == spriteName)
                return item;
        }
        return null;
    }
}
