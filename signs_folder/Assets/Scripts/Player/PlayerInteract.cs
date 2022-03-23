using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    private Rigidbody2D RigidBody;
    private Vector3 tempPos;
    private float CharDistance;

    private Vector3 PlayerPos;
    public float PlayerDistance;
    public Transform closest;

    private bool paused;
    public bool check;
    private bool chatting = false;

    private GameObject[] NPCPoints;

    [SerializeField] private float chatDist = 10f;

    // public GameObject SoundGuy;
    // public audio AC;

    // Start is called before the first frame update
    void Start()
    {
        NPCPoints= GameObject.FindGameObjectsWithTag("Talkable");

        paused = false; // temp until i implement a pause menu

        // SoundGuy = GameObject.Find("SoundGuy");
        // AC = SoundGuy.GetComponent<audio>();
    }

    // Update is called once per frame
    void Update()
    {
        // paused = (canvas.GetComponent<PauseMenu>().pubPaused);
        closest = GetClosestNPC(NPCPoints);
        chatting = GetComponent<PlayerController>().talkButton;
        if (!chatting) return;

        DistanceCheck();

        
        if (check && (!paused))
        {
            // something that makes the NPCs cycle through text lines
            // Debug.Log("Attempting to chat...");
            closest.GetComponent<NPCSpeaking>().readLine();
        }

        // DrawLine();
    }

    // private void DrawLine()
    // {
    //     bool facingRight = GetComponent<PlayerMovement>().m_FacingRight;
    //     Vector3 temp = transform.position + new Vector3((facingRight ? 1 : -1) * xOffset, yOffset);
    //     lineRenderer.SetPosition(0, temp);
    //     lineRenderer.SetPosition(1, distanceJoint.connectedAnchor);
    // }

    Transform GetClosestNPC(GameObject[] NPCPoints)
    {
        Transform closest = null;
        float closestDistance = Mathf.Infinity;
        foreach (GameObject NPCPoint in NPCPoints)
        {
            float dist = Vector3.Distance(NPCPoint.transform.position, transform.position);
            if(dist < closestDistance)
            {
                closest = NPCPoint.transform;
                closestDistance = dist;
            }
        }

        return closest;
    }

    private void DistanceCheck()
    {
        check = false;
        PlayerDistance = Vector3.Distance(transform.position, closest.position);
        if (PlayerDistance < chatDist)
            check = true;
    }

    public bool Give(Item item) {
        if (closest == null) return false;
        return closest.GetComponent<NPCTakeItem>().take(item);
    }

    void OnDrawGizmosSelected() {
        if (closest == null) return;
        Gizmos.DrawWireSphere(closest.position, chatDist * 0.85f);
        // Gizmos.DrawWireSphere(closest.position, messing/2);
        // Gizmos.DrawWireSphere(RigidBody.position, messing/2);
    }
}
