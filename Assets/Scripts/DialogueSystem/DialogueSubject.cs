using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueSubject : MonoBehaviour
{
    [SerializeField]
    private DialogueText dialogueText;
    [SerializeField]
    private float textSpeed;
    [SerializeField]
    private InputActionReference dialogueReference;
    private InputAction dialogueAction;

    public Dialogue dialogue;
    private int sentenceIndex;

    public UnityEvent DialogueEnded;

    private void Awake() => dialogueAction = dialogueReference.action;

    private void OnEnable() => dialogueAction.performed += OnInput;
    private void OnDisable() => dialogueAction.performed -= OnInput;


    public void StartDialogue()
    {
        dialogueText.ClearAll();
        sentenceIndex = 0;
        dialogueText.gameObject.SetActive(true);
        dialogueText.speakerName.text = dialogue.speakerName;

        StartCoroutine(TypeSentence());
    }
    private void EndDialogue()
    {
        sentenceIndex = 0;
        dialogueText.gameObject.SetActive(false);

        StopCoroutine(TypeSentence());
        DialogueEnded?.Invoke();
    }

    private IEnumerator TypeSentence() 
    {
        foreach (char c in dialogue.sentences[sentenceIndex]) 
        {
            dialogueText.sentenceText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    private void OnInput(InputAction.CallbackContext ctx) 
    {
        NextSentence();
    }

    private void NextSentence()
    {
        StopCoroutine(TypeSentence());
        if (sentenceIndex < dialogue.sentences.Length - 1)
        {
            sentenceIndex++;
            dialogueText.sentenceText.text = string.Empty;
            StartCoroutine(TypeSentence());
        }
        else 
        {
            EndDialogue();
        }
    }

}
