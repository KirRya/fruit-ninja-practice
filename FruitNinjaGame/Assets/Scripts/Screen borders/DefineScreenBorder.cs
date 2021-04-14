using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class DefineScreenBorder : MonoBehaviour
{
    [SerializeField]
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
        Height = mainCamera.orthographicSize * 2;
        AspectRatious = mainCamera.aspect;
        Width = Mathf.Round(Height * AspectRatious);

        endHeight = (Height / 2) + offset;
        startHeight = endHeight * -1.0f;

        endWidth = (Width / 2) + offset;
        startWidth = endWidth * -1.0f;
    }
}
