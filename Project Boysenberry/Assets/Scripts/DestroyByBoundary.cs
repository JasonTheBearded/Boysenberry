using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            other.gameObject.GetComponent<Collider2D>().enabled = false;
            Renderer rend = other.gameObject.GetComponent<SpriteRenderer>();
            rend.enabled = false;
            Debug.Log("Player hit by hazard");
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            player.LoseLife();
        }
    }
}
