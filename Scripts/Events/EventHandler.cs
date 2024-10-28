using System;
using System.Collections.Generic;
using UnityEngine;

public delegate void MovementDelegate(float inputX, float inputY,
 bool isWalking, bool isRunning,
  bool isIdle, bool isCarrying, // boşta duruyor mu?, oyuncu bir şey taşıyor mu?
   ToolEffect toolEffect,
    bool isUsingToolRight, bool isUsingToolLeft, bool isUsingToolUp, bool isUsingToolDown, // hangi yönde araç kullanıyor?
    bool isLiftingToolRight, bool isLiftingToolLeft, bool isLiftingToolUp, bool isLiftingToolDown, // bir aletin kaldırılıp kaldırılmadığı
    bool isPickingRight, bool isPickingLeft, bool isPickingUp, bool isPickingDown, // bir şeyler aldı mı?
    bool isSwingingToolRight, bool isSwingingToolLeft, bool isSwingingToolUp, bool isSwingingToolDown, // bir aletin sallanıp sallanmadığı
    bool idleUp, bool idleDown, bool idleLeft, bool idleRight); // hangi yönde boşta duruyor?

public static class EventHandler
{
    // Inventory Updated Event
    public static event Action<InventoryLocation, List<InventoryItem>> InventoryUpdatedEvent;

    public static void CallInventoryUpdatedEvent(InventoryLocation inventoryLocation, List<InventoryItem> inventoryList)
    {
        if (InventoryUpdatedEvent != null)
        {
            InventoryUpdatedEvent(inventoryLocation, inventoryList);
        }
    }

    // Movement Event
    public static event MovementDelegate MovementEvent;

    // Movement Event Call For Publishers - Yayıncılara Hareket Olayı Çağrısı
    public static void CallMovementEvent(float inputX, float inputY, bool isWalking, bool isRunning, bool isIdle, bool isCarrying, ToolEffect toolEffect,
    bool isUsingToolRight, bool isUsingToolLeft, bool isUsingToolUp, bool isUsingToolDown,
    bool isLiftingToolRight, bool isLiftingToolLeft, bool isLiftingToolUp, bool isLiftingToolDown,
    bool isPickingRight, bool isPickingLeft, bool isPickingUp, bool isPickingDown,
    bool isSwingingToolRight, bool isSwingingToolLeft, bool isSwingingToolUp, bool isSwingingToolDown,
    bool idleUp, bool idleDown, bool idleLeft, bool idleRight)
    {
        if (MovementEvent != null)
            MovementEvent(inputX, inputY,
                isWalking, isRunning, isIdle, isCarrying,
                toolEffect,
                isUsingToolRight, isUsingToolLeft, isUsingToolUp, isUsingToolDown,
                isLiftingToolRight, isLiftingToolLeft, isLiftingToolUp, isLiftingToolDown,
                isPickingRight, isPickingLeft, isPickingUp, isPickingDown,
                isSwingingToolRight, isSwingingToolLeft, isSwingingToolUp, isSwingingToolDown,
                idleUp, idleDown, idleLeft, idleRight);
    }
}