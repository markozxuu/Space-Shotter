using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    // GameObject
    [SerializeField]
    private GameObject _laserPrefab;
    // Audio Source
    private AudioSource _musicLaser;
    // Float
    private float _horizontalInput;
    private float _verticalInput;
    private float _speed;
    [SerializeField]
    private float _fireRate = 0.25f;
    private float _canFire = 0.0f;

    private void LaserSong() {
        _musicLaser = GetComponent<AudioSource>();
        _musicLaser.Play();
    }

    private void PlayerMove()
    {
        _speed = 5.0f;
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * _speed * _horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.up * _speed * _verticalInput * Time.deltaTime);
    }

    private void PlayerBounds()
    {
        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }

        if (transform.position.x > 8)
        {
            transform.position = new Vector3(8, transform.position.y, 0);
        }
        else if (transform.position.x < -8)
        {
            transform.position = new Vector3(-8, transform.position.y, 0);
        }
    }

    private void ShotLaser() {

        // If space key pressed or click left
        // spawn laser at player position
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            if(Time.time > _canFire) {
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
                LaserSong();
                _canFire = Time.time + _fireRate;
                Debug.Log("The time elapsed  of game is: " + Time.time);
                Debug.Log("The value canFire is: " + _canFire);
                Debug.Log("The value fireRate is: " + _fireRate);
            }
        }
    }

    private void Movements() {
        // This method will contain all the movements 
        // that the player can do
        PlayerMove();
        PlayerBounds();
        ShotLaser();
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Movements();
	}

}
    