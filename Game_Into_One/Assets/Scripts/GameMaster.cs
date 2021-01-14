using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{

    public Image[] livesDisplay;
    int livesLeft = 3;
    int score = 0; 
    public Text scoreCurret, finalScore;
    public GameObject GameOverScreen;
    // Update is called once per frame
    
    public void playerHit()
    {
        livesLeft--;
        UpdateLives(); 
    }
    void UpdateScore(int x) {
        score += x;
        scoreCurret.text = score.ToString();
        finalScore.text = score.ToString();

    }

    void GameOver()
    {
        GameOverScreen.SetActive(true); 
    }

    void UpdateLives()
    {
        for(int i =0; i < livesDisplay.Length; i++)
        {
            
            if(i <= livesLeft - 1)
            {
                livesDisplay[i].enabled = true;
            }
            else
            {
                livesDisplay[i].enabled = false;
            }
        }

    }
}
