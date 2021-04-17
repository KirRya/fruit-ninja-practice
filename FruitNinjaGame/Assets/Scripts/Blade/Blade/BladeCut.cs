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

    private Vector2 lastCursorPosition;


    private float speedCursorLimit = 0.1f;

    [SerializeField]
    public ScorePopup scorePopup;
    private Vector2 offsetScorePopup;
    private float scoreLifetime = 1.5f;

    void Start()
    {
        lastCursorPosition = Vector2.zero;
    }

    void Update()
    {
        cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (unit != null)
        {
            if ((Input.GetMouseButton(0) && (cursorPosition - (Vector2)unit.transform.position).magnitude <= sliceRadious) &&
                (cursorPosition - lastCursorPosition).magnitude > speedCursorLimit)
            {
                Stain stain = gameObject.GetComponent<Stain>();
                stain.StainCreate(cursorPosition);

                sliceCount = Random.Range(2, 6);
                unitHalf.sliceCreate(sliceCount, cursorPosition, unit);

                Destroy(unit);

                scoreView.increaseScore();

                offsetScorePopup = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));
                scorePopup.showScorePopup(cursorPosition + offsetScorePopup);

                GameObject scorePopupObject = GameObject.Find("prefabScorePopup(Clone)");

                StartCoroutine(destroyScoreDelay(scorePopupObject));
            }
        }

        lastCursorPosition = cursorPosition;
    }

    public static void InitiateUnit(GameObject _unit)
    {
        unit = _unit;
    }

    IEnumerator destroyScoreDelay(GameObject _scorePopup)
    {
        yield return new WaitForSeconds(scoreLifetime);
        Destroy(_scorePopup);
    }
}
