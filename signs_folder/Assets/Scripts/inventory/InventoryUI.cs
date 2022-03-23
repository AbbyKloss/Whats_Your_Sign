using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    Inventory inventory;

    InventorySlot[] slots;
    
    void Start() {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUI () {
        Debug.Log("Updating UI");
        for (int i = 0; i < slots.Length; i++) {
            if (i < inventory.items.Count) {
                slots[i].AddItem(inventory.items[i]);
            }
            else {
                slots[i].ClearSlot();
            }
        }
    }

    public void imposeLRotate() {
        foreach (InventorySlot slot in slots) {
            slot.lRotate();
        }
    }

    public void imposeRRotate() {
        foreach (InventorySlot slot in slots) {
            slot.rRotate();
        }
    }
}
