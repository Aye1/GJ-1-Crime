using UnityEngine;
using Random = System.Random;

public class DancefloorTile : MonoBehaviour
{
    [Header("Readonly")]
    public SpriteRenderer haloLight;
    public bool isLightOn = false;
    private Random random;

    // Use this for initialization
    void Start()
    {
        random = new Random();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ManageLight(Color color)
    {
        SwitchLight(random.NextDouble() <= 0.8f, color);
    }

    private void SwitchLight(bool on, Color color)
    {
        if (on)
        {
            LightOn(color);
        }
        else
        {
            LightOff();
        }
    }

    private void LightOn(Color color)
    {
        haloLight.gameObject.SetActive(true);
        haloLight.color = color;
        GetComponent<SpriteRenderer>().color = color;
    }

    private void LightOff()
    {
        //haloLight.gameObject.SetActive(false);
    }
}
