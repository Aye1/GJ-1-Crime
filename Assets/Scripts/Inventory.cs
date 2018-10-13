using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool CanFly { get; set; }

    private static Inventory _instance;
    public static Inventory Instance
    {
        get
        {
            return _instance;
        }
    }

    // Use this for initialization
    void Start()
    {
        if(_instance !=null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
