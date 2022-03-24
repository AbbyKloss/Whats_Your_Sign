using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCSpeaking : MonoBehaviour
{
    public List<string> lines;
    private List<string> denyLines;
    public TextAsset iFile;
    [SerializeField] private TextMeshPro textbox;
    [SerializeField] private string desiredline;
    public bool loopingDialogue = true;
    private int currentLine = 0;
    [SerializeField] private string specialDeny = "";
    private PlayerSpeaking playerSpeaker;



    void Start()
    {
        lines = initLines(iFile);
        denyLines = initLines(iFile, 'd');
        textbox.text = "";
        playerSpeaker = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerSpeaking>();
    }

    private List<string> initLines(TextAsset inputFile, char lineType = 'l') {
        var retString = new List<string>();
        var arrayString = inputFile.text.Split('\n');
        string[] temp;
        string strong;

        foreach (var line in arrayString) {
            if (line.Length <= 0) continue;
            else if (line[0] == '#') continue;
            temp = line.Split('|');
            strong = temp[1] + "|" + temp[2];
            // Debug.Log(line);
            // foreach (string lin in temp)
            //     Debug.Log(lin);

            if ((temp[0] == desiredline) && (temp[1][1] == lineType)) {
                retString.Add(strong);
                Debug.Log(strong);
            }
        }

        return retString;
    }

    public void updateLines(char lineType) {
        currentLine = 0;
        lines = initLines(iFile, lineType);
        readLine();
    }

    public void readLine() {
        string[] split = lines[currentLine].Split('|');
        if (split[0][2] == 'n')
            textbox.text = split[1];
        else if (split[0][2] == 'p')
            playerSpeaker.customLine(split[1]);
        // Debug.Log(lines[currentLine][1]);
        int temp = currentLine + 1;
        if (temp >= (lines.Count - 1)) {
            if (loopingDialogue)
                currentLine = (currentLine + lines.Count + 1) % lines.Count;
            else
                currentLine = lines.Count - 1;
        }
        else currentLine = temp;
    }

    public void deny(string itemName = "Talisman1") {
        if (itemName == specialDeny) {
            textbox.text = denyLines[1].Split('|')[1];
        }
        else
            textbox.text = denyLines[0].Split('|')[1];
    }

    public void clearBox() {
        textbox.text = "";
    }

    IEnumerator clearText() {
		yield return new WaitForSeconds(3f);
		textbox.text = "";
	}
}

