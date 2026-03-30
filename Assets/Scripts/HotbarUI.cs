using UnityEngine;
using TMPro;

public class HotbarUI : MonoBehaviour
{
    public PlayerInventory inventory;
    public TextMeshProUGUI[] slotTexts = new TextMeshProUGUI[9];

    private void Start()
    {
        if (inventory != null)
        {
            inventory.OnInventoryChanged += RefreshHotbar;
        }

        RefreshHotbar();
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
        for (int i = 0; i < slotTexts.Length; i++)
        {
            if (i < inventory.items.Count)
                slotTexts[i].text = inventory.items[i];
            else
                slotTexts[i].text = "";
        }
    }
}