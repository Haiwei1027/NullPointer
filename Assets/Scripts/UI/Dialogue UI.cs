using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    public static DialogueUI Instance { get; private set; }

    [SerializeField] TMP_Text dialogueText;

    private Coroutine dialogueRoutine;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Hide();
    }

    IEnumerator DialogueUpdate(Dialogue dialogue)
    {
        dialogueText.text = dialogue.GetLine();
        yield return null;
    }

    public void Show(Dialogue dialogue)
    {
        SetAllChildren(true);
        dialogueRoutine = StartCoroutine(DialogueUpdate(dialogue));
    }

    public void Hide()
    {
        SetAllChildren(false);
        if (dialogueRoutine != null) { StopCoroutine(dialogueRoutine); }
        
    }

    private void SetAllChildren(bool active)
    {
        for (int i = 0;i< transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(active);
        }
    }
}
