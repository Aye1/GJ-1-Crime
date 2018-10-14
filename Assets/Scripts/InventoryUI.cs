using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {

    [Header("UI Bindings")]
    public Image scrollImage;
    public Image wingsImage;
    public Image forceImage;
    public Image bodyImage;
    public Image deathStarImage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ManageVisibility();
	}

    private void ManageVisibility() {
        scrollImage.gameObject.SetActive(Inventory.Instance.HasFreddyScroll);
        wingsImage.gameObject.SetActive(Inventory.Instance.CanFly);
        forceImage.gameObject.SetActive(Inventory.Instance.CanUseTheForce);
        bodyImage.gameObject.SetActive(Inventory.Instance.HasVictim);
        deathStarImage.gameObject.SetActive(Inventory.Instance.HasTakenDeathStar);
    }
}
