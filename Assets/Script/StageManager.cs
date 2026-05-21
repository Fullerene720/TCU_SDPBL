using Unity.Cinemachine;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public AnomalyManager anomalyManager;
    [SerializeField] private GameObject BeginObject;
    [SerializeField] private GameObject HallWay;
    [SerializeField] public int ClassCount = 0;

    //事前に設定が必要
    [SerializeField] private Vector3 hallwayRelativePos;//今いる教室に対しての廊下の相対座標
    [SerializeField] private Vector3 frontClassRelativePos;//今いる教室に対しての前からの教室座標
    [SerializeField] private Vector3 backClassRelativePos;//今いる教室に対しての後ろからの教室座標

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


    

    public void FrontJudge()
    {
        if (anomalyManager.currentIsAnomaly == true) ClassCount++;
        else ClassCount = 0;

        anomalyManager.GenerateAnomaly(frontClassRelativePos);
        anomalyManager.DelateAnomaly();
    }

    public void BackJudge()
    {
        if (anomalyManager.currentIsAnomaly == false) ClassCount++;
        else ClassCount = 0;

        anomalyManager.GenerateAnomaly(backClassRelativePos);
        anomalyManager.DelateAnomaly();
    }
}
