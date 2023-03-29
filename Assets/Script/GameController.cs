using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public TMP_Text scoreText;
    public TMP_Text gameOverText;
    public Button retryGameButton;
    public Button quitGameButton;


    public bool gameOver;
    private bool retryGame;
    private bool quitGAme;

    public int score;
    void Start()
    {
        gameOver = false;
        retryGame = false;
        gameOverText.text = "";
        retryGameButton.gameObject.SetActive(false);
        quitGameButton.gameObject.SetActive(false);

        score = 0;
        UpdateScore();
        StartCoroutine(Spawnwaves());
    }
    IEnumerator Spawnwaves ()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                 Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                 Quaternion spawnRotstion = Quaternion.identity;
                 Instantiate(hazard, spawnPosition, spawnRotstion);
                 yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            
            if (gameOver)
            {
                GameOver();
                break;
            }
        }
    }
    
    public void AddScore (int newscorevalue)

    {
        score += newscorevalue;
        UpdateScore();
    }


    void UpdateScore ()
    {
        scoreText.text = "score:" + score;
    }

    public void GameOver()
    {
        retryGameButton.gameObject.SetActive(true);
    }

    public void RetryGame()
    {
        SceneManager.LoadScene("Main");
        Debug.Log("Game open");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }
}
