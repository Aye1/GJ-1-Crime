using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioStopAtDistance : MonoBehaviour {

    Player _player;
    AudioSource _source;
    float maxDist = 20.0f;

    // Use this for initialization
    void Start () {
        _player = FindObjectOfType<Player>();
        _source = FindObjectOfType<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Vector3.Distance(_player.transform.position, gameObject.transform.position) > maxDist) {
            _source.volume = 0.0f;
        } else {
            _source.volume = 1.0f;
        }
	}
}
