using UnityEngine;

public class AnomalyManager : MonoBehaviour
{

    [SerializeField]  private AnomalySelector selector;
    public bool currentIsAnomaly = false;
    public Vector3 currentPosition;
    public Quaternion currentRotation;
    [SerializeField] private Transform firstRoomPos;
    private int shift = -1;

    private void Start()
    {
        currentPosition = firstRoomPos.localPosition;
        currentRotation = firstRoomPos.rotation;
        currentIsAnomaly = false;
        shift = 1;
    }

    public void GenerateAnomaly(Vector3 position,int classCount)//生成教室選択
    {
        AnomalyData selected = selector.Select(classCount);
        Spawn(selected,position);
        ChangeFloorNum(selected,classCount);
    }
    
    public void DelateAnomaly()//削除教室選択
    {
        AnomalyData delated = selector.Delate();
        delate(delated);
    }

    void Spawn(AnomalyData data, Vector3 position)//教室生成
    {
        data.gameObject.SetActive(true);

        position *= shift;

        Vector3 newPos = currentPosition + position;


        Quaternion newRot = currentRotation * Quaternion.Euler(0, 180, 0);

        data.transform.SetPositionAndRotation(newPos, newRot);

        // 現在値更新
        currentPosition = data.transform.position;
        currentRotation = data.transform.rotation;

        shift *= -1;

        currentIsAnomaly = data.isAnomaly;
    }


    void delate(AnomalyData data)//教室削除
    {
        data.gameObject.SetActive(false);
    }

    private void ChangeFloorNum(AnomalyData data, int classCount)//階数表示変更
    {

        switch (classCount)
        {
            case 0:
                data.ChangeFloorString("1BF");
                break;

            case 1:
                data.ChangeFloorString("1BE");
                break;

            case 2:
                data.ChangeFloorString("1BD");
                break;

            case 3:
                data.ChangeFloorString("1BC");
                break;
            case 4:
                data.ChangeFloorString("1BB");
                break;
            case 5:
                data.ChangeFloorString("1BA");
                break;

            default:
                data.ChangeFloorString("Error");
                break;
        }
    }
}
