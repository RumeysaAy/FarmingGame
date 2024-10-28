// nesnelere bileşen olarak verebilmek için
using UnityEngine;

[System.Serializable]
public class ItemDetails
{
    public int itemCode;
    public ItemType itemType;
    public string itemDescription;
    public Sprite itemSprite;
    public string itemLongDescription;
    public short itemUseGridRadius;
    public float itemUseRadius;
    public bool isStartingItem;
    // bir öğenin seçilip seçilemeyeceğini belirleyecek
    public bool canBePickedUp;
    // bir öğenin düşürülüp düşürülemeyeceği, oyuncunun eline aldığı aletlerin bırakılamayacağına
    public bool canBeDropped;
    public bool canBeEaten;
    // taşınabilir mi?
    public bool canBeCarried;
}
