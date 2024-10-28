using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[CustomPropertyDrawer(typeof(ItemCodeDescriptionAttribute))]
public class ItemCodeDescriptionDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        // change the returned property height to be double to cater for the additional item code description that we will draw
        // çizeceğimiz ek ürün kodu açıklamasına uyum sağlamak için döndürülen özellik yüksekliğini iki katına çıkarın
        return EditorGUI.GetPropertyHeight(property) * 2;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Ana özellikte BeginProperty / EndProperty kullanılması, önceden hazırlanmış geçersiz kılma mantığının tüm özellikte çalışması anlamına gelir.
        EditorGUI.BeginProperty(position, label, property);

        if (property.propertyType == SerializedPropertyType.Integer)
        {
            // editördeki değişiklikleri veya değerleri tespit edip bunları uygulayabilmesidir.
            // değişen değerleri kontrol et
            EditorGUI.BeginChangeCheck(); // Değiştirilen değer için kontrolün başlangıcı

            // Draw item code
            var newValue = EditorGUI.IntField(new Rect(position.x, position.y, position.width, position.height / 2), label, property.intValue);

            // Draw item description
            EditorGUI.LabelField(new Rect(position.x, position.y + position.height / 2, position.width, position.height / 2), "Item Description", GetItemDescription(property.intValue));

            // If item code value has changed, then set value to new value
            if (EditorGUI.EndChangeCheck()) // değişiklik kontrolü
            {
                // özelliği yeni değere eşitle
                property.intValue = newValue;
            }
        }

        EditorGUI.EndProperty();
    }

    private string GetItemDescription(int itemCode)
    {
        // itemCode(intValue)'a göre itemDescription bulunacak
        SO_ItemList so_itemList;

        so_itemList = AssetDatabase.LoadAssetAtPath("Assets/Scriptable Object Assets/Item/so_ItemList.asset", typeof(SO_ItemList)) as SO_ItemList;

        List<ItemDetails> itemDetailsList = so_itemList.itemDetails;

        ItemDetails itemDetail = itemDetailsList.Find(x => x.itemCode == itemCode);

        if (itemDetail != null)
        {
            return itemDetail.itemDescription;
        }
        else
        {
            return "";
        }
    }
}
