using System;
using UnityEngine;

public class Dracula : Character
{
    public Vector2 TeleportTo;

    private bool _isOnTheOtherSide;

    protected override DialogLine[] GetDialogLines()
    {
        if (!_isOnTheOtherSide)
        {
            return new DialogLine[]
            {
                BuildMultiLineDialog(
                    this,
                    "Tiens donc, un étudiant.",
                    "Qu'est-ce qui t'amène ici ?",
                    "Tu es inscrit en cours d'hémologie et tu veux goûter mes grands crus ?"),
                BuildMultiLineDialog(
                    this,
                    "Ha, tu veux apprendre à voler...",
                    "Ce n'est pas au programme de ton cursus mais je ne vois pas pourquoi tu ne pourrais pas suivre de cours optionnels.",
                    "Par contre tu vas devoir te montrer apte en réussissant l'examen."),
                BuildMultiLineDialog(
                    this,
                    "Devant toi tu peux voir une passerelle qui surplombe un gouffre, tu dois la traverser.",
                    "Tu trouves probablement ça facile, mais attention, tu vas devoir faire tout ça dans le noir le plus complet, tel un vrai vampire.",
                    "Rejoins moi de l'autre côté pour valider cette épreuve et nous reparlerons d'apprendre à voler.")
            };
        }
        else
        {
            return new DialogLine[]
            {
                BuildMultiLineDialog(
                    this,
                    "Bravo, bien joué. Tu as passé l'épreuve avec succès et je vais donc t'apprendre l'art du vol.",
                    "Approche et laisse toi faire..."),
                BuildMultiLineDialog(
                    this,
                    "......*Croc*......",
                    "......*Slurp*......"),
                BuildMultiLineDialog(
                    this,
                    "Bon sang, j'adore enseigner. Essaye donc ton nouveau pouvoir en retraversant la pièce.",
                    "A bientôt peut-être.")
            };
        }

    }

    protected override void DoAfterDialogue(object sender, EventArgs args)
    {
        if (!_isOnTheOtherSide)
        {
            this.transform.SetPositionAndRotation(TeleportTo, Quaternion.identity);
            _isOnTheOtherSide = true;
        }
        else
        {            
            Inventory.Instance.CanFly = true;
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
