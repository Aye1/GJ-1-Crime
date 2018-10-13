using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraScript : MonoBehaviour
{
    public Player player;

    private void Start()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 target = new Vector3(
                player.transform.position.x,
                player.transform.position.y,
                this.transform.position.z);


            // The step size is equal to speed times frame time.
            float step = 10 * Time.deltaTime;

            // Move our position a step closer to the target.
            transform.position = Vector3.MoveTowards(transform.position, target, step);
        }
    }
}
