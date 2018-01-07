using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAppear : MonoBehaviour {

    private SpriteRenderer rend;
    private Collider2D col;
    private bool complete;

    private void Awake()
    {
        rend = gameObject.GetComponent<SpriteRenderer>();
        col = gameObject.GetComponent<Collider2D>();
        rend.enabled = false;
        col.enabled = false;
        StartCoroutine(FireMaLaser());
    }

    IEnumerator FireMaLaser()
    {
        yield return new WaitForSeconds(1f);
        rend.enabled = true;
        col.enabled = true;
    }
}
