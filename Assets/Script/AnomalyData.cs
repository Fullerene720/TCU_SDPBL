using UnityEngine;
using TMPro;


public enum AnomalyType
{
    NoAnomaly,
    HugeAnomaly,
    NormalAnomaly,
    TinyAnomaly,
}

public class AnomalyData : MonoBehaviour
{
    public string anomalyName;

    public AnomalyType type;


    public TMP_Text classNumber;  // テキスト表示
    public GameObject NumberUI; // UI全体
    public bool isFirst = false; 

    public bool isAnomaly = true;

    public float spawnWeight;//出現率設定

    private void Start()
    {
            isAnomaly = true;

        if (type == AnomalyType.NoAnomaly)
        {
            isAnomaly = false;
        }
    }
}
