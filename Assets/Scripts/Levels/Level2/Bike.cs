﻿using UnityEngine;
using System.Collections;

public class Bike : MonoBehaviour {

	public float speed;
	public float accel;
	private float currentSpeed;

	// Use this for initialization
	void Start () {
		Input.gyro.enabled = true;
		currentSpeed = speed;
	
	}
	
	// Update is called once per frame
	void Update () {
		float dt = Time.deltaTime;
		transform.parent.Translate(dt*currentSpeed, 0, 0);
		currentSpeed += (accel/10)*dt;

		Move ();



	}

	float clamp(float v, float min, float max){
		if (v < min) {
			return min;
		} else if (v > max) {
			return max;
		}
		return v;
	}

	void OnTriggerEnter2D(Collider2D other){
		switch (other.name) {
		case "SelfieGirl":
		case "Trashcan":
		case "Bench":
			other.enabled = false;
			currentSpeed /= 4;
			break;
		}
	}

	void Move(){
		if (Input.touchCount > 0){

		}

		Vector3 gyro = Input.gyro.rotationRate;
		gyro.x = 0;
		transform.Translate (gyro/10);
		Vector3 pos = transform.localPosition;
		float clamped = clamp (pos.y, -5f, 3.5f);
		pos.y = clamped;
		transform.localPosition = pos;
	}

}
