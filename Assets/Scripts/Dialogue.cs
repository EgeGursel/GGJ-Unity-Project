using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public GameObject dialogueBox;
    public GameObject contButton;
    public TextMeshProUGUI dtext;
    public float TypingSpeed;
    public string[] sentences;
    private int index;
    public int ended = 0;
    private void Start()
    {
        ended = 0;
        dialogueBox.SetActive(true);
        contButton.SetActive(false);
        StartCoroutine(Type());
    }
    private void Update()
    {
        if (dtext.text == sentences[index])
        {
            contButton.SetActive(true);
        }
    }
    IEnumerator Type()
    {
        foreach (char c in sentences[index].ToCharArray())
        {
            dtext.text += c;
            yield return new WaitForSeconds(TypingSpeed);
        }
    }
    public void Next()
    {
        contButton.SetActive(false);
        if (index < sentences.Length - 1)
        {
            index++;
            dtext.text = "";
            StartCoroutine(Type());
        }
        else
        {
            dtext.text = "";
            dialogueBox.SetActive(false);
            ended += 1;
        }
    }
}
