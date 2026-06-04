using TMPro;
using UnityEngine;
using System.Collections;

public class result : MonoBehaviour
{
    [SerializeField] private GameObject resultPanel;
    [SerializeField] private TextMeshProUGUI resultText;
    private StageManager stageManager;
    private GameManager gameManager;

    private bool hasStarted = false;

    void Update()
    {
        if (resultPanel.activeSelf && !hasStarted)
        {
            hasStarted = true;
            StartCoroutine(ResultCoroutine());
        }
    }

    IEnumerator ResultCoroutine()
    {
        stageManager = FindAnyObjectByType<StageManager>();
        gameManager = FindAnyObjectByType<GameManager>();
        float time = gameManager.clearTime;
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        string timeText = $"{minutes}分{seconds}秒";
        string classCount = $"{stageManager.BaseCount}個";
        string[] messages =
        {
        "結果発表",
        "\nクリア時間：",
        timeText,
        "\n入った教室の数：",
        classCount
        };

        

        resultText.text = "";

        foreach (string message in messages)
        {
            resultText.text += message;
            yield return new WaitForSeconds(1f);
        }
    }
}

