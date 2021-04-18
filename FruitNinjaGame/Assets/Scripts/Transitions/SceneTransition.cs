using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField]
    public Animator animator;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FadeToLevel();
        }
    }

    public void FadeToLevel()
    {
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene("game");
    }


    IEnumerator delay()
    {
        yield return new WaitForSeconds(2);
        FadeToLevel();
    }
}
