using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private static GameManager _instance;
    private Player _player;
    public bool shouldTeleportToStairs = false;

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
        _player = FindObjectOfType<Player>();
        SceneManager.sceneLoaded += SetPlayerInitialPosition;
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void FreezeAllButText(bool on) {
        _player.forceStopMove = on;
        _player.blockInteraction = on;
    }

    private void SetPlayerInitialPosition(Scene scene, LoadSceneMode mode) {
        _player = FindObjectOfType<Player>();
        if(shouldTeleportToStairs) {
            TeleportPlayerToStairsExit();
        }
    }

    private void TeleportPlayerToStairsExit() {
        Vector3 pos = FindObjectOfType<Escalier>().exitPosition;
        _player.transform.position = pos;
    }
}
