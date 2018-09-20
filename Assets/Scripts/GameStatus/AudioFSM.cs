using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AudioFSM : MonoBehaviour
{
    public AudioSource _audioSource;
    private static AudioFSM _audioFsm;

    //Singleton For AudioFsm to be an audio manager
    public static AudioFSM AudioFsm
    {
        get
        {
            if (_audioFsm) return _audioFsm;
            _audioFsm = GameObject.FindObjectOfType<AudioFSM>();
            if (_audioFsm) return _audioFsm;
            var container = new GameObject("FX");
            container.AddComponent<AudioSource>();
            _audioFsm = container.AddComponent<AudioFSM>();
            return _audioFsm;
        }
    }

    public AudioClip BonkAudioClip;

    public AudioClip AreYouSureAudioClip;

    public AudioClip CantPlaceArrowAudioClip;

    public AudioClip ConfirmAudioClip;

    public AudioClip Go;

    public AudioClip PickingUpArrowAudioClip;

    public AudioClip ResetAudioClip;

    public AudioClip AltResetAudioClip;

    public AudioClip RhoombaAudioClip;

    public AudioClip CantGrabThatAudioClip;

    public void PlaySound(AudioClip currentAudioClip)
    {
        _audioSource.Stop();
        _audioSource.clip = currentAudioClip;

        _audioSource.Play();
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _audioSource.clip = AreYouSureAudioClip;
            _audioSource.Play();
        }
    }
}