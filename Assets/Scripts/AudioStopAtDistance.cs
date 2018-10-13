using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioStopAtDistance : MonoBehaviour {

    Player _player;
    AudioSource _source;
    public float maxDist;

    // Use this for initialization
    void Start () {
        _player = FindObjectOfType<Player>();
        _source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        float dist = Vector3.Distance(_player.transform.position, gameObject.transform.position);
        _source.mute = dist > maxDist;
	}
}
