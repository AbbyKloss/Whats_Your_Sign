using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InanimateThoughts : MonoBehaviour
{
    public List<string> lines;
    public TextAsset iFile;
    [SerializeField] private string desiredline = "[b0]";
    public bool loopingDialogue = false;
    private int currentLine = 0;
    private string denyLine;
    private PlayerSpeaking playerSpeaker;


    void Start()
    {
        playerSpeaker = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerSpeaking>();
        lines = initLines(iFile);
    }

    private List<string> initLines(TextAsset inputFile, char lineType = 't') {
        var retString = new List<string>();
        var arrayString = inputFile.text.Split('\n');
        string[] temp;

        foreach (var line in arrayString) {
            if (line.Length <= 0) continue;
            else if (line[0] == '#') continue;
            temp = line.Split('|');
            // foreach (string lin in temp)
                // Debug.Log(lin);

            if ((temp[0] == desiredline) && (temp[1][1] == lineType))
                retString.Add(temp[2]);
            else if ((temp[0] == desiredline) && (temp[1][1] == 'd'))
                denyLine = temp[2];
        }

        return retString;
    }

    public void updateLines(char lineType) {
        currentLine = 0;
        lines = initLines(iFile, lineType);
        readLine();
    }

    public void readLine() {
        playerSpeaker.customLine(lines[currentLine]);
        // Debug.Log(lines[currentLine]);
        int temp = currentLine + 1;
        if (temp > lines.Count) {
            if (loopingDialogue)
                currentLine = (currentLine + lines.Count + 1) % lines.Count;
            else
                currentLine = lines.Count - 1;
        }
        else currentLine = temp;
        Debug.Log("currentLine changed" + currentLine);
    }

    public void resetCounter() {
        currentLine = 0;
    }

    public bool take() {
        return false;
    }
}

