using UnityEngine;

//Useless now, but can't delete
public class ScreenBorder
{
    private const float negativeNumber = -1f;
    private Camera mainCamera;
    private float Height { get; set; }
    private float Width { get; set; }

    public float startHeight, endHeight;
    public float startWidth, endWidth;
    private float AspectRatious { get; set; }
    private float offset = 2f;

    public ScreenBorder(Camera mainCamera) {
        Height = mainCamera.orthographicSize * 2;
        AspectRatious = mainCamera.aspect;
        Width = Mathf.Round(Height * AspectRatious);

        endHeight = (Height / 2) + offset;
        startHeight = endHeight * negativeNumber;

        endWidth = (Width / 2) + offset;
        startWidth = endWidth * negativeNumber;

        //Debug.Log($"Basic height and width - {Height}:{Width}; correct height and width {startHeight}:{endHeight}, {startWidth}:{endWidth}");
    }
}
