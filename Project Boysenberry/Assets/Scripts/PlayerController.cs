using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    //Check every frame for player movement and apply movement
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moverVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moverVertical);
        rb2d.AddForce(movement * speed);
    }
}
