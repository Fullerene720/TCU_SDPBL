using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField]  private AnomalyManager anomalyManager;
    [SerializeField] private GameObject BeginObject;
    [SerializeField] private GameObject ChangeHall;
    [SerializeField] private GameObject WallFront;//前から来た時に出す
    [SerializeField] private GameObject WallBack;//後ろから来た時に出す

    [SerializeField] public int ClassCount = 0;//もし行動に成功したら増える、失敗したら0に戻る
    [SerializeField] public int BaseCount = 0;//正誤関係なく行動するたびに増える
    [SerializeField] public int CheckCount = 0;//廊下生成されるたびにカウントアップ。教室生成のフラグになっている。

    //事前に設定が必要
    [SerializeField] private Vector3 hallwayRelativePos;//今いる教室に対しての廊下の相対座標
    [SerializeField] private Vector3 frontClassRelativePos;//今いる教室に対しての前からの教室座標
    [SerializeField] private Vector3 backClassRelativePos;//今いる教室に対しての後ろからの教室座標

    private int shift;

    public void Start()
    {
        shift = 1;
        WallBack.SetActive(false);
        WallFront.SetActive(true);
        ClassCount = -1;
        BaseCount = 0;
        CheckCount = 0;
    }

    public void GameStart()
    {
        BeginObject.SetActive(false);
        ClassCount = 0;
        BaseCount = 0;
        CheckCount = 0;


    }

    private void Update()
    {
        if (ClassCount > 5&&GameManager.Instance.State==GameState.Playing)
        {
            
            GameManager.Instance.SetCurrentState(GameState.End);
        }
    }
    public void EventSet()
    {
        BeginObject.SetActive(true);
    }


    

    public void FrontJudge()//前の扉から出たら
    {
        if (CheckCount != BaseCount) return;
        if (anomalyManager.currentIsAnomaly == true) ClassCount++;
        else ClassCount = 0;
        BaseCount++;

        anomalyManager.GenerateAnomaly(frontClassRelativePos,ClassCount);
        WallBack.SetActive(false);
    }

    public void BackJudge()//後ろの扉から出たら
    {
        if (CheckCount != BaseCount) return;
        if (anomalyManager.currentIsAnomaly == false) ClassCount++;
        else ClassCount = 0;
        BaseCount++;

        anomalyManager.GenerateAnomaly(backClassRelativePos,ClassCount);
        WallFront.SetActive(false);
    }

    private void HallWayChange()//廊下生成
    {
        CheckCount++;
        Quaternion rot =anomalyManager.currentRotation;

        hallwayRelativePos *= shift;
        Vector3 pos = anomalyManager.currentPosition + rot * hallwayRelativePos;

        ChangeHall.transform.SetPositionAndRotation(pos, rot);

        shift *= -1;

        WallBack.SetActive(true);
        WallFront.SetActive(true);

    }

    public void HallChange()//廊下生成フラグ
    {
        Debug.Log("HallChange");
        HallWayChange();
        anomalyManager.DelateAnomaly();
    }

    public void FirstHallChange()
    {
        Debug.Log("FirstHallChange");
        HallWayChange();
    }
}
