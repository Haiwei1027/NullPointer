using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    public static DialogueUI Instance { get; private set; }

    [SerializeField] TMP_Text dialogueText;

    private Dialogue current;
    private bool isShown = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Hide();
    }

    private void Update()
    {
        if (isShown && !current.IsFinished() && Input.GetKeyDown(KeyCode.Return))
        {
            current.Continue();
            if (current.IsFinished())
            {
                Hide();
            }
            else
            {
                dialogueText.text = current.GetLine(); 
            }
        }
        if (isShown && !current.IsFinished() && Input.GetKeyDown(KeyCode.Escape))
        {
            Hide();
        }
    }

    public void Show(Dialogue dialogue)
    {
        SetAllChildren(true);
        this.current = dialogue;
        isShown = true;
        dialogueText.text = current.GetLine();
    }

    public void Hide()
    {
        SetAllChildren(false);
        isShown = false;
    }

    private void SetAllChildren(bool active)
    {
        for (int i = 0;i< transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(active);
        }
    }
}
