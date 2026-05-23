using System.Collections;
using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [System.Serializable]
    public class UIMamanger
    {
        public string[] sentences;  // セリフ
    }

    public TMP_Text messageText;  // テキスト表示
    public GameObject dialogueUI; // UI全体
    private StarterAssetsInputs _input;

    void Start()
    {
        _input = new StarterAssetsInputs();
        dialogueUI.SetActive(false);
    }



    public IEnumerator ShowMessage(string message)
    {
        var keyboard = Keyboard.current;

        dialogueUI.SetActive(true);
        messageText.text = message;

        yield return new WaitUntil(() => keyboard.spaceKey.wasPressedThisFrame);

        dialogueUI.SetActive(false);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
