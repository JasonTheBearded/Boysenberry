using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBloom : MonoBehaviour {

    public float speed;
    private float alpha = 0f;
    private Color color;
    private SpriteRenderer rend;

    // Use this for initialization
	void Start () {
        rend = GetComponent<SpriteRenderer>();
        color = rend.material.color;
        color.a = 0f;
        rend.color = color;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        while(alpha <= 1f)
        {
            Debug.Log("increasing alpha");
            alpha += speed;
            color.a = alpha;
            rend.color = color;
        }

	}
}
