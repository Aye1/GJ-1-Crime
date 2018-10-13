public class SwaggVador : Character
{
    protected override DialogLine[] GetDialogLines()
    {
        if (!Inventory.Instance.CanUseTheForce)
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
            Inventory.Instance.CanUseTheForce = true;
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
    }
}
