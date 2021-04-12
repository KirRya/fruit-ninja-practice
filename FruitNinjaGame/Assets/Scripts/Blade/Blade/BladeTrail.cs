using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeTrail : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Debug.Log(cursorPosition);
        //Debug.Log(Screen.height + " " + Screen.width);

        if (Input.GetMouseButton(0))
        {
            transform.position = cursorPosition;
        }
    }
}
