using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_Dialogue : MonoBehaviour
{
    public Text chatText;

    private void Start()
    {
        chatText.text = "";
        string sampleText = "안녕. 오랜만이구나.";
        StartCoroutine(Typing(sampleText));
    }

    IEnumerator Typing(string text)
    {
        foreach (char letter in text.ToCharArray())
        {
            chatText.text += letter;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
