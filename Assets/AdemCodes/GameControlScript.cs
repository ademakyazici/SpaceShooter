using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControlScript : MonoBehaviour
{

    public GameObject asteroid;
    public Vector3 randomRange;
    public Text scoreText;
    public Text gameOverText;

    bool isGameFinished=false;
   

    int score;
    
    void Start()
    {
        StartCoroutine(create());
        score = 0;
    }

    private void Update()
    {
       if (Input.GetKeyDown(KeyCode.R))
        {
            if(isGameFinished==true)
            {
                isGameFinished = false;
                SceneManager.LoadScene("level1");

            }
        }
    }


    IEnumerator create()
    {
        yield return new WaitForSeconds(2);

        while(true)
        {
            if(isGameFinished)
            {
                break;
            }

            for(int i=0;i<10;i++)
            {
                Vector3 position = new Vector3(Random.Range(randomRange.x, -randomRange.x), randomRange.y, -0.3f);
                Instantiate(asteroid, position, Quaternion.identity);
                yield return new WaitForSeconds(1);
            }
            yield return new WaitForSeconds(4);

            

        }
       
    }

    public void increaseScore(int incomingScore)
    {
        score += incomingScore;
        Debug.Log(score);
        scoreText.text = "Score: " + score;
    }

    public void gameOver()
    {
        gameOverText.text = "Oyun Bitti. Skorunuz: " + score;
        StartCoroutine(gameOverTimer(3));
        
        

    }

    IEnumerator gameOverTimer(int seconds)
    {
       yield return new WaitForSeconds(seconds);
        isGameFinished = true;
        gameOverText.text = "Yeniden başlamak için R'ye basınız ";
    }

    
}
