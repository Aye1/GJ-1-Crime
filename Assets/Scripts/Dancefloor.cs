﻿using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Random = System.Random;

public class Dancefloor : MonoBehaviour
{
    public List<Color> colors;
    public GameObject spotlights;

    Timer _timer;
    Random _random;
    bool _shouldUpdateTiles = false;
    const int time = 6000 / 13;

    // Use this for initialization
    void Start()
    {
        //timer = new Timer(new TimerCallback(OnTimerTick), null, 1000, 0);
        _timer = new Timer(OnTimerTick, null, 0, time);
        _random = new Random();
    }

    // Update is called once per frame
    void Update()
    {
        if (_shouldUpdateTiles)
        {
            UpdateTiles();
        }
    }

    private void OnTimerTick(object state)
    {
        _shouldUpdateTiles = true;
    }

    private void UpdateTiles()
    {
        _shouldUpdateTiles = false;
        foreach (DancefloorTile tile in gameObject.GetComponentsInChildren<DancefloorTile>())
        {
            tile.ManageLight(GetNextColor());
        }
    }

    private Color GetNextColor()
    {
        int index = _random.Next(0, colors.Count);
        return colors.ToArray()[index];
    }

    public void SpotlightsOn() {
        spotlights.SetActive(true);
    }
}
