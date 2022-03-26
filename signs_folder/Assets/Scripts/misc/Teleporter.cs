using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.CoreModule;

public class Teleporter : MonoBehaviour
{
    private CameraFollow camera;
    private GameObject player;
    [SerializeField] private float xCameraPos;
    [SerializeField] private float yCameraPos;
    [SerializeField] private int mode;
    [SerializeField] private float xPlayerPos;
    [SerializeField] private float yPlayerPos;
    private Vector3 position;
    private AudioSource AC;
    [SerializeField] AudioClip DoorOpen;

    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
        player = GameObject.FindGameObjectWithTag("Player");
        AC = GameObject.Find("SoundGuy").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.transform.tag == "Player") {
            Debug.Log("Player collided with Teleporter");
            AC.PlayOneShot(DoorOpen, 0.3f);
            Quaternion tempQ = player.transform.localRotation;
            Vector3 tempVec = new Vector3(xPlayerPos, yPlayerPos, player.transform.position.z);
            player.transform.SetPositionAndRotation(tempVec, tempQ);
            if (mode == 1)
                camera.toModeOne(xCameraPos, yCameraPos);
            else if (mode == 0)
                camera.toModeZero();
        }
    }
}
