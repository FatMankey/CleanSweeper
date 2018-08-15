using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {
    public delegate void Win(bool enable);
    public static event Win WinningStatement;
    public delegate void GameOver(bool enable);
    public static event GameOver LosingStatement;
    private static GameState _instance;
    public static GameState Instance
    {
        get
        {
            if(_instance != null) return _instance;
            var go = new GameObject("GameState");
            go.AddComponent<GameState>();
            return _instance;
        }
    }

}
