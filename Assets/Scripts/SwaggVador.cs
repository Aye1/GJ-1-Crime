using System.Collections.Generic;

public class SwaggVador : Character
{
    protected override DialogLine[] GetDialogLines()
    {
        List<DialogLine> aggregatedLines = new List<DialogLine>();
        
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
                    "Par contre là je suis en pleine descente et j'ai perdu ma boule disco, si tu la trouves ramènes la moi et tu pourras utiliser le dance floor"));
   
        if(Inventory.Instance.HasSeenDeathStar)
        {
            Inventory.Instance.CanUseTheForce = true;
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
                    "Hahaha, je t'ai bien eu, des medichloriens, quel concept idiot... Utilise la haine et tout ça, tu verras c'est facile."));
        }
        return aggregatedLines.ToArray();
    }
}
