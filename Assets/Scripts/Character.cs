﻿using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public abstract class Character : MonoBehaviour, IInteractable
{
    public Sprite picture;
    public string characterName;
    private Timer interactTimer;
    public bool canInteract;

    // Use this for initialization
    void Start()
    {
        canInteract = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Interact()
    {
        if (canInteract && !GameManager.Instance.isGameFinished)
        {
            canInteract = false;
            DoBeforeDialogue();
            DialogManager.Instance.StartDialog(GetDialogLines());
            DialogManager.Instance.dialogClosing += DoAfterDialogue;
            DialogManager.Instance.dialogClosing += WaitBeforeNextInteract;
        }
    }

    private void WaitBeforeNextInteract(object sender, EventArgs args)
    {
        interactTimer = new Timer(_ => canInteract = true, null, 500, 0);
        DialogManager.Instance.dialogClosing -= DoAfterDialogue;
    }

    protected DialogLine BuildMultiLineDialog(Character character, params string[] lines)
    {
        return new DialogLine(string.Join(Environment.NewLine, lines), character);
    }

    protected DialogLine BuildMultiLineDialog(params string[] lines)
    {
        return new DialogLine(string.Join(Environment.NewLine, lines));
    }

    protected DialogLine[] GetABlankPhrase(Character character)
    {
        int index = UnityEngine.Random.Range(0, blankLines.Count);
        return new DialogLine[]
        {
           new DialogLine(blankLines[index], character)
        };
    }

    private List<string> blankLines = new List<string>
    {
        "Tu n'as pas autre chose à faire ?",
        "Va ennuyer quelqu'un d'autre",
        "Qui a deux pouces et n'a pas envie de te parler ?",
        "Je crois que quelqu'un t'appelles là bas"
    };

    protected abstract DialogLine[] GetDialogLines();
    protected virtual void DoBeforeDialogue() { }
    protected virtual void DoAfterDialogue(object sender, EventArgs args) { }
}
