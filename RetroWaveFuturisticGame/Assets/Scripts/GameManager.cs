using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager gameManager;
    private Fader fader;

    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    void Start()
    {
        
    }

    public static void RegisterFader (Fader registerFader)
    {
        if (gameManager == null)
            return;

        gameManager.fader = registerFader;
    }

    public static void ManagerLoadLevel(int index)
    {
        if (gameManager == null)
            return;

        gameManager.fader.SetLevel(index);
    }

    public static void ManagerRestartLevel()
    {
        if (gameManager == null)
            return;

        gameManager.fader.RestartLevel();
    }
}
