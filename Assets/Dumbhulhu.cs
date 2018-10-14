using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dumbhulhu : Character {
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected override DialogLine[] GetDialogLines()
    {
        DialogLine[] lines = {
            new DialogLine("Bienvenue à la Crime Academy", this)
        };
        return lines;
    }

}
