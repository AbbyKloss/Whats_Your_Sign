using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerSpeaking : MonoBehaviour
{
    public List<string> selfLines;
    public List<string> denyLines;
    public TextAsset iFile;
    [SerializeField] private TextMeshPro textbox;
    private string desiredline = "[p0]";

    private int pastLine;
    private int currentLine = 0;
    private string denyLine;


    void Start()
    {
        selfLines = initLines(iFile, 's');
        denyLines = initLines(iFile, 'd');
        textbox.text = "";
    }

    private List<string> initLines(TextAsset inputFile, char lineType = 'l') {
        var retString = new List<string>();
        var arrayString = inputFile.text.Split('\n');
        string[] temp;

        foreach (var line in arrayString) {
            temp = line.Split('|');
            // foreach (string lin in temp)
            //     Debug.Log(lin);

            if ((temp[0] == desiredline) && (temp[1][1] == lineType))
                retString.Add(temp[2]);
        }
        return retString;
    }

    public void updateLines(char lineType) {
        currentLine = 0;
        selfLines = initLines(iFile, lineType);
        readLine();
    }

    public void readLine() {
        textbox.text = selfLines[currentLine];
        // Debug.Log(selfLines[currentLine]);
        int temp = currentLine + 1;
        if (temp >= (selfLines.Count - 1)) {
            currentLine = (currentLine + selfLines.Count + 1) % selfLines.Count;
        }
        else currentLine = temp;
        // StartCoroutine(clearText());
    }

    public void deny() {
        int randInt = Random.Range(0, denyLines.Count);
        textbox.text = denyLines[randInt];
        StartCoroutine(clearText());
    }

    public void self() {
        int randInt = Random.Range(0, selfLines.Count);
        textbox.text = selfLines[randInt];
        StartCoroutine(clearText());
    }

    // for thoughts around certain objects, probably
    // we're thinking ahead, but not _too_ far ahead
    public void customLine(string input) {
        textbox.text = input;
        Debug.Log("Speaking: " + input);
        // StartCoroutine(clearText());
    }

    public void clearBox() {
        textbox.text = "";
    }

    IEnumerator clearText() {
		yield return new WaitForSeconds(3f);
		textbox.text = "";
	}
}
