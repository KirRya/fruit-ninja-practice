using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UnitHalf : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites;
    [SerializeField]
    private GameObject prefab;

    private Vector2 firstOffset;
    private Vector2 secondOffset;

    private float lifetime = 3.0f;

    [SerializeField]
    private GameObject effect;

    private Vector2 offset;

    public void sliceCreate(int countSlices, Vector2 startPosition, GameObject unit)
    {
        for (int i = 0; i < countSlices; i++)
        {
            GameObject slice = Instantiate(prefab);
            offset = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));

            slice.transform.position = startPosition + offset;

            Sprite sliceSprite = getUnitSprite(unit);

            slice.GetComponent<SpriteRenderer>().sprite = findSprite(getSpriteName(sliceSprite));

            StartCoroutine(delayDestroy(slice));
        }

        effect.transform.position = startPosition;
        Instantiate(effect);
    }

    private Sprite getUnitSprite(GameObject unit)
    {
        return unit.GetComponent<SpriteRenderer>().sprite;
    }

    private string getSpriteName(Sprite unitSprite)
    {
        return unitSprite.name + "Slice";
    }

    private Sprite findSprite(string spriteName)
    {
        foreach(Sprite item in sprites)
        {
            if (item.name == spriteName)
                return item;
        }
        return null;
    }

    IEnumerator delayDestroy(GameObject slice)
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(slice);
    }
}
