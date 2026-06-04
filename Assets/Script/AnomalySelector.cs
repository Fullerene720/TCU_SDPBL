using System.Collections.Generic;
using UnityEngine;

public class AnomalySelector : MonoBehaviour
{
    public List<AnomalyData> anomalies=new List<AnomalyData>();
    public List<AnomalyRate> rates;
    public int choiceNum = 0;
    public int previousChoiceNum = 0;

    public int GetChoiceNum()
    {
        return previousChoiceNum;
    }

    public AnomalyData Select(int floor)
    {

        Debug.Log(previousChoiceNum);
        AnomalyType selectedType;

        // 0階
        if (floor < 1)
        {
            selectedType = AnomalyType.NoAnomaly;
            previousChoiceNum = choiceNum;
            choiceNum = 0;
            return anomalies[choiceNum];
        }
        else
        {
            selectedType = GetRandomType(floor);
        }

        List<int> candidates = new List<int>();//選ばれたTypeだけのリストを作成(元のリストのindexを保存)

        for (int i = 1; i < anomalies.Count; i++)//異変の数だけ繰り返す
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

        previousChoiceNum = choiceNum;
        choiceNum = candidates[rand];
        return anomalies[choiceNum];

    }

    AnomalyType GetRandomType(int floor)//階数によってTypeの出やすさが変化
    {
        while (true)
        {
            AnomalyRate rate = rates[floor];
            int rand = Random.Range(0, 100);

            AnomalyType result;

            if (rand < rate.noAnomaly)
                result = AnomalyType.NoAnomaly;
            else if (rand < rate.noAnomaly + rate.huge)
                result = AnomalyType.HugeAnomaly;
            else if (rand < rate.noAnomaly + rate.huge + rate.normal)
                result = AnomalyType.NormalAnomaly;
            else
                result = AnomalyType.TinyAnomaly;

            // 前回も今回もNoAnomalyなら引き直し
            if (
                result == AnomalyType.NoAnomaly &&
                anomalies[choiceNum].type == AnomalyType.NoAnomaly &&
                previousChoiceNum != 0
            )
            {
                continue;
            }

            return result;
        }
    }

    

    public AnomalyData Delate()
    {
        return anomalies[previousChoiceNum];
    }

}
