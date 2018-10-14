using System;
using System.Collections.Generic;

public class SwaggVador : Character
{
    //private bool _deathStarReturned;
    private bool _questGiven;
    private bool _willGrantForce;

    private void Update()
    {
        if (Inventory.Instance.DeathStarReturned)
        {
            FindObjectOfType<Dancefloor>().SpotlightsOn();
        }
    }

    protected override DialogLine[] GetDialogLines()
    {
        if (Inventory.Instance.CanUseTheForce && Inventory.Instance.DeathStarReturned)
        {
            return GetABlankPhrase(this);
        }

        List<DialogLine> aggregatedLines = new List<DialogLine>();
        if (!Inventory.Instance.HasSeenVador && !_questGiven && !Inventory.Instance.HasTakenDeathStar)
        {
            aggregatedLines.Add(
                BuildMultiLineDialog(
                    this,
                    ".....*hmmmm kssssh*.....",
                    "T'es qui toi ?"));
            aggregatedLines.Add(
                BuildMultiLineDialog(
                    this,
                    ".....*hmmmm kssssh*.....",
                    "Alors, c'est qui le roi de la nuit ? C'est toujours Freddy ?",
                    "Non c'est Dark V !"));
            aggregatedLines.Add(BuildMultiLineDialog(
                    this,
                    ".....*hmmmm kssssh*.....",
                    "Par contre la je suis en pleine descente et j'ai perdu ma boule disco, si tu la trouves ramenes la moi et tu pourras utiliser le dance floor"));
            _questGiven = true;
        }
        else
        {
            aggregatedLines.Add(
                BuildMultiLineDialog(
                    this,
                    ".....*hmmmm kssssh*.....",
                    "Et ma boule disco ?"));
        }

        if (Inventory.Instance.HasSeenDeathStar && !Inventory.Instance.HasTakenDeathStar)
        {
            _willGrantForce = true;
            aggregatedLines.Add(new DialogLine("Je l'ai trouvee, elle est devant l'escalier", FindObjectOfType<Player>()));
            aggregatedLines.Add(
                BuildMultiLineDialog(
                    this,
                    ".....*hmmmm kssssh*.....",
                    "Tu l'as vue ? Elle est dans l'escalier au fond du hall ? C'est beaucoup trop loin pour moi"));
            aggregatedLines.Add(
                BuildMultiLineDialog(
                    this,
                    ".....*hmmmm kssssh*.....",
                    "Ecoutes, je vais te faire une injection de medichloriens pour que tu puisses utiliser la Force."));
            aggregatedLines.Add(
                BuildMultiLineDialog(
                    this,
                    ".....*hmmmm kssssh*.....",
                    "Hahaha, je t'ai bien eu. Des medichloriens, quel concept idiot..."));
            aggregatedLines.Add(
                BuildMultiLineDialog(
                    this,
                    ".....*hmmmm kssssh*.....",
                    "Utilise la haine et tout ça, tu verras c'est facile."));
        }

        if (Inventory.Instance.HasTakenDeathStar && !Inventory.Instance.DeathStarReturned)
        {
            aggregatedLines.Add(new DialogLine("Voila votre Death Star, M. Vador", FindObjectOfType<Player>()));
            aggregatedLines.Add(new DialogLine("La soiree peut repreeeeendre", this));
            Inventory.Instance.HasTakenDeathStar = false;
            Inventory.Instance.DeathStarReturned = true;            
        }
        return aggregatedLines.ToArray();
    }

    protected override void DoAfterDialogue(object sender, EventArgs args)
    {
        if (_willGrantForce)
        {
            Inventory.Instance.CanUseTheForce = true;
            _willGrantForce = false;
        }
        if (Inventory.Instance.DeathStarReturned)
        {
            FindObjectOfType<Dancefloor>().SpotlightsOn();
        }
    }
}
