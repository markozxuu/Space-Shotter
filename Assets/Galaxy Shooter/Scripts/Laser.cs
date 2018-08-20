using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    // Float
    private float _speed;

    private void MoveLaser() {
        _speed = 10.0f;
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
        DestroyLaser();
    }

    private void DestroyLaser() {
        // When the laser goes beyond the limits of the camera
        // the object of the game will be destroyed, 
        // it is a good performance technique :)
        if (transform.position.y >= 5.45f) {
            Destroy(this.gameObject);
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MoveLaser();
	}
}
