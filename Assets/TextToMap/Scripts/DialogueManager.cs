using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Dialogue dialogue;

    Queue<string> sentences;

    public GameObject dialoguePanel;
    public TextMeshProUGUI displayText;

    string activeSentence;
    public float typingSpeed;

    AudioSource myAudio;
    public AudioClip speakSound;

    
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        myAudio = GetComponent<AudioSource>();
    }

    void startDialogue()
    {
        sentences.Clear();

        foreach (string sentence in dialogue.sentenceList)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    void DisplayNextSentence()
    {
        if (sentences.Count <= 0)
        {
            displayText.text = activeSentence;
            return;
        }

        activeSentence = sentences.Dequeue();
        Debug.Log(activeSentence);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            startDialogue();
        }
    }
}
