using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class Movie_Opening : MonoBehaviour
{
    public VideoPlayer vp;

    public Canvas MainMenuCanvas;
    public Canvas FadeCanvas;
    public Animator FadeAnimator;

    private void Awake()
    {
        FadeAnimator.StopPlayback();
        FadeCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (vp.isPlaying)
        {
            if (MainMenuCanvas.gameObject.activeInHierarchy)
            {
                MainMenuCanvas.gameObject.SetActive(false);
            }
        }

        if (!vp.isPlaying)
        {
            if (!FadeCanvas.gameObject.activeInHierarchy)
            {
                FadeCanvas.gameObject.SetActive(true);
                FadeAnimator.StartPlayback();
                FadeAnimator.Play("Fading");
            }

            if (!MainMenuCanvas.gameObject.activeInHierarchy)
            {
                DelayedActivation();
            }
        }
    }

    private void DelayedActivation()
    {
        StartCoroutine(DelayedActivationCoroutine());
    }

    private IEnumerator DelayedActivationCoroutine()
    {
        //FadeAnimator.StartPlayback();
        yield return new WaitForSecondsRealtime(1);
        MainMenuCanvas.gameObject.SetActive(true);
    }
}