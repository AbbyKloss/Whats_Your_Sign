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
    private int currentLine;


    void Start()
    {
        lines = initLines(iFile);
        textbox.text = "";
    }

    private List<string> initLines(TextAsset inputFile, string desiredLines="[s0]") {
        var retString = new List<string>();
        var arrayString = inputFile.text.Split('\n');
        string[] temp;

        foreach (var line in arrayString) {
            temp = line.Split('|');

            if (temp[0] == desiredLines)
                retString.Add(temp[2]);
        }

        return retString;
    }

    public void readLine() {
        textbox.text = lines[currentLine];
        Debug.Log(lines[currentLine]);
        int temp = currentLine + 1;
        if (temp >= (lines.Count - 1)) {
            currentLine = lines.Count - 1;
        }
        else currentLine = temp;
        StartCoroutine(clearText());
    }

    IEnumerator clearText() {
		yield return new WaitForSeconds(5f);
		textbox.text = "";
	}
}
