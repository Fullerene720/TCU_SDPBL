using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class AnomalySelector : MonoBehaviour
{
    public List<AnomalyData> anomalies=new List<AnomalyData>();
    public List<AnomalyRate> rates;
    public int choiceNum = 0;

    public int GetChoiceNum()
    {
        return choiceNum;
    }

    public AnomalyData Select(int floor)
    {

        AnomalyType selectedType;

        // 0階
        if (floor == 0)
        {
            selectedType = AnomalyType.NoAnomaly;
        }
        else
        {
            selectedType = GetRandomType(floor);
        }

        List<int> candidates = new List<int>();//選ばれたTypeだけのリストを作成(元のリストのindexを保存)

        for (int i = 0; i < anomalies.Count; i++)//異変の数だけ繰り返す
        {
            // Typeと一致しないiがあったらスキップ
            if (anomalies[i].type != selectedType)
                continue;

            // 前と同じ異変が出てもスキップする
            if (i == choiceNum)
                continue;

            candidates.Add(i);//Typeと一致するものがあったらCandidatesリストに追加。
        }

        int rand = Random.Range(0, candidates.Count);

        choiceNum = candidates[rand];


        return anomalies[choiceNum];

    }

    AnomalyType GetRandomType(int floor)//階数によってTypeの出やすさが変化
    {
        AnomalyRate rate = rates[floor];

        int rand = Random.Range(0, 100);

        if (rand < rate.noAnomaly)//異変無しの確率を引き当てたら
        {
            return AnomalyType.NoAnomaly;
        }

        rand -= rate.noAnomaly;

        if (rand < rate.huge)
        {
            return AnomalyType.HugeAnomaly;
        }

        rand -= rate.huge;

        if (rand < rate.normal)
        {
            return AnomalyType.NormalAnomaly;
        }

        return AnomalyType.TinyAnomaly;
    }

    public AnomalyData Delate()
    {
        return anomalies[choiceNum];
    }

}
