using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager gameManager;
    private Fader fader;
    private Door theDoor;
    private List<Money> moneys;

    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

        moneys = new List<Money>();
    }

    public static void RegisterDoor(Door door)
    {
        if (gameManager == null)
            return;

        gameManager.theDoor = door;
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

        gameManager.moneys.Clear();
        gameManager.fader.RestartLevel();
    }

    public static void RegisterMoney(Money money)
    {
        if (gameManager == null)
            return;

        if (!gameManager.moneys.Contains(money))
            gameManager.moneys.Add(money);
    }

    public static void RemoveMoneyFromList(Money money)
    {
        if (gameManager == null)
            return;

        gameManager.moneys.Remove(money);
        if (gameManager.moneys.Count == 0)
            gameManager.theDoor.UnlockDoor();
    }

}
