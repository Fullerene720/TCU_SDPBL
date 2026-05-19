using Unity.Cinemachine;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public AnomalyManager anomalyManager;
    [SerializeField] private GameObject BeginObject;
    [SerializeField] private GameObject HallWay;
    [SerializeField] public int ClassCount = 0;

    private void Start()
    {
        BeginObject.SetActive(false);
    }

    private void Update()
    {
        
    }
    public void EventSet()
    {
        BeginObject.SetActive(true);
    }


    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "FrontJudge")
        {
            if (anomalyManager.currentIsAnomaly == true) ClassCount++;
            else                                         ClassCount = 0;
        }
        else if(other.gameObject.tag == "BackJudge")
        {
            if (anomalyManager.currentIsAnomaly == false) ClassCount++;
            else ClassCount = 0;
        }


    }


    public void NextStage()
    {
        anomalyManager.GenerateAnomaly();
    }
}
