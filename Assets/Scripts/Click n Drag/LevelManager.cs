using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine.SocialPlatforms.Impl;

public class LevelManager : MonoBehaviour
{
    public static LevelManager control;
    public GameObject LoadingFrame;
    public GameObject[] Levels;
    public int currentLevelCounter;
    public int CurrentTempScore = Oil.CurrentScore;
    private GameObject _currentTempLevel;

    private void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ManualBackLevel();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            ForwardLevel();
        }
    }

    private void ManualBackLevel()
    {
        LoadingFrame.SetActive(true);

        if (_currentTempLevel != null)
        {
            Destroy(_currentTempLevel);
        }
        LoadingFrame.SetActive(false);
        _currentTempLevel = Instantiate(Levels[currentLevelCounter]);
        currentLevelCounter = currentLevelCounter < Levels.Length - 1 ? currentLevelCounter + 1 : 0;
        load(currentLevelCounter.ToString());
    }

    private void ForwardLevel()
    {
        LoadingFrame.SetActive(true);

        if (_currentTempLevel != null)
        {
            Destroy(_currentTempLevel);
        }
        LoadingFrame.SetActive(false);
        _currentTempLevel = Instantiate(Levels[currentLevelCounter]);
        currentLevelCounter = currentLevelCounter > 0 ? currentLevelCounter - 1 : 0;
        load(currentLevelCounter.ToString());
    }

    private void Start()
    {
        OnNextLevel();
    }

    public void OnNextLevel()
    {
        StartCoroutine(StartNextLevel());
    }

    private IEnumerator StartNextLevel()
    {
        save(currentLevelCounter.ToString());
        LoadingFrame.SetActive(true);

        if (_currentTempLevel != null)
        {
            Destroy(_currentTempLevel);
        }
        yield return new WaitForSeconds(1.0f);
        LoadingFrame.SetActive(false);
        _currentTempLevel = Instantiate(Levels[currentLevelCounter]);
        currentLevelCounter = currentLevelCounter < Levels.Length - 1 ? currentLevelCounter + 1 : 0;
        load(currentLevelCounter.ToString());
    }

    public void save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/Levelinfo.dat");
        PlayerInfo PI = new PlayerInfo();
        PI.levels = currentLevelCounter;
        PI.Score = Oil.CurrentScore;
        bf.Serialize(file, PI);
        file.Close();
    }

    public void save(string filename)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/Levelinfo" + filename + ".dat");
        PlayerInfo PI = new PlayerInfo();
        PI.levels = currentLevelCounter;
        PI.Score = Oil.CurrentScore;
        PI.HighestScorePossible();
        bf.Serialize(file, PI);
        file.Close();
    }

    public void load()
    {
        if (File.Exists(Application.persistentDataPath + "/Levelinfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/Levelinfo.dat", FileMode.Open);
            PlayerInfo PI = (PlayerInfo)bf.Deserialize(file);
            file.Close();
            currentLevelCounter = PI.levels;
            Oil.CurrentScore = PI.Score;
        }
    }

    public void load(string filename)
    {
        if (File.Exists(Application.persistentDataPath + "/Levelinfo" + filename + ".dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/Levelinfo" + filename + ".dat", FileMode.Open);
            PlayerInfo PI = (PlayerInfo)bf.Deserialize(file);
            file.Close();
            if (PI.Score <= 3)
                Oil.CurrentScore = PI.Score;
        }
    }
}

[Serializable]
internal class PlayerInfo
{
    public int levels;
    public int Score;
    public int previousScore;

    public int HighestScorePossible()
    {
        if (Score <= 3)
        {
            CurrentScoreForLevel += Score;
            Score = 0;
            return CurrentScoreForLevel;
        }
        else
        {
            return CurrentScoreForLevel;
        }
    }

    public int CurrentScoreForLevel;
    public int Totalstars;

    public int Stars()
    {
        if (CurrentScoreForLevel <= 3)
        {
            Totalstars += CurrentScoreForLevel;
            CurrentScoreForLevel = 0;
            return Totalstars;
        }
        else
        {
            Totalstars += 0;
            return Totalstars;
        }
    }
}