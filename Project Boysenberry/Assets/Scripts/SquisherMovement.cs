using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquisherMovement : MonoBehaviour {

    public Vector3 target;
    public float speed;

    private Vector3 start;
    private bool complete;
    private float step;
	// Use this for initialization
	void Start () {
        start = transform.position;
        step = speed * Time.deltaTime;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!complete)
        {
            StartCoroutine(StartSquishers(target, step));
        }
        else
        {
            StartCoroutine(EndSquishers(start, step));
        }
	}

    IEnumerator StartSquishers(Vector3 newPosition, float step)
    {
        float sqrRemainingDistance = (transform.position - newPosition).sqrMagnitude;

        //While that distance is greater than a very small amount (Epsilon, almost zero):
        while (sqrRemainingDistance > float.Epsilon)
        {
            yield return new WaitForSeconds(.1f);
            transform.position = Vector3.MoveTowards(transform.position, target, step);
            sqrRemainingDistance = (transform.position - newPosition).sqrMagnitude;
            yield return null;
        }

        complete = true;
    }

    IEnumerator EndSquishers(Vector3 newPosition, float step)
    {
        float sqrRemainingDistance = (transform.position - newPosition).sqrMagnitude;

        while (sqrRemainingDistance > float.Epsilon)
        {
            yield return new WaitForSeconds(.3f);
            transform.position = Vector3.MoveTowards(transform.position, start, step);
            sqrRemainingDistance = (transform.position - newPosition).sqrMagnitude;
            yield return null;
        }
    }
}
