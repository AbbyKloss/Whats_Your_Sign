using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCSpeaking : MonoBehaviour
{
    public List<string> lines;
    public TextAsset iFile;
    [SerializeField] private TextMeshPro textbox;
    [SerializeField] private string desiredline;
    public bool loopingDialogue = true;
    private int currentLine = 0;
    private string denyLine;


    void Start()
    {
        lines = initLines(iFile);
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
        textbox.text = lines[currentLine];
        Debug.Log(lines[currentLine]);
        int temp = currentLine + 1;
        if (temp >= (lines.Count - 1)) {
            if (loopingDialogue)
                currentLine = (currentLine + lines.Count + 1) % lines.Count;
            else
                currentLine = lines.Count - 1;
        }
        else currentLine = temp;
        // StartCoroutine(clearText());
    }

    public void deny() {
        textbox.text = denyLine;
        StartCoroutine(clearText());
    }

    public void clearBox() {
        textbox.text = "";
    }

    IEnumerator clearText() {
		yield return new WaitForSeconds(3f);
		textbox.text = "";
	}
}

