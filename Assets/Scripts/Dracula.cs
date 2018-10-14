using System;
using UnityEngine;
using UnityEngine.UI;

public class Dracula : Character
{
    public Vector2 TeleportTo;
    public Image darkness;

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
                    "Qu'est-ce qui t'amène ici?"),
                new DialogLine("Tu es inscrit en cours d'hémologie et tu veux goûter mes grands crus ?", this),
                BuildMultiLineDialog(
                    this,
                    "Ha, tu veux apprendre à voler...",
                    "Ce n'est pas au programme de ton cursus mais je ne vois pas pourquoi tu ne pourrais pas suivre de cours optionnels."),
                new DialogLine("Par contre tu vas devoir te montrer apte en réussissant l'examen.", this),
                new DialogLine("Devant toi tu peux voir une passerelle qui surplombe un gouffre, tu dois la traverser.", this),
                new DialogLine("Tu trouves probablement ça facile, mais attention, tu vas devoir faire tout ça dans le noir le plus complet, tel un vrai vampire.",this),
                new DialogLine("Rejoins moi de l'autre côté pour valider cette épreuve et nous reparlerons d'apprendre à voler.", this)
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
            ActivateDarkness(true);
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

    public void ActivateDarkness(bool on) {
        darkness.gameObject.SetActive(on);
    }
}
