using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class EventManager : MonoBehaviour
{
    [SerializeField]
    private List<EventData> eventList;

    [SerializeField]
    private FirstPersonController player;

    [SerializeField]
    private UIManager uiManager;



    public void StartEvent()
    {
        StartCoroutine(EventCoroutine());
    }

    private IEnumerator EventCoroutine()
    {
        
        player.canMove = false;

        foreach(EventData data in eventList)
        {
            switch (data.type)
            {
                case EventType.Talk:
                    yield return StartCoroutine(uiManager.ShowMessage(data.message));
                    break;
                case EventType.LookAt:
                    yield return StartCoroutine(player.LookAtTarget(data.targetPosition,data.moveSpeed));
                    break;
                case EventType.Move:
                    yield return StartCoroutine(player.MoveTo(data.targetPosition,data.moveSpeed));
                    break;
                case EventType.Wait:
                    yield return new WaitForSeconds(data.waitTime);
                    break;
                case EventType.Change:
                    yield return StartCoroutine(uiManager.ChangeObject(data.Object, data.isActive));
                    break;
                case EventType.end:
                    yield return StartCoroutine(player.Reset());
                    break;

            }
        }
        player.canMove = true;
        GameManager.Instance.SetCurrentState(GameState.Playing);
    } 


}
