using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteract : MonoBehaviour
{

    private Rigidbody2D RigidBody;
    private Vector3 tempPos;
    private float CharDistance;
    private Vector3 PlayerPos;
    public float PlayerDistance;
    public Transform closestTalk;
    private GameObject[] NPCPoints;
    public Transform closestBlock;
    private GameObject[] ThinkPoints;

    private bool paused;
    public bool talkCheck;
    public bool pastTalkCheck;
    public bool thinkCheck;
    public bool pastThinkCheck;
    private bool chatting = false;

    [SerializeField] private TextMeshPro textbox;
    private PlayerSpeaking selfSpeak;

    [SerializeField] private float chatDist = 10f;

    // public GameObject SoundGuy;
    // public audio AC;

    // Start is called before the first frame update
    void Start()
    {
        NPCPoints= GameObject.FindGameObjectsWithTag("Talkable");
        ThinkPoints= GameObject.FindGameObjectsWithTag("Thinkable");
        selfSpeak = GetComponent<PlayerSpeaking>();
        paused = false; // temp until i implement a pause menu

        // SoundGuy = GameObject.Find("SoundGuy");
        // AC = SoundGuy.GetComponent<audio>();
    }

    // Update is called once per frame
    void Update()
    {
        // paused = (canvas.GetComponent<PauseMenu>().pubPaused);
        closestTalk = GetClosestNPC(NPCPoints);
        closestBlock = GetClosestNPC(ThinkPoints);
        chatting = GetComponent<PlayerController>().talkButton;

        pastTalkCheck = talkCheck;
        pastThinkCheck = thinkCheck;

        talkCheck = DistanceCheck(closestTalk);
        thinkCheck = DistanceCheck(closestBlock);

        if (chatting && (!paused))
        {
            if (talkCheck) {
                // something that makes the NPCs cycle through text lines
                // Debug.Log("Attempting to chat...");
                closestTalk.GetComponent<NPCSpeaking>().readLine();
            }
            else if (thinkCheck) {
                closestBlock.GetComponent<InanimateThoughts>().readLine();
            }
            else {
            selfSpeak.self();
            }
        }
        if (pastTalkCheck && (pastTalkCheck != talkCheck) && !paused) {
            selfSpeak.clearBox();
            closestTalk.GetComponent<NPCSpeaking>().clearBox();
        }
        if (pastThinkCheck && (pastThinkCheck != thinkCheck) && !paused) {
            selfSpeak.clearBox();
        }

    }

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

    private bool DistanceCheck(Transform closestObj)
    {
        bool tempcheck = false;
        PlayerDistance = Vector3.Distance(transform.position, closestObj.position);
        if (PlayerDistance < chatDist)
            tempcheck = true;
        return tempcheck;
    }

    public bool Give(Item item) {
        if (closestTalk == null) return false;
        else if (!talkCheck) {
            selfSpeak.deny();
            return false;
        }
        return closestTalk.GetComponent<NPCTakeItem>().take(item);
    }

    void OnDrawGizmosSelected() {
        if ((closestTalk == null) || (closestBlock == null)) return;
        Gizmos.DrawWireSphere(closestTalk.position, chatDist * 0.85f);
        Gizmos.DrawWireSphere(closestBlock.position, chatDist * 0.85f);
    }
}
