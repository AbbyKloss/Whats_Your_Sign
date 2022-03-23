using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    // public Animator animator;
    // public GameObject SoundGuy;
    // public audio AC;

    public PlayerMovement controller;

    public float horizSpeed = 2.0f;
    public float vertiSpeed = 1.5f;

    float horizMov = 0f;
    float vertiMov = 0f;
    public bool talkButton = false;

    // void Start()
    // {
    //     SoundGuy = GameObject.Find("SoundGuy");
    //     AC = SoundGuy.GetComponent<audio>();
    // }
   

    void Update() {
        horizMov = Input.GetAxisRaw("Horizontal") * horizSpeed;
        vertiMov = Input.GetAxisRaw("Vertical")   * vertiSpeed;
        talkButton  = Input.GetKeyDown("e");
        // if (clicked) {
        //     // Debug.Log("Clicked! (" + Time.time + ")");
        // }

        // animator.SetFloat("Speed", Mathf.Abs(horizMov)); // normalized vector of horizMov and vertiMov?
        
        // keeping all of these because maybe i'll add sound effects later
        // if (Input.GetButtonDown("Jump")) {
        //     AC.PlaySound("JumpSound");
        //     jump = true;
        // }
        // if (Input.GetMouseButtonDown(1)) {
        //     AC.PlaySound("KickSound");
        //     attack = true;
        // }
    }

    void FixedUpdate() {
        controller.Move(horizMov, vertiMov);
    }
}
