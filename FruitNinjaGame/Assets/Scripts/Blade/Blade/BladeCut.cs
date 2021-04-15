using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BladeCut : MonoBehaviour
{
    private static GameObject unit;
    private float sliceRadious = 1.0f;
    private Vector2 cursorPosition;

    void Start()
    {
        
    }

    void Update()
    {
        cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0) && (cursorPosition - (Vector2)unit.transform.position).magnitude <= sliceRadious)
        {
            Stain stain = gameObject.GetComponent<Stain>();
            stain.StainCreate(cursorPosition);

            UnitHalf unitHalf = gameObject.GetComponent<UnitHalf>();
            unitHalf.UnitSlice(cursorPosition, unit);

            Destroy(unit);

            GameObject.Find("score").GetComponent<ScoreView>().Score += 1;
        }
    }


    public static void InitiateUnit(GameObject _unit)
    {
        unit = _unit;
    }


}
