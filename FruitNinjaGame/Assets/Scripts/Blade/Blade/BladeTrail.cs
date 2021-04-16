using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeTrail : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    void Update()
    {
        Vector2 cursorPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            transform.position = cursorPosition;
        }
    }
}
