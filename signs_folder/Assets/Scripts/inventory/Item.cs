using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;

    public virtual void Use() {
        // use item
        bool accepted = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerInteract>().Give(this);
        if (accepted) {
            Inventory.instance.Remove(this);
            Debug.Log("Using " + name);
        }
        else
            Debug.Log("Could not use " + name);
    }
}
