using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject current;
    public GameObject Goal;
    public GameObject WinScreen;

    // Use this for initialization
    void Start()
    {
        if (Goal == null)
            Goal = GameObject.FindGameObjectWithTag("Goal");

    }

    // Update is called once per frame
    void Update()
    {
        if (current.transform == Goal.transform ||
            Mathf.Abs(current.transform.position.x - Goal.transform.position.x) < 0.5f &&
            Mathf.Abs(current.transform.position.y - Goal.transform.position.y) < 0.5f)
        {
            WinnerChickenDinner();
        }
    }

    void WinnerChickenDinner()
    {
        if (!WinScreen.activeSelf)
        {
            WinScreen.SetActive(true);
        }
        
    }
}