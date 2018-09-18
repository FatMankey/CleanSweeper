using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Audio_Player : MonoBehaviour
{
    public AudioSource AudioS;

    private VideoPlayer VideoP;

    private bool _isStillPlaying = false;

    // Use this for initialization
    private void Start()
    {
        AudioS = GetComponent<AudioSource>();
        VideoP = GameObject.FindGameObjectWithTag("Video").GetComponent<VideoPlayer>();
        if (VideoP.playOnAwake)
        {
            _isStillPlaying = true;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        _isStillPlaying = VideoP.isPlaying;
        if (!_isStillPlaying && !AudioS.isPlaying)
        {
            AudioS.Play();
        }
    }
}