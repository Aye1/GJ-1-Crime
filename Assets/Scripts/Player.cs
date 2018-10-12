using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    List<IInteractable> currentInteractablesList = new List<IInteractable>();

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        IInteractable otherObj = collision.gameObject.GetComponent<IInteractable>();
        if (otherObj != null)
        {
            currentInteractablesList.Add(otherObj);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        IInteractable otherObj = collision.gameObject.GetComponent<IInteractable>();
        if (otherObj != null)
        {
            currentInteractablesList.Remove(otherObj);
        }
    }
}
