using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
   public Item item;
   public Image icon;
   [SerializeField] private int pos;
   [SerializeField] private TextMeshProUGUI slotIterator;
   [SerializeField] private TextMeshProUGUI itemDescriptor;

   void Start() {
        updateItem();
        ClearDescriptor();
        // Debug.Log("pos: " + pos + "\n(pos - 1 + 7) % 7: " + (pos - 1 + 7) % 7);
   }

    public void updateItem() {
        pos = pos % Inventory.instance.space;
        ClearSlot();
        if (pos < Inventory.instance.items.Count)
            AddItem(Inventory.instance.items[pos]);
        else item = null;
        slotIterator.text = (pos + 1).ToString();
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
       slotIterator.text = (pos + 1).ToString();
    }

    public void rRotate() {
        ClearSlot();
        int nextpos = (pos + Inventory.instance.space + 1) % Inventory.instance.space;
        if ((nextpos < Inventory.instance.items.Count) && (Inventory.instance.items[nextpos] != null)) {
           AddItem(Inventory.instance.items[nextpos]);
        }
        pos = nextpos;
        slotIterator.text = (pos + 1).ToString();
    }

   public void updateDescriptor() {
      if (item == null) return;
      string temp = "";
      switch (item.name) {
         case "Talisman1":
            temp = "Nameof\nTalisman\n(The Water-bearer)";
            goto default;
         case "AriesTalisman":
            temp = "Aries\nTalisman\n(The Ram)";
            goto default;
         case "TaurusTalisman":
            temp = "Taurus\nTalisman\n(The Bull)";
            goto default;
         case "GeminiTalisman":
            temp = "Gemini\nTalisman\n(The Twins)";
            goto default;
         case "CancerTalisman":
            temp = "Cancer\nTalisman\n(The Crab)";
            goto default;
         case "LeoTalisman":
            temp = "Leo\nTalisman\n(The Lion)";
            goto default;
         case "VirgoTalisman":
            temp = "Virgo\nTalisman\n(The Maiden)";
            goto default;
         case "LibraTalisman":
            temp = "Libra\nTalisman\n(The Scales)";
            goto default;
         case "ScorpioTalisman":
            temp = "Scorpio\nTalisman\n(The Scorpion)";
            goto default;
         case "SaggitariusTalisman":
            temp = "Saggitarius\nTalisman\n(The Archer)";
            goto default;
         case "CapricornTalisman":
            temp = "Capricorn\nTalisman\n(The Goat)";
            goto default;
         case "AquariusTalisman":
            temp = "Aquarius\nTalisman\n(The Water-bearer)";
            goto default;
         case "PiscesTalisman":
            temp = "Pisces\nTalisman\n(The Fish)";
            goto default;
         default:
            itemDescriptor.text = temp;
            break;
      }
   }

   public void ClearDescriptor() {
      itemDescriptor.text = "";
   }
}
