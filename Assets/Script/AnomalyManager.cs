using System.Collections.Generic;
using Mono.Cecil;
using NUnit.Framework;
using Unity.VisualScripting;
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
    }


    public void GenerateAnomaly(Vector3 position,int classCount)//生成異変選択
    {
        AnomalyData selected = selector.Select(classCount);
        Spawn(selected,position);
    }

    
    public void DelateAnomaly()//削除異変選択
    {
        AnomalyData delated = selector.Delate();
        delate(delated);
    }


    void Spawn(AnomalyData data, Vector3 position)
    {
        data.gameObject.SetActive(true);

        position *= shift;

        // Position
        Vector3 newPos = currentPosition + position;


        // Rotation
        Quaternion newRot =
            currentRotation * Quaternion.Euler(0, 180, 0);

        // 一括設定
        data.transform.SetPositionAndRotation(newPos, newRot);

        // 現在値更新
        currentPosition = data.transform.position;
        currentRotation = data.transform.rotation;

        shift *= -1;

        currentIsAnomaly = data.isAnomaly;
    }


    void delate(AnomalyData data)//異変削除
    {
        data.gameObject.SetActive(false);
    }


    private void Update()
    {
        


    }


    

}
