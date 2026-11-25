using UnityEngine;

public class MedBottle : MonoBehaviour
{
    [SerializeField] private int valeur = 1;

    private void OnTriggerEnter2D(Collider2D autre)
    {
        if (!autre.CompareTag("Player"))
            return;

        if (ItemManager.Instance == null)
        {
            Debug.LogError("ItemManager isn't present.");
            return;
        }

        ItemManager.Instance.AddHealthBottle(valeur);
        Destroy(gameObject);
    }
}
