using UnityEngine;

public class MedBottle : MonoBehaviour
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

        InventoryManager.Instance.AddHealthBottle(valeur);
        Destroy(gameObject);
    }
}
