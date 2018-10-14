using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvas : MonoBehaviour {

    private static MainCanvas _instance;
    public static MainCanvas Instance {
        get { return _instance; }
    }

	// Use this for initialization
	void Start () {
        if (_instance != this && _instance != null) {
            Destroy(gameObject);
        } else {
            _instance = this;
        }
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
