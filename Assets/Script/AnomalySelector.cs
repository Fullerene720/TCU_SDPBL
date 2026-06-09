using System.Collections.Generic;
using UnityEngine;

public class AnomalySelector : MonoBehaviour
{
    public List<AnomalyData> anomalies=new List<AnomalyData>();
    public List<AnomalyRate> rates;
    public int choiceNum = 0;//現在の異変。ゲーム開始時は０
    public int previousChoiceNum = 0;//ひとつ前の異変。ゲーム開始時は０

    public int GetChoiceNum()//現在の異変を返す
    {
        return previousChoiceNum;
    }

    public void Start()//初期化
    {
        choiceNum = 0;
        previousChoiceNum = 0;
    }

    public AnomalyData Select(int floor)
    {

        Debug.Log(previousChoiceNum);
        AnomalyType selectedType;

        // 0階のときは必ずNoAnomalyを選ぶ
        if (floor < 1)
        {
            selectedType = AnomalyType.NoAnomaly;
        }
        else//0階以外のときはランダムに選ぶ
        {
            selectedType = GetRandomType(floor);
        }

        List<int> candidates = new List<int>();//選ばれたTypeだけのリストを作成(元のリストのindexを保存)

        for (int i = 0; i < anomalies.Count; i++)//異変の数だけ繰り返す
        {
            // Typeと一致しないものはスキップ
            if (anomalies[i].type != selectedType)
                continue;

            // 前と同じ異変が出てもスキップする
            if (i == choiceNum)
                continue;

            candidates.Add(i);//Typeと一致するものがあったらCandidatesリストに追加。
        }

        int rand = Random.Range(0, candidates.Count);//Candidatesリストからランダムに選ぶ

        previousChoiceNum = choiceNum;//前回の異変を保存
        choiceNum = candidates[rand];//今回の異変を保存
        return anomalies[choiceNum];//選ばれた異変を返す

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

            return result;
        }
    }

    

    public AnomalyData Delate()
    {
        return anomalies[previousChoiceNum];
    }

}
