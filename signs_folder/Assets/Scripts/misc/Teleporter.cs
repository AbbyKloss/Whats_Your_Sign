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

    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.transform.tag == "Player") {
            Debug.Log("Player collided with Teleporter");
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
