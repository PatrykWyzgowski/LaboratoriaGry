﻿using UnityEngine;
using UnityEngine.SceneManagement;
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
  
    public Text scoreText;
    public int score { get; set; }   

    public Text Restart;
    public Text GameOver1;


    private bool gameOver;
    private bool restart;
    private AudioSource gameOverSound;


    void Start()
	{
        gameOver = false;
        restart = false;
        Restart.text = "";
        GameOver1.text = "";
        score=0;
        UpdateScore ();
        StartCoroutine(SpawnWaves());
	}
    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
    IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds(startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate(hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                Restart.text = "Press 'R' for Restart";
                restart = true;
                gameOverSound = GetComponent<AudioSource>();
                gameOverSound.Play();
                break;
            }
        }
	}

    public void GameOver()
    {
        GameOver1.text = "Game Over!";
        gameOver = true;
    }

    public void AddScore (int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore ();
    }

    void UpdateScore ()
    {
        scoreText.text = "Score: " + score;
    }

}