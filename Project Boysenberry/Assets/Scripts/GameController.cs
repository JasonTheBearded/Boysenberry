using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject[] hazards;
    public GameObject[] players;
    public Text[] playerLives;
    public float startWait;
    public float hazardWait;
    public float respawnWait;

    private int hazardSpawn;
    private int bloodSpawn;
    private bool gameOver;
    public bool dead;
    

	// Use this for initialization
	void Start () {
        gameOver = false;
        dead = false;
        InvokeRepeating("SpawnHazards", startWait, hazardWait);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnHazards()
    {
        if(gameOver || dead)
        {
            return;
        }
        
        GameObject hazard = hazards[Random.Range(0, hazards.Length)];
        Instantiate(hazard);
    }

    public void GameOver()
    {
        gameOver = true;
    }
}
