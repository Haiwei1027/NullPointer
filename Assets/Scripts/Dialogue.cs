using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [SerializeField] Narrative narrative;
    int currentLine;

    public string GetLine()
    {
        if (!IsFinished())
        {
            return narrative.lines[currentLine];
        }

        return null;
    }

    public void Continue()
    {
        if (IsFinished()) { return; }
        currentLine++;
    }

    public bool IsFinished()
    {
        if (narrative == null) { return true; }
        return currentLine >= narrative.lines.Length;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (IsFinished()) { return; }
        if (other.gameObject == Player.Instance.Character)
        {
            DialogueUI.Instance.Show(this);
        }
    }
    
    public void OnTriggerExit(Collider other)
    {
        if (IsFinished()) { return; }
        if (other.gameObject == Player.Instance.Character)
        {
            DialogueUI.Instance.Hide();
        }
    }
}
