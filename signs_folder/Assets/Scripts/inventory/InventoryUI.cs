using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    Inventory inventory;

    InventorySlot[] slots;
    private AudioSource AC;
    [SerializeField] AudioClip Click;
    
    void Start() {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
        AC = GameObject.Find("SoundGuy").GetComponent<AudioSource>();
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUI () {
        Debug.Log("Updating UI");
        for (int i = 0; i < slots.Length; i++) {
            slots[i].updateItem();
        }
    }

    public void imposeLRotate() {
        AC.PlayOneShot(Click, 0.5f);
        foreach (InventorySlot slot in slots) {
            slot.lRotate();
        }
    }

    public void imposeRRotate() {
        AC.PlayOneShot(Click, 0.5f);
        foreach (InventorySlot slot in slots) {
            slot.rRotate();
        }
    }
}
