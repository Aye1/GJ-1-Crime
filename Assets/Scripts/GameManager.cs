using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager _instance;

    public static GameManager Instance {
        get { return _instance; }
    }

	// Use this for initialization
	void Start () {
        if(_instance != null && _instance != this) {
            Destroy(gameObject);
        } else 
        {
            _instance = this;
        }
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FreezeAllButText() {

    }
}
