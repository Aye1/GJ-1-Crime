using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInteractionZone : MonoBehaviour
{
    Collider2D triggerCollider;
    public List<IInteractable> CurrentInteractablesList { get; private set; }

    // Use this for initialization
    void Start()
    {
        triggerCollider = GetComponents<Collider2D>().First(col => col.isTrigger);
        CurrentInteractablesList = new List<IInteractable>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        IInteractable otherObj = collision.gameObject.GetComponent<IInteractable>();
        if (otherObj != null)
        {
            CurrentInteractablesList.Add(otherObj);
        }
        else { return; }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        IInteractable otherObj = collision.gameObject.GetComponent<IInteractable>();
        if (otherObj != null)
        {
            CurrentInteractablesList.Remove(otherObj);
        }
    }
}
