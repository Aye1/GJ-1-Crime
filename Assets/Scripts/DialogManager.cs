using System;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public DialogBox dialog;
    public bool isDialogOpen = false;

    // Event sent when the dialog is closing
    public EventHandler dialogClosing;

    private static DialogManager _instance;
    public static DialogManager Instance
    {
        get { return _instance; }
    }

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void StartDialog(DialogLine[] dialogLines)
    {
        if (!isDialogOpen)
        {
            DialogBox currentDialog = Instantiate(dialog);
            currentDialog.Init(dialogLines);
            currentDialog.transform.SetParent(FindObjectOfType<Canvas>().transform);
            RectTransform rect = currentDialog.GetComponent<RectTransform>();
            rect.offsetMax = new Vector2(-20, rect.offsetMax.y);
            isDialogOpen = true;
            currentDialog.dialogClosing += DialogClosed;
        }
    }

    private void DialogClosed(object sender, EventArgs args)
    {
        DialogBox dialogClosed = (DialogBox)sender;
        dialogClosed.dialogClosing -= DialogClosed;
        isDialogOpen = false;
        dialogClosing?.Invoke(this, EventArgs.Empty);
        Destroy(dialogClosed.gameObject);
    }
}
