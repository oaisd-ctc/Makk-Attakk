using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSessionRemover : MonoBehaviour
{
    GameSession gameSession;

    void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;

        int numgmrRemover = FindObjectsOfType<GameSessionRemover>().Length;
        gameSession = FindObjectOfType<GameSession>();
        if (numGameSessions > 1)
        {
            Destroy(gameSession);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        int numgmrRemover = FindObjectsOfType<GameSessionRemover>().Length;
        if (numgmrRemover == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
