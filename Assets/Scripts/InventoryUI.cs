using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {

    [Header("UI Bindings")]
    public Image scrollImage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ManageVisibility();
	}

    private void ManageVisibility() {
        scrollImage.gameObject.SetActive(Inventory.Instance.HasFreddyScroll);
    }
}
