using System;

public class DiscoDeathStar : Character
{
    void Start()
    {
        if (Inventory.Instance.CanUseTheForce)
        {
            this.gameObject.SetActive(false);
        }
    }

    protected override DialogLine[] GetDialogLines()
    {
        Inventory.Instance.HasSeenDeathStar = true;

        if (!Inventory.Instance.CanUseTheForce)
        {
            return new DialogLine[] { new DialogLine("Ca semble extremement lourd...", FindObjectOfType<Player>()) };
        }
        else
        {
            return new DialogLine[] { new DialogLine("La Force est avec moiiiiiiii !", FindObjectOfType<Player>()) };
        }
    }

    protected override void DoAfterDialogue(object sender, EventArgs args)
    {
        if (Inventory.Instance.CanUseTheForce)
        {
            Inventory.Instance.HasTakenDeathStar = true;
            Destroy(this.gameObject);
        }
    }
}
