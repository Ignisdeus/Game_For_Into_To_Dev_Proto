using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{

    public Image[] livesDisplay;
    int livesLeft = 3;
    int score = 0, combo = 1 ; 
    public Text scoreCurret, finalScore, comboText;
    public GameObject GameOverScreen;
    private AudioSource audioS;
    public AudioClip gameOverAudio;
    // Update is called once per frame
    private void Start()
    {
        audioS = gameObject.AddComponent<AudioSource>();
        UpdateScore(0); 
    }
    public void playerHit()
    {
        livesLeft--;
        UpdateLives(); 
    }

    private void Update()
    {
        if(GameOverScreen.activeInHierarchy && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }
    }
    void UpdateScore(int x = 0) {
        if(livesLeft < 3)
        {
            livesLeft++;
            UpdateLives();
        }
        score += x * combo;
        scoreCurret.text = score.ToString();
        finalScore.text = score.ToString();
        comboText.text = "x " + combo.ToString(); 

    }

    public GameObject player; 
    void GameOver()
    {
        audioS.PlayOneShot(gameOverAudio, 0.7f);
        Destroy(player); 
        StartCoroutine(GameOverScreenTimer());
    }

    IEnumerator GameOverScreenTimer()
    {   
        yield return new WaitForSeconds(0.5f);
        GameOverScreen.SetActive(true);
    }
    public void LevelComplete()
    {
       
        UpdateScore(100);
        combo++;

    }
    public void ResetCombo()
    {
        combo = 1; 
    }
    void UpdateLives()
    {
        if(livesLeft <= 0)
            GameOver(); 
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
