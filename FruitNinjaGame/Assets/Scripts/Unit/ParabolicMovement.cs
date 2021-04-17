using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicMovement : MonoBehaviour
{
    private Vector3 Acceleration { get; set; }
    private float g = 9.81f;

    private const float scaleIncrease = 0.2f;
    private float rotationSpeed;

    [SerializeField]
    public static bool isGameInProgress = true;

    void Start()
    {
        Vector2 startVector = new Vector2(
            Random.Range(DefineScreenBorder.GameZone.startWidth, DefineScreenBorder.GameZone.endWidth), 
            DefineScreenBorder.GameZone.startHeight);

        Vector2 initialAcceleration = new Vector2();

        if (startVector.x >= 0)
            initialAcceleration = new Vector2(Random.Range(DefineScreenBorder.GameZone.startWidth, 0), DefineScreenBorder.GameZone.endHeight);
        else
            initialAcceleration = new Vector2(Random.Range(0, DefineScreenBorder.GameZone.endWidth), DefineScreenBorder.GameZone.endHeight);

        Acceleration = (Vector2.up * Random.Range(2, DefineScreenBorder.GameZone.endHeight)) + initialAcceleration;
        transform.position = startVector;
    }


    void Update() {
        moveUnit();
        rotateUnit();
        scaleUnit();

        if(outOfZone()) {
            GameObject unit = GameObject.Find("unit");
            Destroy(unit);

            HearthsSystem hearths = GameObject.Find("GameController").GetComponent<HearthsSystem>();
            hearths.decreaseHearth();

            if (hearths.isLose()) {
                isGameInProgress = false;
            }
        }
    }

    private void moveUnit()
    {
        transform.position = transform.position + Acceleration * Time.deltaTime;
        Acceleration += Vector3.down * g * Time.deltaTime;
    }

    private void rotateUnit()
    {
        rotationSpeed = Random.Range(0, 5);
        transform.Rotate(Vector3.back, rotationSpeed);
    }

    private void scaleUnit()
    {
        transform.localScale += new Vector3(scaleIncrease, scaleIncrease, scaleIncrease) * Time.deltaTime;
    }

    private bool outOfZone()
    {
        return !DefineScreenBorder.GameZone.zone.Contains(transform.position);
    }
}
