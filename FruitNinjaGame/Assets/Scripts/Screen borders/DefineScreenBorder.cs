using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefineScreenBorder : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;
    private static float Height { get; set; }
    private static float Width { get; set; }

    private float AspectRatious { get; set; }
    private static float offset = 2f;

    void Start()
    {
        Height = mainCamera.orthographicSize * 2;
        AspectRatious = mainCamera.aspect;
        Width = Mathf.Round(Height * AspectRatious);
        GameZone.Initialize();
    }

    public static class GameZone
    {
        public static Rect zone;
        public static float startHeight, endHeight, startWidth, endWidth;

        public static void Initialize()
        {
            endHeight = (Height / 2) + offset;
            startHeight = endHeight * -1.0f;

            endWidth = (Width / 2) + offset;
            startWidth = endWidth * -1.0f;

            zone = new Rect(startWidth, startHeight, endWidth * 2, endHeight * 2);
        }
    }

}
