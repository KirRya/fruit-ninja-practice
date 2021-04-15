using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHalfMovement : MonoBehaviour
{
    private Vector3 Acceleration { get; set; }
    private float g = 9.81f;

    private const float scaleIncrease = 0.2f;
    private float rotationSpeed;

    void Start()
    {
        Vector2 startVector = new Vector2(Random.Range(0, 5), Random.Range(0, 5));

        Vector2 initialAcceleration = new Vector2();

            initialAcceleration = new Vector2(Random.Range(DefineScreenBorder.GameZone.startWidth, DefineScreenBorder.GameZone.endWidth), DefineScreenBorder.GameZone.endHeight);

        Acceleration = (Vector2.down * Random.Range(2, DefineScreenBorder.GameZone.endHeight)) + initialAcceleration;
    }

    void Update()
    {
        moveUnit();
        rotateUnit();
    }

    private void moveUnit()
    {
        transform.position = transform.position + Acceleration * Time.deltaTime;
        Acceleration += Vector3.down * g * Time.deltaTime;
    }

    private void rotateUnit()
    {
        rotationSpeed = Random.Range(0, 5);
        transform.Rotate(Vector3.forward, rotationSpeed);
    }

}
