using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    StageManager stageManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "FrontJudge")
        {
            stageManager.FrontJudge();
        }
        else if (other.gameObject.tag == "BackJudge")
        {
            stageManager.BackJudge();
        }
    }
}
