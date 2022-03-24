using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTakeItem : MonoBehaviour
{
    [SerializeField] private string desiredItem = "Talisman1";
    [SerializeField] private NPCSpeaking speaky;
    public bool take(Item item) {
        bool fulfilled = item.name == desiredItem;
        if (fulfilled) {
            speaky.updateLines('t');
            speaky.loopingDialogue = false;
        }
        else
            speaky.deny(item.name);
        return fulfilled;
    }
}
