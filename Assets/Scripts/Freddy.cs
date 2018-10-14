using System.Collections.Generic;

public class Freddy : Character
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override DialogLine[] GetDialogLines()
    {
        List<DialogLine> aggregatedLines = new List<DialogLine>();
        if (!Inventory.Instance.HasFreddyScroll)
        {
            aggregatedLines.Add(
                BuildMultiLineDialog(
                    this,
                    "Oui, c'est pour quoi ?",
                    "Une victime pour un sacrifice rituel ?"));
            aggregatedLines.Add(
                BuildMultiLineDialog(
                    this,
                    "Il vous faut un FDP pour ça.",
                    "Un Formulaire de Demande de Prisonnier, vous n'êtes pas très vif vous..."));
            aggregatedLines.Add(BuildMultiLineDialog(
                    this,
                    "Vous en trouverez un dans la remise à l'autre bout du hall mais attention le sol s'est effondré."));
            aggregatedLines.Add(BuildMultiLineDialog(
                    this,
                    "On attend la livraison d'un formulaire SS... Sauvetage des Sols"));
        }
        else if (!Inventory.Instance.HasVictim)
        {
            Inventory.Instance.AllowedToTakeVictim = true;
            aggregatedLines.Add(
                BuildMultiLineDialog(
                    this,
                    "Vous y avez mis le temps, il va falloir vous remuer un peu si vous voulez réussir vos études."));
            aggregatedLines.Add(
                BuildMultiLineDialog(
                    this,
                    "Tout semble en règle, vous pouvez prélever."));
        }
        else
        {
            return GetABlankPhrase(this);
        }

        return aggregatedLines.ToArray();
    }
}
