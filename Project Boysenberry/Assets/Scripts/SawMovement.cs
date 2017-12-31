using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMovement : MonoBehaviour {

	public Transform start;
	public Transform target;
	public float speed;
	private bool starter;

	void Start(){
		starter = true;
	}

	void Update(){
		float step = speed * Time.deltaTime;

		if (starter) {
			MoveSawsForward(step);
		}// else if (starter == false) {
		//	ReturnSaws(step);
		//}
	}

	void MoveSawsForward(float step){
		transform.position = Vector3.MoveTowards (transform.position, target.position, step);
		starter = false;
	}
	
	//void ReturnSaws(float step){
	//	transform.position = Vector3.MoveTowards (transform.position, start.position, step);
	//}		
}
