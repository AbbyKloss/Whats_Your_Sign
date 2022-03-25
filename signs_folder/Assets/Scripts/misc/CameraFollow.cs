using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using System.Math;

public class CameraFollow : MonoBehaviour
{
    private Transform playerTransform;

    [SerializeField] private bool FollowX = true;
    [SerializeField] private bool FollowY = true;
    [SerializeField] private float XOffset;
    [SerializeField] private float YOffset;
    [SerializeField] private float XPadding = 5.0f;
    [SerializeField] private float YPadding = 5.0f;
    [SerializeField] private float yTopLimit = 0.0f;
    [SerializeField] private float yBottomLimit = 0.0f;
    [SerializeField] private float xLeftLimit = 0.0f;
    [SerializeField] private float xRightLimit = 0.0f;

    void Start() {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate() {
        Vector3 temp = transform.position;
        bool leftTest   = playerTransform.position.x > xLeftLimit;
        bool rightTest  = playerTransform.position.x < xRightLimit;
        bool topTest    = playerTransform.position.y < yTopLimit;
        bool bottomTest = playerTransform.position.y > yBottomLimit;

        

        if (FollowX) {
            // if (System.Math.Abs(playerTransform.position.x) > System.Math.Abs(temp.x) + XPadding) {
            // }
            if ((xLeftLimit != 0.0f) && (leftTest && rightTest)) {
                temp.x = playerTransform.position.x;
                temp.x += XOffset;
            }
            else if (xLeftLimit == 0.0f) {
                temp.x = playerTransform.position.x;
                temp.x += XOffset;
            }
        }
        if (FollowY) {
            // if (System.Math.Abs(playerTransform.position.y) > System.Math.Abs(temp.y) + YPadding) {
            // }
            if ((yBottomLimit != 0.0f) && (bottomTest && topTest)) {
                temp.y = playerTransform.position.y;
                temp.y += YOffset;
            }
            else if (yBottomLimit == 0.0f) {
                temp.y = playerTransform.position.y;
                temp.y += YOffset;
            }
        }

        transform.position = temp;
    }
}
