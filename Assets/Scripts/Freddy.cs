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
        DialogLine[] lines = {
            new DialogLine("Line 1"),
            new DialogLine("Line 2")
        };
        return lines;
    }
}
