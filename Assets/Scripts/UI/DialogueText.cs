using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueText : MonoBehaviour
{
    public Text sentenceText;
    public Text speakerName;

    public void ClearAll()
    {
        sentenceText.text = string.Empty;
        speakerName.text = string.Empty;
    }
}
