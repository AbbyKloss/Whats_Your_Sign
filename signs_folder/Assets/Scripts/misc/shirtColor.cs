using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shirtColor : MonoBehaviour
{
    private Renderer rend;
    [SerializeField] private Color colorToTurnTo = Color.white;
    // Start is called before the first frame update
    void Start()
    {
     rend = GetComponent<Renderer>();   
     rend.material.color = colorToTurnTo;
    }
}
