using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public int lives;
    public int scores;
    public Text LivesText;
    public Text ScoreText;
    public bool gameOver;
    public GameObject gameoverPanel;
    public int brickCount;
    void Start()
    {   //initialize texts
        LivesText.text = "Lives: " + lives;
        ScoreText.text = "Score: " + scores;
        brickCount= GameObject.FindGameObjectsWithTag("brick").Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void LiveController(int newLives){
        
        lives += newLives;
        if (lives <=0){
            lives=0;
            GameOver();
        }
        LivesText.text = "Lives: " + lives;

    }

    public void ScoreController(int points){
        scores += points;
        ScoreText.text = "Score: " + scores;


    }

    public void GameOver(){
        gameOver=true;
        gameoverPanel.SetActive(true);

    }
    public void PlayAgain(){
        SceneManager.LoadScene("SampleScene");
    }
    public void ExitGame(){
        Application.Quit();
        Debug.Log("Game is left.");
    }

    public void UpdateBrickCount(){
        brickCount--;
        if(brickCount == 0){
            GameOver();
        }

    }
}
