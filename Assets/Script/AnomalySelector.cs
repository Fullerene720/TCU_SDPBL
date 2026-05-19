using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class AnomalySelector : MonoBehaviour
{
    public List<AnomalyData> anomalyList=new List<AnomalyData>();
    int choiceNum = -1;

    
    public AnomalyData Select()
    {
        
        //選択ロジックを記述
        //今はリストから順番に代わっていくようにしている。
        //今後、PlayerTrackerなどを使ってランダムかつ重みを付けたい。
        choiceNum++;
        return anomalyList[choiceNum];
        
    }

    public AnomalyData Delate()
    {
        return anomalyList[choiceNum];
    }

}
