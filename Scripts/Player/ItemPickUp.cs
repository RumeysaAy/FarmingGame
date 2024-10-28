using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // oyuncunun çarptığı öğenin Item bileşenini aldım
        Item item = other.GetComponent<Item>();

        if (item != null)
        {
            // Get item details
            ItemDetails itemDetails = InventoryManager.Instance.GetItemDetails(item.ItemCode);

            Debug.Log(itemDetails.itemDescription);
        }
    }

}
