using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject[] hazards;
    public GameObject bloodSplat;
    public GameObject player1WinPanel;
    public GameObject player2WinPanel;
    public float startWait;
    public float hazardWait;
    public float respawnWait;

    private GameObject hazard;
    private int hazardSpawn;
    private int bloodSpawn;
    private float player1Lives;
    private float player2Lives;
    private bool gameOver;
    public bool dead;


    // Use this for initialization
    private void Awake()
    {
        player1WinPanel.SetActive(false);
        player2WinPanel.SetActive(false);
    }
    void Start () {
        gameOver = false;
        dead = false;
        InvokeRepeating("SpawnHazards", startWait, hazardWait);
	}
	
	// Update is called once per frame
	void Update () {
		if(gameOver && Input.GetKey("R"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
	}

    void SpawnHazards()
    {
        if(gameOver || dead)
        {
            return;
        }
        
        hazard = hazards[Random.Range(0, hazards.Length)];
        Instantiate(hazard);
    }

    public void GameOver()
    {
        player1Lives = GameObject.Find("Player1").GetComponent<PlayerController>().lives;
        player2Lives = GameObject.Find("Player2").GetComponent<PlayerController>().lives;

        gameOver = true;
        if (player1Lives > player2Lives)
        {
            player1WinPanel.SetActive(true);
        }
        else
        {
            player2WinPanel.SetActive(true);
        }
    }

    public void Death(Vector3 deathPosition)
    {
        Destroy(hazard);
        Instantiate(bloodSplat, deathPosition, Quaternion.identity);
    }
}
