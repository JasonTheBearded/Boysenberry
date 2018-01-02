using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float playerNumber;
    public float speed;
    public float turnSpeed;
    public float zAxis;
    public float timeBetweenShoves;
    public GameObject target;

    private Rigidbody2D rb2d;
    private Animator animator;
    private float timer;
    private string movementAxisName;
    private string turnAxisName;
    private string fireButtonName;
    private float movementInputValue;
    private float turnInputValue;
    
    

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        movementAxisName = "Vertical" + playerNumber;
        turnAxisName = "Horizontal" + playerNumber;
        fireButtonName = "Player" + playerNumber + "Fire1";
    }

    private void Update(){
        timer += Time.deltaTime;
        movementInputValue = Input.GetAxis(movementAxisName);
        turnInputValue = Input.GetAxis(turnAxisName);
        
        if (Input.GetButton(fireButtonName) && timer >= timeBetweenShoves)
        {
            Shove();
        }
    }

    //Check every frame for player movement and apply movement
    void FixedUpdate()
    {
        Move();
        transform.LookAt(target.transform.position);
        transform.Rotate(new Vector3(0,-90,zAxis),Space.Self);//correcting the original rotation
        
    }

    void Move(){

        Vector2 movement = new Vector2(turnInputValue, movementInputValue);
        rb2d.AddForce(movement * speed);
        //Vector2 movement = transform.up * movementInputValue * speed * Time.deltaTime;
        //rb2d.MovePosition(rb2d.position + movement);
    }

    void Shove()
    {
        timer = 0f;
        animator.SetTrigger("playerShove");
    }

}
