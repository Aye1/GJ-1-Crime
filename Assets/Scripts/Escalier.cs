using UnityEngine;
using UnityEngine.SceneManagement;

public class Escalier : MonoBehaviour
{
    public Vector3 exitPosition;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
        GameManager.Instance.shouldTeleportToStairs = true;
    }
}
