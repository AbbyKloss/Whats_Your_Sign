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
    private float xVal = 0.0f;
    private float yVal = 0.0f;
    private int mode = 0;

    void Start() {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate() {
        Vector3 temp = transform.position;
        
        if (mode == 0)
            temp = modeZero();
        else if (mode == 1)
            temp = modeOne();
        transform.position = temp;
    }

    Vector3 modeZero() {
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
        return temp;
    }

    private Vector3 modeOne() {
        Vector3 temp = transform.position;
        temp.y = yVal;
        temp.x = xVal;
        return temp;
    }

    public void toModeZero() {
        xVal = 0.0f;
        yVal = 0.0f;
        mode = 0;
    }

    public void toModeOne(float xValIn, float yValIn) {
        xVal = xValIn;
        yVal = yValIn;
        mode = 1;
    }
}
