﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    private Player _player;
    public bool shouldTeleportToStairs = false;
    public GameObject endGameScreen;
    public bool isGameFinished;

    public static GameManager Instance
    {
        get { return _instance; }
    }

    // Use this for initialization
    void Start()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(gameObject);
        _player = FindObjectOfType<Player>();
        SceneManager.sceneLoaded += SetPlayerInitialPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }

    public void FreezeAllButText(bool on)
    {
        _player.forceStopMove = on;
        _player.blockInteraction = on;
    }

    private void SetPlayerInitialPosition(Scene scene, LoadSceneMode mode)
    {
        _player = FindObjectOfType<Player>();
        if (shouldTeleportToStairs)
        {
            TeleportPlayerToStairsExit();
        }
    }

    private void TeleportPlayerToStairsExit()
    {
        Vector3 pos = FindObjectOfType<Escalier>().exitPosition;
        _player.transform.position = pos;
    }

    public void DisplayEndGameScreen() {
        isGameFinished = true;
        endGameScreen.SetActive(true);
    }
}
