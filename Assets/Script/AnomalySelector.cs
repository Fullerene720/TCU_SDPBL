using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class AnomalySelector : MonoBehaviour
{
    private List<AnomalyData> anomalies=new List<AnomalyData>();
    int choiceNum = -1;

    
    public AnomalyData Select(int num)
    {
        
        //選択ロジックを記述
        //今はリストから順番に代わっていくようにしている。
        //今後、PlayerTrackerなどを使ってランダムかつ重みを付けたい。
        choiceNum++;
        return anomalies[choiceNum];
        
    }

    public AnomalyData Delate()
    {
        return anomalies[choiceNum];
    }

}
