using UnityEngine;
using UnityEngine.InputSystem;

public class InteractablePickup : MonoBehaviour
{
    public string itemName = "Key";
    public GameObject highlightObject;

    private bool playerInRange = false;
    private PlayerInventory playerInventory;

    private void Start()
    {
    }

    private void Update()
    {
        if (playerInRange && Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            PickUp();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory inv = other.GetComponentInParent<PlayerInventory>();

        if (inv != null)
        {
            playerInRange = true;
            playerInventory = inv;

            if (highlightObject != null)
                highlightObject.SetActive(true);

            Debug.Log("Player entered pickup range");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerInventory inv = other.GetComponentInParent<PlayerInventory>();

        if (inv != null)
        {
            playerInRange = false;
            playerInventory = null;

            if (highlightObject != null)
                highlightObject.SetActive(false);

            Debug.Log("Player left pickup range");
        }
    }

    private void PickUp()
    {
        if (playerInventory == null)
        {
            Debug.LogWarning("No player inventory found");
            return;
        }

        bool added = playerInventory.AddItem(itemName);

        if (added)
        {
            Debug.Log("Picked up " + itemName);
            Destroy(gameObject);
        }
    }
}