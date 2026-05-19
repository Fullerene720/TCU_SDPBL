using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class AnomalyManager : MonoBehaviour
{

    public AnomalySelector selector;

    public bool currentIsAnomaly = false;


    public PlayerTracker tracker;

    
    public void GenerateAnomaly()//¶¬ˆÙ•Ï‘I‘ğ
    {
        AnomalyData selected = selector.Select();
        Spawn(selected);
    }

    
    public void DelateAnomary()//íœˆÙ•Ï‘I‘ğ
    {
        AnomalyData delated = selector.Delate();
        delate(delated);
    }

    
    void Spawn(AnomalyData data)//ˆÙ•Ï¶¬
    {
        data.gameObject.SetActive(true);
        if(data.isAnomaly== true){ currentIsAnomaly=true; }
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
