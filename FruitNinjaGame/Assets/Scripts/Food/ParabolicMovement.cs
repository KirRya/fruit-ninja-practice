using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicMovement : MonoBehaviour
{
    private Vector2 Acceleration { get; set; }
    private float g = 9.81f;

    void Start()
    {
        //Vector2 startVector = new Vector2(Random.Range(-11, 11), -7);

        //Acceleration = startVector;

        Vector2 startVector = new Vector2(
            Random.Range(DefineScreenBorder.startWidth, DefineScreenBorder.endWidth), 
            DefineScreenBorder.startHeight);

        Vector2 initialAcceleration = new Vector2(); // =  new Vector2(Random.Range(DefineScreenBorder.startWidth / 2, DefineScreenBorder.endWidth / 2), DefineScreenBorder.endHeight);


        if (startVector.x >= 0)
            initialAcceleration = new Vector2(Random.Range(DefineScreenBorder.startWidth, 0), DefineScreenBorder.endHeight);
        else
            initialAcceleration = new Vector2(Random.Range(0, DefineScreenBorder.endWidth), DefineScreenBorder.endHeight);

        Acceleration = (Vector2.up * Random.Range(2, DefineScreenBorder.endHeight)) + initialAcceleration;
        transform.position = startVector;

        Debug.Log($"startVector - {startVector.ToString()}; Acceleration - {Acceleration.ToString()} ");
    }



    void Update() {
        //Убрал проверку

            transform.position = transform.position + (Vector3)Acceleration * Time.deltaTime;
            Acceleration += Vector2.down * g * Time.deltaTime;

            if(transform.position.x >= DefineScreenBorder.endWidth || 
               transform.position.x <= DefineScreenBorder.startWidth ||
               transform.position.y >= DefineScreenBorder.endHeight ||
               transform.position.y <= DefineScreenBorder.startHeight) {
                //Need to be destroyed;

                //Временное решение, могу удалять только если на поле находится один фрукт
                //GameObject unit = GameObject.Find("unit");
                //Destroy(unit);
                
            }
        

    }
}
