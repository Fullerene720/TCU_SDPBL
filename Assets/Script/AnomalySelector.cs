using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class AnomalySelector : MonoBehaviour
{
    public List<AnomalyData> anomalies=new List<AnomalyData>();
    public int choiceNum = 0;

    public int GetChoiceNum()
    {
        return choiceNum;
    }

    public AnomalyData Select(int num, int choiceNum)
    {
        
        choiceNum = Random.Range(1, 4);
        return anomalies[choiceNum];
        
    }

    public AnomalyData Delate()
    {
        return anomalies[choiceNum];
    }

}
