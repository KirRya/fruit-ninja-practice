﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusMovement : MonoBehaviour
{
    private Vector3 Acceleration { get; set; }
    private float g = 9.81f;

    private const float scaleIncrease = 0.2f;
    private float rotationSpeed;

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

    private void moveBonus()
    {
        transform.position = transform.position + Acceleration * Time.deltaTime;
        Acceleration += Vector3.down * g * Time.deltaTime;
    }

    private void rotateBonus()
    {
        rotationSpeed = Random.Range(0, 5);
        transform.Rotate(Vector3.back, rotationSpeed);
    }

    void Update()
    {
        moveBonus();
        rotateBonus();
    }
}
