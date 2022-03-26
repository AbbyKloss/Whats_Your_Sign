using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChange : MonoBehaviour
{
    private int currentScene;
    private int totalScenes;
    private int nextScene;
    private string thought;
    private AudioSource AC;
    [SerializeField] AudioClip DoorOpen;

    void Start() {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        totalScenes = SceneManager.sceneCountInBuildSettings;
        nextScene = (currentScene + 1) % totalScenes;
        thought = "i still have some talismans, i should hand them out";
        AC = GameObject.Find("SoundGuy").GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.transform.tag == "Player") {
            if (Inventory.instance.items.Count == 0){
                AC.PlayOneShot(DoorOpen, 0.3f);
                SceneManager.LoadScene(nextScene);
            }
            else {
                collision.GetComponent<PlayerSpeaking>().customLine(thought, true);
            }
        }
    }
}
