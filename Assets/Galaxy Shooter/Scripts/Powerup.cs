using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {
    
    // Audio Source
    private AudioSource _powerupMusic;
    // Float
    [SerializeField]
    private float _speed = 3.0f;

    private void MovePowerup() {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update () {
        MovePowerup();
	}

    private void TripleShotAc(Collider2D other) {
        // Help filter the "OnTriggerEnter2D" method
        // when colliding with a gameObject that is not a "Player"
        if(other.tag == "Player") {
            Player player = other.GetComponent<Player>();
            if(player != null) {
                // In case the "Player" component exists
                player.TripleShotPowerupOn();
            }
            StopCoroutine(player.TripleShotPowerupDownRoutine());
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        TripleShotAc(other);
    }
}
