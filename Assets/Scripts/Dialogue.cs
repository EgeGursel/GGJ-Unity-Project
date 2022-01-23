using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    private Player player;
    public GameObject dialogueBox;
    public GameObject contButton;
    public TextMeshProUGUI dtext;
    public float TypingSpeed;
    public string[] sentences;
    private int index;
    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
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
            player.DialogueEnd();
        }
    }
}
