using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    [SerializeField]
    public int currentHealth;
    [SerializeField]
    private int hearthsAmount;

    [SerializeField]
    private Image[] hearths;
    [SerializeField]
    private Sprite fullHearth;
    [SerializeField]
    private Sprite emptyHearth;

    void Start() {
        configHearths();
    }

    void Update()
    {

    }

    private void configHearthsView(int iterator) {
        if(iterator < currentHealth) {
            hearths[iterator].sprite = fullHearth;
        }
        else {
            hearths[iterator].sprite = emptyHearth;
        }
    }

    private void checkExsess(int iterator) {
        if(iterator < hearthsAmount) {
            hearths[iterator].enabled = true;
        }
        else {
            hearths[iterator].enabled = false;
        }
    }

    private void configHearths()
    {
        for (int i = 0; i < hearths.Length; i++)
        {
            configHearthsView(i);
            checkExsess(i);
            Debug.Log("Check");
        }
    }


    public void decreaseHealth()
    {
        currentHealth -= 1;
    }
}
