using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BladeCut : MonoBehaviour
{
    private static GameObject unit;
    private float sliceRadious = 1.0f;

    void Start()
    {
        
    }

    void Update()
    {
        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log($"cursor - {cursorPosition}; unit - {unit.transform.position}; minus - {(cursorPosition - (Vector2)unit.transform.position).magnitude}");

        if (Input.GetMouseButton(0) && (cursorPosition - (Vector2)unit.transform.position).magnitude <= sliceRadious)
        {
            Destroy(unit);
        }
    }


    public static void InitiateUnit(GameObject _unit)
    {
        unit = _unit;
    }


}
