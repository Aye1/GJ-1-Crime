using UnityEngine;

public class Scroll : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Inventory.Instance.HasFreddyScroll = true;
        Destroy(this.gameObject);
    }
}
