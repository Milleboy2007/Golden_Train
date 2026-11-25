using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance { get; private set; }

    [SerializeField]
    private int Med_BottleCollected = 0;
    [SerializeField]
    private int Ammo_Reserve = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {

    }

    public void AddHealth(int valeur)
    {
        Med_BottleCollected += valeur;


        if (Med_BottleCollected > 0)
        {
            // Add health into player HP
            Med_BottleCollected -= valeur;
        }
        else
        {
            Debug.Log($"Health Bottle : {Med_BottleCollected}");
        }
    }

    public void UseHealthBottle()
    {
        
        if (Med_BottleCollected < 1)
        {
            Debug.Log("No Health Bottle");
        }
        else
        {
            Debug.Log("Health Bottle used");
            Med_BottleCollected -= 1;
        }
    }

    public void AddAmmo(int valeur)
    {
        Med_BottleCollected += valeur;

        Debug.Log($"Ammo : {Ammo_Reserve}");

        if (Med_BottleCollected > 0)
        {
            // Add ammo
            Ammo_Reserve += valeur;
        }
    }

    public void UseAmmo()
    {
        Debug.Log("Ammo used");
        if (Ammo_Reserve > 0)
        {
            Ammo_Reserve -= 1;
        }
        else
        {
            Debug.Log("No Ammo");
        }
    }
}
