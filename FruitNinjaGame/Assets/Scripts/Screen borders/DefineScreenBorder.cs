using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class DefineScreenBorder : MonoBehaviour
{
    private const float negativeNumber = -1f;
    private Camera mainCamera;
    private float Height { get; set; }
    private float Width { get; set; }

    [Header("Y")]
    public static float startHeight, endHeight;
    [Header("X")]
    public static float startWidth, endWidth;
    private float AspectRatious { get; set; }
    private float offset = 2f;


    void Start()
    {
        mainCamera = GetComponent<Camera>();
        ScreenBorder border = new ScreenBorder(mainCamera);

        Height = mainCamera.orthographicSize * 2;
        AspectRatious = mainCamera.aspect;
        Width = Mathf.Round(Height * AspectRatious);

        endHeight = (Height / 2) + offset;
        startHeight = endHeight * negativeNumber;

        endWidth = (Width / 2) + offset;
        startWidth = endWidth * negativeNumber;

        //Debug.Log($"correct height and width {border.startHeight}:{border.endHeight}, {border.startWidth}:{border.endWidth}");
    }
}
