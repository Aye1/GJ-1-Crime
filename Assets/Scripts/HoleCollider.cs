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
                SceneManager.LoadScene(1);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
