using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HearthsSystem : MonoBehaviour
{
    [SerializeField]
    public Text hearthsCountText;
    private int hearths;
    private string format = "{0}";

    [SerializeField]
    private int currentHearthsConfig;

    public int Hearths
    {
        get { return hearths; }
        set {
            hearths = value;
            hearthsCountText.text = string.Format(format, value);
        }
    }

    void Start()
    {
        Hearths = currentHearthsConfig;
    }

    public void decreaseHearth()
    {
        Hearths -= 1;
    }

    public void increaseHearth()
    {
        Hearths += 1;
    }
}
