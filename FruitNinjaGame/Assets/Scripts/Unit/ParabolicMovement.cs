using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicMovement : MonoBehaviour
{
    private Vector3 Acceleration { get; set; }
    private float g = 9.81f;

    private const float scaleIncrease = 0.2f;
    private float rotationSpeed;

    void Start()
    {
        Vector2 startVector = new Vector2(
            Random.Range(DefineScreenBorder.startWidth, DefineScreenBorder.endWidth), 
            DefineScreenBorder.startHeight);

        Vector2 initialAcceleration = new Vector2();

        if (startVector.x >= 0)
            initialAcceleration = new Vector2(Random.Range(DefineScreenBorder.startWidth, 0), DefineScreenBorder.endHeight);
        else
            initialAcceleration = new Vector2(Random.Range(0, DefineScreenBorder.endWidth), DefineScreenBorder.endHeight);

        Acceleration = (Vector2.up * Random.Range(2, DefineScreenBorder.endHeight)) + initialAcceleration;
        transform.position = startVector;
    }


    void Update() {

        moveUnit();
        rotateUnit();
        scaleUnit();

        if(isUnitCut()) {
            GameObject unit = GameObject.Find("unit");
            Destroy(unit);
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

    private bool isUnitCut()
    {
        if (transform.position.x >= DefineScreenBorder.endWidth ||
           transform.position.x <= DefineScreenBorder.startWidth ||
           transform.position.y >= DefineScreenBorder.endHeight ||
           transform.position.y <= DefineScreenBorder.startHeight) {
            return true;
        }
        else {
            return false;
        }
    }
}
