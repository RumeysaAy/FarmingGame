using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : SingletonMonobehaviour<InventoryManager>
{
    private Dictionary<int, ItemDetails> itemDetailsDictionary;

    // oyuncunun topladığı nesneler
    public List<InventoryItem>[] inventoryLists; // envanter öğelerini içerir

    // the index of the array is the inventory list (from the InventoryLocation enum), and the value is the capacity of that inventory list
    // dizinin indeksi envanter listesidir ("InventoryLocation enum"dan) ve değer o envanter listesinin kapasitesidir
    [HideInInspector] public int[] inventoryListCapacityIntArray;

    [SerializeField]
    private SO_ItemList itemList = null;

    protected override void Awake()
    {
        base.Awake();

        // Create Inventory Lists
        CreateInventoryLists();

        // Create item details dictionary
        CreateItemDetailsDictionary();
    }

    private void CreateInventoryLists()
    {
        inventoryLists = new List<InventoryItem>[(int)InventoryLocation.count];

        for (int i = 0; i < (int)InventoryLocation.count; i++)
        {
            inventoryLists[i] = new List<InventoryItem>();
        }

        // initialise inventory list capacity array - envanter listesi kapasite dizisini başlat
        inventoryListCapacityIntArray = new int[(int)InventoryLocation.count];

        // initialise player inventory list capacity - oyuncu envanter listesi kapasitesini başlat
        inventoryListCapacityIntArray[(int)InventoryLocation.player] = Settings.playerInitialInventoryCapacity;
    }

    // “itemDetailsDictionary”yi “scriptable object items list” listesinden doldurur
    private void CreateItemDetailsDictionary()
    {
        itemDetailsDictionary = new Dictionary<int, ItemDetails>();

        foreach (ItemDetails itemDetails in itemList.itemDetails)
        {
            itemDetailsDictionary.Add(itemDetails.itemCode, itemDetails);
        }
    }

    // itemCode için itemDetails'ı (SO_ItemList'ten) veya öğe kodu yoksa null değerini döndürür
    public ItemDetails GetItemDetails(int itemCode)
    {
        ItemDetails itemDetails;

        if (itemDetailsDictionary.TryGetValue(itemCode, out itemDetails))
        {
            return itemDetails;
        }
        else
        {
            return null;
        }
    }
}
