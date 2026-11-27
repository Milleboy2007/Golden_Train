using UnityEngine;

public class Ammobox : MonoBehaviour
{
    [SerializeField] private int valeur = 1;

    private void OnTriggerEnter(Collider autre)
    {
        if (!autre.CompareTag("Player"))
            return;

        if (InventoryManager.Instance == null)
        {
            Debug.LogError("InventoryManager isn't present.");
            return;
        }

        InventoryManager.Instance.AddAmmo(valeur);
        Destroy(gameObject);
    }
}
