using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public StageManager stageManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("trigger enter");
        //Debug.Log(GameManager.Instance.State);

        if (GameManager.Instance.State == GameState.Playing)
        {
            if (other.gameObject.tag == "HallFront")
            {
                stageManager.HallChange();
            }
        }else if(GameManager.Instance.State == GameState.Start)
        {
            if (other.gameObject.tag == "HallFront")
            {
                stageManager.FirstHallChange();
            }
        }

        if (other.gameObject.tag == "FrontJudge")
        {
            Debug.Log("FrontJudge"); 
            stageManager.FrontJudge();
        }
        else if (other.gameObject.tag == "BackJudge")
        {
            Debug.Log("BackJudge");
            stageManager.BackJudge();
        }

    }
}
