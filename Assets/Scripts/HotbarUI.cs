using UnityEngine;
using TMPro;

public class HotbarUI : MonoBehaviour
{
    public PlayerInventory inventory;
    public TextMeshProUGUI[] slotTexts = new TextMeshProUGUI[9];

    private void Start()
    {
        Debug.Log("HotbarUI Start ran.");

        if (inventory == null)
        {
            inventory = FindAnyObjectByType<PlayerInventory>();
            Debug.Log("Auto-found inventory: " + inventory);
        }

        if (inventory != null)
        {
            inventory.OnInventoryChanged += RefreshHotbar;
            Debug.Log("Subscribed to inventory event.");
            RefreshHotbar();
        }
        else
        {
            Debug.LogError("HotbarUI: No PlayerInventory found.");
        }
    }

    private void OnDestroy()
    {
        if (inventory != null)
        {
            inventory.OnInventoryChanged -= RefreshHotbar;
        }
    }

    public void RefreshHotbar()
    {
        Debug.Log("RefreshHotbar called.");

        if (inventory == null)
        {
            Debug.LogError("HotbarUI: inventory is null.");
            return;
        }

        for (int i = 0; i < slotTexts.Length; i++)
        {
            if (slotTexts[i] == null)
            {
                Debug.LogWarning("slotTexts[" + i + "] is null.");
                continue;
            }

            if (i < inventory.items.Count)
            {
                slotTexts[i].text = inventory.items[i];
                Debug.Log("Set slot " + i + " to " + inventory.items[i]);
            }
            else
            {
                slotTexts[i].text = "";
            }
        }
    }
}