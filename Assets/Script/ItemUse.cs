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
            ItemManager.Instance.UseHealthBottle();

        if (Input.GetMouseButtonDown(0))
            ItemManager.Instance.UseAmmo();
    }
}
