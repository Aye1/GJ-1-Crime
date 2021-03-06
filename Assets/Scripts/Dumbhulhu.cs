﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Dumbhulhu : Character {
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected override DialogLine[] GetDialogLines()
    {
        if (!Inventory.Instance.HasVictim)
        {
            DialogLine[] lines = {
                new DialogLine("Oh, c'est toi. Pret pour l'examen final de cultiste ?", this),
                new DialogLine("Le sacrifice aura lieu ici même, c'est moi qui superviserai l'epreuve.", this),
                new DialogLine("Pour la victime, va voir le responsable des ressources humaines, Freddy.", this),
                new DialogLine("Reviens me voir quand tu l'as.", this)
            };
            return lines;
        } else {
            DialogLine[] lines = {
                new DialogLine("Je vois que tu as recupere la victime !", this),
                new DialogLine("Passons au rituel, montre moi le résultat de ton apprentissage.", this)
            };
            return lines;
        }
    }

    protected override void DoAfterDialogue(object sender, EventArgs args) {
        if(Inventory.Instance.HasVictim) {
            GameManager.Instance.DisplayEndGameScreen();
        }
    }
}
