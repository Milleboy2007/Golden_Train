using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    [SerializeField]
    private int med_BottleCollected = 0;
    [SerializeField]
    private int ammo_Reserve = 0;

    private PlayerHealth playerHealth;

    private void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
    public void AddHealthBottle(int valeur)
    {
        med_BottleCollected += valeur;
        Debug.Log($"Health Bottle : {med_BottleCollected}");

    }

    public void UseHealthBottle()
    {
        
        if (med_BottleCollected < 1)
        {
            Debug.Log("No Health Bottle");
        }
        else
        {
            Debug.Log("Health Bottle used");
            playerHealth.AddHealth(25);
            med_BottleCollected -= 1;
        }
    }

    public void AddAmmo(int valeur)
    {
        ammo_Reserve += valeur;
        Debug.Log($"Ammo : {ammo_Reserve}");
    }

    public void UseAmmo()
    {
        if (ammo_Reserve > 0)
        {
            ammo_Reserve -= 1;
            Debug.Log("Ammo used");
        }
        else
        {
            Debug.Log("No Ammo");
        }
    }
}
