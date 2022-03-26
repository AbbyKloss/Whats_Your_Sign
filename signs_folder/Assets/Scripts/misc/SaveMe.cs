using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveMe : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake() {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        Debug.Log(objs.Length);
        if (objs.Length > 1) 
            Destroy(gameObject);
        else
            DontDestroyOnLoad(this);
    }
}
