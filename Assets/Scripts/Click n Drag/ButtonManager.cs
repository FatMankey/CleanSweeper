using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GonzoMovement[] gonzoMovement;
    public GameObject[] OilsGameObject;

    [System.Serializable]
    public class CustomArrows
    {
        public string name = "";
        public Arrow arrow;
        public int numberOfArrows = 0;
    }

    public CustomArrows[] Arrows;
    public GameObject GoButton;
    public GameObject ResetButton;
    public GameObject WinnerBanner;

    private LevelManager lMan;
    private int roombaCounter = 0;
    private bool isGo = false;

    private void OnEnable()
    {
        lMan = FindObjectOfType<LevelManager>();
        roombaCounter = 0;
        isGo = false;
        for (int i = 0; i < 4; i++)
        {
            Arrows[i].arrow.OnInit(Arrows[i].numberOfArrows);
        }
        for (int i = 0; i < gonzoMovement.Length; i++)
        {
            gonzoMovement[i].OnInit();
        }

        OilsGameObject = GameObject.FindGameObjectsWithTag("Oil");
    }

    public void OnGoButton()
    {
        if (isGo)
            return;
        isGo = true;
        for (int i = 0; i < Arrows.Length; i++)
        {
            Arrows[i].arrow.hasStarted = true;
        }
        for (int i = 0; i < gonzoMovement.Length; i++)
        {
            gonzoMovement[i].OnStart();
        }
        AudioFSM.AudioFsm.PlaySound(AudioFSM.AudioFsm.Go);
    }

    public void OnResetButton()
    {
        for (int i = 0; i < Arrows.Length; i++)
        {
            Arrows[i].arrow.Reset();
        }

        for (int i = 0; i < gonzoMovement.Length; i++)
        {
            gonzoMovement[i].Reset();
        }

        if (OilsGameObject != null || OilsGameObject.Length != 0)
        {
            foreach (var go in OilsGameObject)
            {
                go.SetActive(true);
            }
        }

        roombaCounter = 0;
        isGo = false;
        AudioFSM.AudioFsm.PlaySound(AudioFSM.AudioFsm.ResetAudioClip);
    }

    public void OnEnterGoal()
    {
        roombaCounter++;
        if (roombaCounter >= gonzoMovement.Length)
        {
            StartCoroutine(StartGameWon());
        }
    }

    private IEnumerator StartGameWon()
    {
        WinnerBanner.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        WinnerBanner.SetActive(false);
        lMan.OnNextLevel();
    }
}