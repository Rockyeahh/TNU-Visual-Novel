using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChange : MonoBehaviour {

    Text text;
    public Button yourButton;

    void Start()
    {
        text = GetComponent<Text>();
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TextColour);
    }

    public void TextColour()
    {
        // SaveAndLoad.saveAndLoad.colourText = text.color = Color.cyan;
        // text.text = "Game Saved";
        SaveAndLoad.saveAndLoad.textCount += 1;
        print(SaveAndLoad.saveAndLoad.textCount);
        text.text = "this " + SaveAndLoad.saveAndLoad.textCount;
    }
        
}
