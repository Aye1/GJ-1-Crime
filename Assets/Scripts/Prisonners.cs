using System;
using System.Collections.Generic;

public class Prisonners : Character
{
    private List<DialogLine> allLines;

    private void Start()
    {
        allLines = new List<DialogLine>
        {
            new DialogLine("Je suis pas venu ici pour souffrir OK ?", this),
            new DialogLine("Je vais vous mettre une mauvaise note sur airbnb", this),
        };
    }

    protected override DialogLine[] GetDialogLines()
    {
        if (!Inventory.Instance.AllowedToTakeVictim)
        {
            int index = UnityEngine.Random.Range(0, allLines.Count);
            return new DialogLine[]
            {
                allLines[index]
            };
        }
        else if (!Inventory.Instance.HasVictim)
        {
            return new DialogLine[]
            {
                BuildMultiLineDialog(
                    this,
                    "Si ça vous ennuie pas j'aime autant rester la finalement, on n'y est pas si mal."),
                BuildMultiLineDialog(
                    this,
                    "Non, vraiment j'insite..."),
                BuildMultiLineDialog(
                    this,
                    "PITIE... NOOOON !")
            };
        }
        else
        {
            return new DialogLine[]
            {
                BuildMultiLineDialog(
                    FindObjectOfType<Freddy>(),
                    "Votre formulaire n'est valable que pour une ressource !"),
            };
        }
    }

    protected override void DoAfterDialogue(object sender, EventArgs args)
    {
        if (Inventory.Instance.AllowedToTakeVictim)
        {
            Inventory.Instance.HasVictim = true;
        }
    }
}
