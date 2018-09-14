using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    private Texture2D tex;
    private bool isStillFading = true;
    public int ReduceAlpha = 2;
    public CanvasGroup canvasGroup;

    // Use this for initialization
    public void fade_in()
    {
        StartCoroutine(unFade());
    }

    private IEnumerator unFade()
    {
        while (canvasGroup.alpha <= 100)
        {
            canvasGroup.alpha += Time.deltaTime / ReduceAlpha;
            yield return null;
        }

        canvasGroup.interactable = false;
        yield return null;
    }

    private void Start()
    {
        //canvasGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (this.gameObject.activeInHierarchy && isStillFading)
        {
            fade_in();
            isStillFading = false;

            this.gameObject.SetActive(false);
        }
    }
}