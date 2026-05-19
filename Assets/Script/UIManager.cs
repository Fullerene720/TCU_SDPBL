using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [System.Serializable]
    public class UIMamanger
    {
        public string[] sentences;  // セリフ
    }

    public TMP_Text dialogueText;  // テキスト表示
    public Button nextButton; // 次のセリフボタン
    public GameObject dialogueUI; // UI全体

    public UIManager[] dialogueEvents; // 会話データ
    private int currentDialogueIndex = 0; // 現在の会話イベント
    private int currentSentenceIndex = 0; // 現在のセリフ
    private bool isTyping = false; // 文字表示中フラグ


    public void UIStartEvent()
    {

    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogueUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
