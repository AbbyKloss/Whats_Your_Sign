using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
   Item item;
   public Image icon;
   [SerializeField] private int pos;

   void Start() {
        updateItem();
        // Debug.Log("pos: " + pos + "\n(pos - 1 + 7) % 7: " + (pos - 1 + 7) % 7);
   }

    public void updateItem() {
        if (pos < Inventory.instance.items.Count)
            AddItem(Inventory.instance.items[pos]);
    }

    public void AddItem (Item newItem) {
       item = newItem;
       icon.sprite = item.icon;
       icon.enabled = true;
    }

    public void ClearSlot () {
       item = null;
       icon.sprite = null;
       icon.enabled = false;
    }

    public void OnRemoveButton() {
       Inventory.instance.Remove(item);
    }

    public void UseItem() {
       if (item != null)
        item.Use();
    }

    public void lRotate() {
       ClearSlot();
       int nextpos = (pos + Inventory.instance.space + 1) % Inventory.instance.space;
       if ((nextpos < Inventory.instance.items.Count) && (Inventory.instance.items[nextpos] != null)) {
           AddItem(Inventory.instance.items[nextpos]);
       }
       pos = nextpos;
    }

    public void rRotate() {
        ClearSlot();
        int nextpos = (pos + Inventory.instance.space - 1) % Inventory.instance.space;
        if ((nextpos < Inventory.instance.items.Count) && (Inventory.instance.items[nextpos] != null)) {
           AddItem(Inventory.instance.items[nextpos]);
        }
        pos = nextpos;
    }
}
