using UnityEngine;

public class InteractablePickup : MonoBehaviour
{
    public KeyCode interactKey = KeyCode.E;
    public GameObject highlightObject;
    public string itemName = "Key";

    private bool playerInRange = false;
    private PlayerInventory playerInventory;

    private void Start()
    {
        if (highlightObject != null)
            highlightObject.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(interactKey))
        {
            PickUp();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            playerInventory = other.GetComponent<PlayerInventory>();

            if (highlightObject != null)
                highlightObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            playerInventory = null;

            if (highlightObject != null)
                highlightObject.SetActive(false);
        }
    }

    private void PickUp()
    {
        if (playerInventory != null)
        {
            bool added = playerInventory.AddItem(itemName);

            if (added)
            {
                Destroy(gameObject);
            }
        }
    }
}