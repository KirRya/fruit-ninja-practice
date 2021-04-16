using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BladeCut : MonoBehaviour
{
    private static GameObject unit;
    private float sliceRadious = 1.0f;
    private Vector2 cursorPosition;

    [SerializeField]
    public ScoreView scoreView;

    private int sliceCount;

    [SerializeField]
    public UnitHalf unitHalf;

    [SerializeField]
    public HearthsSystem hearthsSystem;

    void Update()
    {
        cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0) && (cursorPosition - (Vector2)unit.transform.position).magnitude <= sliceRadious)
        {
            Stain stain = gameObject.GetComponent<Stain>();
            stain.StainCreate(cursorPosition);

            sliceCount = Random.Range(2, 6);
            unitHalf.sliceCreate(sliceCount, cursorPosition, unit);

            Destroy(unit);

            scoreView.increaseScore();
        }
    }

    public static void InitiateUnit(GameObject _unit)
    {
        unit = _unit;
    }


}
