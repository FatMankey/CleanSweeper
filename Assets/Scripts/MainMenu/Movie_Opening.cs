using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Movie_Opening : MonoBehaviour
{
    public VideoPlayer vp;

    public Canvas MainMenuCanvas;

    // Use this for initialization
    private void Start()
    {
        vp = GetComponent<VideoPlayer>();
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
        if (!vp.isPlaying && !MainMenuCanvas.gameObject.activeInHierarchy)
        {
            MainMenuCanvas.gameObject.SetActive(true);
            vp.gameObject.SetActive(false);
        }
    }
}