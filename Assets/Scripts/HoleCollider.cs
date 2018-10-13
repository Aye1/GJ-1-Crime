using UnityEngine;
using UnityEngine.SceneManagement;

public class HoleCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Escalier"))
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                // go to Dracula
                SceneManager.LoadScene(1);
                this.transform.parent.transform.position = new Vector3(-3.4f, 10, -2);
            }
            else
            {
                // go to Main
                SceneManager.LoadScene(0);
                this.transform.parent.transform.position = new Vector3(13, 13, -2);
            }
        }
    }
}
