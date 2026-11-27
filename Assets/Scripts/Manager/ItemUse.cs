using UnityEngine;
using UnityEngine.InputSystem;

public class ItemUse : MonoBehaviour
{

    private void Update()
    {
        UseItem();
    }

    private void UseItem()
    {
        if (Input.GetKeyDown("e"))
            InventoryManager.Instance.UseHealthBottle();

        if (Input.GetMouseButtonDown(0))
            InventoryManager.Instance.UseAmmo();
    }
}
