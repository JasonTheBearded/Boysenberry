using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoveTrigger : MonoBehaviour {

    public float magnitude = 50f;
    public float playerNumber;

    private Rigidbody2D rb2d;


    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.isTrigger != true && col.CompareTag("Player"))
        {
            Vector3 force = transform.position - col.transform.position;

            Debug.Log("Hit by Player" + playerNumber + " Shove");
            col.gameObject.GetComponent <Rigidbody2D> ().AddForce(-force * magnitude);
        }
    }
}
