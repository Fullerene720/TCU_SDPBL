using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UIElements;

public class StageManager : MonoBehaviour
{
    public AnomalyManager anomalyManager;
    [SerializeField] private GameObject BeginObject;
    [SerializeField] private GameObject FirstRoom;
    [SerializeField] private GameObject ChangeHall;

    [SerializeField] public int ClassCount = 0;//もし行動に成功したら増える、失敗したら0に戻る
    [SerializeField] public int BaseCount = 0;//正誤関係なく行動するたびに増える

    //事前に設定が必要
    [SerializeField] private Vector3 hallwayRelativePos;//今いる教室に対しての廊下の相対座標
    [SerializeField] private Vector3 frontClassRelativePos;//今いる教室に対しての前からの教室座標
    [SerializeField] private Vector3 backClassRelativePos;//今いる教室に対しての後ろからの教室座標

    public void GameStart()
    {
        BeginObject.SetActive(false);
        ClassCount = 0;
        BaseCount = 0;


    }

    private void Update()
    {
        
    }
    public void EventSet()
    {
        BeginObject.SetActive(true);
        FirstRoom.SetActive(true);
    }


    

    public void FrontJudge()
    {
        if (anomalyManager.currentIsAnomaly == true) ClassCount++;
        else ClassCount = 0;
        BaseCount++;

        anomalyManager.GenerateAnomaly(frontClassRelativePos,ClassCount);
        HallWayChange();
        anomalyManager.DelateAnomaly();

    }

    public void BackJudge()
    {
        if (anomalyManager.currentIsAnomaly == false) ClassCount++;
        else ClassCount = 0;
        BaseCount++;

        anomalyManager.GenerateAnomaly(backClassRelativePos,ClassCount);
        HallWayChange();
        anomalyManager.DelateAnomaly();
    }

    private void HallWayChange()
    {
        ChangeHall.transform.position = anomalyManager.currentPosition + hallwayRelativePos;
        ChangeHall.transform.eulerAngles = anomalyManager.currentRotation + new Vector3(0, 180, 0);
    }

    public void HallChangeFront()
    {

    }
    public void HallChangeBack()
    {

    }
}
