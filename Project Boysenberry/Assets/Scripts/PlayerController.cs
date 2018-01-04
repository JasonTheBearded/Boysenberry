using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public int playerNumber;
    public float speed;
    public float zAxis;
    public float timeBetweenShoves;
    public int lives;
    public float respawnWait;
    public bool dead;
    public GameObject target;
    public Collider2D attackTrigger;
    public Text playerLives;

    private Rigidbody2D rb2d;
    private Animator animator;
    private GameController gameController;
    
    private Vector3 startPosition;
    private Vector3 targetStartPosition;
    private float timer;
    private string movementAxisName;
    private string turnAxisName;
    private string fireButtonName;
    private float movementInputValue;
    private float turnInputValue;


    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        movementAxisName = "Vertical" + playerNumber;
        turnAxisName = "Horizontal" + playerNumber;
        fireButtonName = "Player" + playerNumber + "Fire1";
        attackTrigger.enabled = false;
        playerLives.text = "Player " + playerNumber + ": " + lives;
        startPosition = gameObject.transform.position;
        targetStartPosition = target.transform.position;
    }

    private void Start()
    {
        
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

    }

    private void Update(){
        timer += Time.deltaTime;
        movementInputValue = Input.GetAxis(movementAxisName);
        turnInputValue = Input.GetAxis(turnAxisName);
        
        if (Input.GetButton(fireButtonName) && timer >= timeBetweenShoves)
        {
            Shove();
        }
        else
        {
            attackTrigger.enabled = false;
        }
    }

    //Check every frame for player movement and apply movement
    void FixedUpdate()
    {
        Move();
        LookAt();
    }

    void Move(){

        Vector2 movement = new Vector2(turnInputValue, movementInputValue);
        rb2d.AddForce(movement * speed);
        //Vector2 movement = transform.up * movementInputValue * speed * Time.deltaTime;
        //rb2d.MovePosition(rb2d.position + movement * Time.deltaTime);
    }

    void LookAt()
    {
        if (target != null) { 
        //transform.LookAt(target.transform.position);
        Vector3 vectorToTarget = target.transform.position - transform.position;
        float angle = (Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg) - 90;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
        }
    }

    void Shove()
    {
        timer = 0f;
        animator.SetTrigger("playerShove");
        attackTrigger.enabled = true;
    }

    public void LoseLife()
    {
        gameController.dead = true;
        Debug.Log("taking life off and preparing respawn");
        lives--;
        playerLives.text = "Player " + playerNumber + ": " + lives;
        if (lives == 0)
        {
            gameController.GameOver();
        }
        else
        {
            StartCoroutine(Respawn());

        }
        
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnWait);
        gameObject.transform.position = startPosition;
        target.transform.position = targetStartPosition;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<Collider2D>().enabled = true;
        Debug.Log("Respawn has occured");
        yield return new WaitForSeconds(1f);
        gameController.dead = false;
    }
}
