using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameIsEnded;
    public GameObject gameOverUI;
    private void Start()
    {
        gameIsEnded = false;
    }
    void Update()
    {
        if (gameIsEnded == true)
        {
            return;
        }

        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }

        if (PlayerStats.Lives<=0)
        {
            EndGame();
        }


    }

    void EndGame()
    {
        gameIsEnded = true;
        gameOverUI.SetActive(true);
        Debug.Log("Game Over");
    }
}
