using System.Collections.Generic;
using Mono.Cecil;
using NUnit.Framework;
using UnityEngine;

public class AnomalyManager : MonoBehaviour
{

    private AnomalySelector selector;
    public bool currentIsAnomaly = false;
    private Vector3 currentPosition;
    private Vector3 currentRotation;


    public PlayerTracker tracker;


    private void Start()
    {
        currentPosition = new Vector3(0,0,0);
        currentRotation = new Vector3(0,0,0);
    }


    public void GenerateAnomaly(Vector3 position,int classCount)//¶¬ˆÙ•Ï‘I‘ğ
    {
        AnomalyData selected = selector.Select(classCount);
        Spawn(selected,position);
    }

    
    public void DelateAnomaly()//íœˆÙ•Ï‘I‘ğ
    {
        AnomalyData delated = selector.Delate();
        delate(delated);
    }

    
    void Spawn(AnomalyData data ,Vector3 position)//ˆÙ•Ï¶¬
    {
        data.gameObject.SetActive(true);
        data.transform.position = currentPosition + position;
        data.transform.eulerAngles = currentRotation + new Vector3(0, 180, 0);
        currentPosition = data.transform.position;
        currentRotation = data.transform.eulerAngles;

        if (data.isAnomaly== true){ currentIsAnomaly=true; }
        else { currentIsAnomaly=false; }
    }

    
    void delate(AnomalyData data)//ˆÙ•Ïíœ
    {
        data.gameObject.SetActive(false);
    }


    private void Update()
    {
        if (GameManager.Instance.State != GameState.Playing)
        {
            return;
        }


    }


    

}
