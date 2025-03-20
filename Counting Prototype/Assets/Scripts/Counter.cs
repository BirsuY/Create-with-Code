using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text CounterText;
    public string teamName;
    private int Count = 0;
    public SceneManagement sceneManager;
    public void Start(){
        Count = 0;
        //CounterText.text = teamName + ": " + Count;

        //StartGame(Count);
    }
    private void StartGame(int count)
    {
        Count = count;

        
    }

    private void OnTriggerEnter(Collider other)
    {
        Count += 1;
        //PlayerPrefs.SetInt(teamName + "Count", Count);
        CounterText.text = teamName + ": " + Count;
        sceneManager.RestartGame();
    }
}
