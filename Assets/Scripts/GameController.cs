using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public int lives ;
    public int scores;
    public Text LivesText;
    public Text ScoreText;
    public bool gameOver;
    public GameObject gameoverPanel;
    public GameObject loadlevelPanel;
    public int brickCount;
    public Transform[] levels;
    public int currentLevel=0;
    void Start()
    {   //initialize texts
        LivesText.text = "Lives: " + lives;
        ScoreText.text = "Score: " + scores;
        brickCount= GameObject.FindGameObjectsWithTag("brick").Length;
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}
    
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
        SceneManager.LoadScene("Start Menu");
        Debug.Log("Game is left.");
    }

    public void UpdateBrickCount(){
        brickCount--;
        if(brickCount <= 0){
            if(currentLevel>=levels.Length -1){
                 GameOver();
            }
           else{
               loadlevelPanel.SetActive(true);
               loadlevelPanel.GetComponentInChildren<Text>().text = "Great! Level " + (currentLevel + 2) ;
               gameOver=true;
               Invoke("LoadLevel",3f);
           }
        }

    }

    public void LoadLevel(){
        currentLevel++;
        Instantiate(levels[currentLevel],Vector2.zero, Quaternion.identity);
        brickCount = GameObject.FindGameObjectsWithTag("brick").Length;
        gameOver=false;
        loadlevelPanel.SetActive(false);
    }
}
