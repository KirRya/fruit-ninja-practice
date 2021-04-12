using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefineScreenBorder : MonoBehaviour
{
    private const float negativeNumber = -1f;
    private Camera mainCamera;
    public float Height { get; private set; }
    public float Width { get; private set; }

    [Header("Y")]
    public float startHeight, endHeight;
    [Header("X")]
    public float startWidth, endWidth;
    private float AspectRatious { get; set; }
    private float offset = 2f;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GetComponent<Camera>();
        ScreenBorder border = new ScreenBorder(mainCamera);
        Debug.Log($"correct height and width {border.startHeight}:{border.endHeight}, {border.startWidth}:{border.endWidth}");
    }
}
