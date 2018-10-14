using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool CanFly { get; set; }
    public bool HasFreddyScroll { get; set; }
    public bool CanUseTheForce { get; set; }
    public bool HasSeenDeathStar { get; set; }
    public bool HasSeenVador { get; set; }
    public bool HasVictim { get; set; }
    public bool AllowedToTakeVictim { get; set; }
    public bool HasTakenDeathStar { get; set; }
    public bool DeathStarReturned { get; set; }

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
        if (_instance != null && _instance != this)
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
