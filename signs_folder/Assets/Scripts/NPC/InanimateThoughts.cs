using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InanimateThoughts : MonoBehaviour
{
    public List<string> lines;
    public TextAsset iFile;
    private string desiredline = "[b0]";
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
            temp = line.Split('|');
            foreach (string lin in temp)
                Debug.Log(lin);

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
        if (temp >= (lines.Count - 1)) {
            if (loopingDialogue)
                currentLine = (currentLine + lines.Count + 1) % lines.Count;
            else
                currentLine = lines.Count - 1;
        }
        else currentLine = temp;
    }

    public bool take() {
        return false;
    }
}

