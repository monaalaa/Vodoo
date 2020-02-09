using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [HideInInspector]
    bool gameStarted = false;
    public static Action AGameStarted;

    public bool GameStarted { get => gameStarted;
        set 
        {
            gameStarted = value;
            if (AGameStarted != null)
                AGameStarted.Invoke();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
            Instance = this;
    }
}
