using System;
using UnityEngine;

public abstract class Character : MonoBehaviour, IInteractable
{
    public Sprite picture;
    public string characterName;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Interact()
    {
        DoBeforeDialogue();
        DialogManager.Instance.StartDialog(GetDialogLines());
        DialogManager.Instance.dialogClosing += DoAfterDialogue;
    }

    protected DialogLine BuildMultiLineDialog(Character character, params string[] lines)
    {
        return new DialogLine(string.Join(Environment.NewLine, lines), character);
    }

    protected DialogLine BuildMultiLineDialog(params string[] lines)
    {
        return new DialogLine(string.Join(Environment.NewLine, lines));
    }

    protected abstract DialogLine[] GetDialogLines();
    protected virtual void DoBeforeDialogue() { }
    protected virtual void DoAfterDialogue(object sender, EventArgs args) { }
}
