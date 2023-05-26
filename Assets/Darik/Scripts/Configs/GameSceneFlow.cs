using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameSceneFlow : MonoBehaviour
{
    public UnityEvent OnReady;
    public UnityEvent OnPlay;
    public UnityEvent OnGameOver;

    private void Start()
    {
        Ready();
    }

    public void Ready()
    {
        OnReady?.Invoke();
    }

    public void Play()
    {
        OnPlay?.Invoke();
    }

    public void GameOver()
    {
        OnGameOver?.Invoke();
    }
}
