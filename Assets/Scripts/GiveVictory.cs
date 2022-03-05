using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GiveVictory : MonoBehaviour
{
    public GameObject VictoryScript;
    public GameObject HomeButton;
    public GameObject NextLevelButton;

    public static bool isPlayed;

    private static LevelsReq[] levels = {
        new LevelsReq("level_one", 30)
    };

    private string currentLevel;
    public static int levelsPoints;

    public void Awake()
    {
        isPlayed = false;

        currentLevel = SceneManager.GetActiveScene().name;
        for (int x = 0; x < levels.Length; x++)
        {
            if (currentLevel == levels[x].Name)
            {
                levelsPoints = levels[x].Points;
            }
        }
    }

    public void Update()
    {
        if (Player.score == levelsPoints && !isPlayed)
        {
            VictoryScript.SetActive(true);
            HomeButton.SetActive(true);
            NextLevelButton.SetActive(true);
            Player.isPlayerBlocked = true;
            FindObjectOfType<AudioManager>().PlaySound("victory_sound");
            isPlayed = true;
        }
    }
}
