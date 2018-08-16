using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private float horizontalInput;
    private float verticalInput;
    [SerializeField]
    private float speed;

    private void PlayerMove() {
        speed = 5.0f;
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);
    }

    private void PlayerBounds() {
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

    private void Movements()
    {
        PlayerMove();
        PlayerBounds();
    }
    
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Movements();
	}

}
    