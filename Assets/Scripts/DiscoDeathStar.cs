﻿using System;

public class DiscoDeathStar : Character
{
    protected override DialogLine[] GetDialogLines()
    {
        Inventory.Instance.HasSeenDeathStar = true;

        if (!Inventory.Instance.CanUseTheForce)
        {
            return new DialogLine[] { new DialogLine("Ca semble extrêmemement lourd...") };
        }
        else
        {
            return new DialogLine[] { new DialogLine("Vous soulevez sans peine la Disco Death Star et l'écartez du chemin") };
        }
    }

    protected override void DoAfterDialogue(object sender, EventArgs args)
    {
        if (Inventory.Instance.CanUseTheForce)
        {
            Destroy(this.gameObject);
        }
    }
}