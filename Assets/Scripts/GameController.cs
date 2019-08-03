using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour

{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public int score;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    public Text youWinText;

    private bool youWin;
    private bool gameOver;
    private bool restart;
   public AudioSource audioSource;
   public AudioClip Victory;
   public AudioClip Lose;
    void Start ()
    {
        audioSource = GetComponent<AudioSource> ();
        gameOver = false;
        restart = false;
        youWin = false;
        gameOverText.text = "";
        restartText.text = "";
        youWinText.text = "";
        score = 0;
        UpdateScore ();
        StartCoroutine (SpawnWaves ());
        
        
    }

    void Update ()
    {
        if (restart)
        {
            if (Input.GetKeyDown (KeyCode.T))
            {
                Application.LoadLevel (Application.loadedLevel);
            }
        }
         if (Input.GetKey("escape"))
     Application.Quit();
    }

    IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds (startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                
                GameObject hazard = hazards[Random.Range (0,hazards.Length)];
                Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate (hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds (spawnWait);
            }
            yield return new WaitForSeconds (waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'T' for Restart";
                restart = true;
                break;
            }
           
        }
    }

    public void AddScore (int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore ();
    }

    void UpdateScore ()
    {
        scoreText.text = "Points: " + score;
          if (score >= 300)
          {
            youWinText.text = "You WIN! Game by Roni Conner";
            youWin = true;
            gameOver = true;
            restart = true;
            audioSource.clip = Victory;
            audioSource.Play();
            audioSource.loop = false;
           }
    }

    public void GameOver ()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
         if (youWin = true)
    {
        gameOverText.text = "";
    }

    if (gameOver = true)
    {
        audioSource.clip = Lose;
            audioSource.Play();
            audioSource.loop = false;
    }

    }
   
}