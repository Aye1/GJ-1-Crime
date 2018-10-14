using System;
using System.Collections.Generic;

public class Prisonners : Character
{

    private List<DialogLine> allLines = new List<DialogLine>
    {
        new DialogLine("Je suis pas venu ici pour souffrir OK ?")
    };

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
        else
        {
            return new DialogLine[]
            {
                BuildMultiLineDialog(
                    this,
                    "Si ça vous ennuie pas j'aime autant rester là finalement, on n'y est pas si mal."),
                BuildMultiLineDialog(
                    this,
                    "Non, vraiment j'insite..."),
                BuildMultiLineDialog(
                    this,
                    "PITIE... NOOOON !")
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
