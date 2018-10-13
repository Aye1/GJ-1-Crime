using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Character : MonoBehaviour, IInteractable {

    public Sprite picture;
    public string characterName;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Interact()
    {
        DialogManager.Instance.StartDialog(GetDialogLines());
    }

    protected abstract DialogLine[] GetDialogLines();
}
