using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int maxSlots = 9;
    public List<string> items = new List<string>();

    public Action OnInventoryChanged;

    public bool AddItem(string itemName)
    {
        if (items.Count >= maxSlots)
        {
            Debug.Log("Inventory full");
            return false;
        }

        items.Add(itemName);
        Debug.Log("Added item: " + itemName);

        OnInventoryChanged?.Invoke();
        return true;
    }

    public bool HasItem(string itemName)
    {
        return items.Contains(itemName);
    }

    public void RemoveItem(string itemName)
    {
        if (items.Remove(itemName))
        {
            Debug.Log("Removed item: " + itemName);
            OnInventoryChanged?.Invoke();
        }
    }
}