using UnityEngine;


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

    public GameObject ClassroomPerfab;


    public bool isAnomaly = true;


    public int UnlockLevel;//å„îºÇ≈í«â¡Ç≈Ç´ÇÈê›íË
    public float spawnWeight;//èoåªó¶ê›íË
    public bool canRepeat;//çƒèoåªâ¬î\Ç©

    private void Start()
    {
        this.gameObject.SetActive(false);

        if (type == AnomalyType.NoAnomaly)
        {
            isAnomaly = false;
        }


    }




}
