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
        dialogueUI.SetActive(true);
        messageText.text = message;

        // 1フレーム待つ
        yield return null;

        // 全入力が離されるまで待つ
        yield return new WaitUntil(() => !IsPressing());

        // 新しい入力を待つ
        yield return new WaitUntil(() => IsSubmitPressed());

        dialogueUI.SetActive(false);
    }

    public IEnumerator ChangeObject(GameObject obj, bool isActive)
    {
        if (isActive && obj != null && obj.activeSelf == false)
        {
            obj.SetActive(true);
        }
        else if (!isActive && obj != null && obj.activeSelf == true)
        {
            obj.SetActive(false);
        }
            // 1フレーム待つ
            yield return null;
    }

    private bool IsPressing()
    {
        bool keyboard =
            Keyboard.current != null &&
            Keyboard.current.spaceKey.isPressed;

        bool touch =
            Touchscreen.current != null &&
            Touchscreen.current.primaryTouch.press.isPressed;

        return keyboard || touch;
    }

    private bool IsSubmitPressed()
    {
        bool keyboard =
            Keyboard.current != null &&
            Keyboard.current.spaceKey.wasPressedThisFrame;

        bool touch =
            Touchscreen.current != null &&
            Touchscreen.current.primaryTouch.press.wasPressedThisFrame;

        return keyboard || touch;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
