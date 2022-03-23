using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
   public Item item;
   public Image icon;
   [SerializeField] private int pos;
   [SerializeField] private TextMeshProUGUI textbox;

   void Start() {
        updateItem();
        // Debug.Log("pos: " + pos + "\n(pos - 1 + 7) % 7: " + (pos - 1 + 7) % 7);
   }

    public void updateItem() {
        pos = pos % Inventory.instance.space;
        ClearSlot();
        if (pos < Inventory.instance.items.Count)
            AddItem(Inventory.instance.items[pos]);
        else item = null;
        textbox.text = pos.ToString();
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
       int nextpos = (pos + Inventory.instance.space - 1) % Inventory.instance.space;
       if ((nextpos < Inventory.instance.items.Count) && (Inventory.instance.items[nextpos] != null)) {
           AddItem(Inventory.instance.items[nextpos]);
       }
       pos = nextpos;
       textbox.text = pos.ToString();
    }

    public void rRotate() {
        ClearSlot();
        int nextpos = (pos + Inventory.instance.space + 1) % Inventory.instance.space;
        if ((nextpos < Inventory.instance.items.Count) && (Inventory.instance.items[nextpos] != null)) {
           AddItem(Inventory.instance.items[nextpos]);
        }
        pos = nextpos;
        textbox.text = pos.ToString();
    }
}
