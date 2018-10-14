using System;
using UnityEngine;
using UnityEngine.UI;

public class Dracula : Character
{
    public Vector2 TeleportTo;
    public Image darkness;

    public bool IsOnTheOtherSide { get; private set; }

    protected override DialogLine[] GetDialogLines()
    {
        if (Inventory.Instance.CanFly)
        {
            return GetABlankPhrase(this);
        }
        else if (!IsOnTheOtherSide)
        {
            return new DialogLine[]
            {
                BuildMultiLineDialog(
                    this,
                    "Tiens donc, un etudiant.",
                    "Qu'est-ce qui t'amene ici?"),
                new DialogLine("Tu es inscrit en cours d'hemologie et tu veux gouter mes grands crus ?", this),
                BuildMultiLineDialog(
                    this,
                    "Ha, tu veux apprendre à voler...",
                    "Ce n'est pas au programme de ton cursus mais je ne vois pas pourquoi tu ne pourrais pas suivre de cours optionnels."),
                new DialogLine("Par contre tu vas devoir te montrer apte en réussissant l'examen.", this),
                new DialogLine("Devant toi tu peux voir une passerelle qui surplombe un gouffre, tu dois la traverser.", this),
                new DialogLine("Tu trouves probablement ça facile, mais attention, tu vas devoir faire tout ça à l'aveugle, tel un vrai vampire.",this),
                new DialogLine("Rejoins moi de l'autre cote pour valider cette épreuve et nous reparlerons d'apprendre à voler.", this)
            };
        }
        else
        {
            return new DialogLine[]
            {
                BuildMultiLineDialog(
                    this,
                    "Bravo, bien joue. Tu as passé l'epreuve avec succès et je vais donc t'apprendre l'art du vol.",
                    "Approche et laisse toi faire..."),
                BuildMultiLineDialog(
                    this,
                    "......*Croc*......",
                    "......*Slurp*......"),
                BuildMultiLineDialog(
                    this,
                    "Bon sang, j'adore enseigner. Essaye donc ton nouveau pouvoir en retraversant la piece.",
                    "A bientot peut-être.")
            };
        }

    }

    protected override void DoAfterDialogue(object sender, EventArgs args)
    {
        if (!IsOnTheOtherSide)
        {
            this.transform.SetPositionAndRotation(TeleportTo, Quaternion.identity);
            IsOnTheOtherSide = true;
            FindObjectOfType<Initializer>().HideHoles();
        }
        else
        {
            Inventory.Instance.CanFly = true;
        }
    }
}
