using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Galaxy : MonoBehaviour {

    // Audio Source
    private AudioSource _musicBackground;

    private void BackgroundSong() {
        _musicBackground = GetComponent<AudioSource>();
        _musicBackground.Play();
    }

	// Use this for initialization
	void Start () {
        BackgroundSong();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
