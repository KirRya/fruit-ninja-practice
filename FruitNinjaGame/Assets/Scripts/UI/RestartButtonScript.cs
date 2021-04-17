using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButtonScript : MonoBehaviour
{
    private Vector3 initScale;
    [SerializeField]
    private Vector3 endScale;

    public void ButtonScale()
    {
        initScale = transform.localScale;
        StartCoroutine(LerpScale());
    }

    IEnumerator LerpScale()
    {
        float progress = 0;

        while(progress <= 1)
        {
            transform.localScale = Vector3.Lerp(initScale, endScale, progress);
            progress += Time.deltaTime * Time.timeScale;
            yield return null;
        }

        transform.localScale = endScale;
    }
}
