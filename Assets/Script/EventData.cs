using UnityEngine;

public enum EventType
{
    Move,
    LookAt,
    Talk,
    Wait,
    Change,
    end
}


[System.Serializable]
public class EventData
{
    public EventType type;

    [Header("Move and Look")]
    public Transform targetPosition;
    public float moveSpeed;

    [Header("Talk")]
    [TextArea]
    public string message;

    [Header("Wait")]
    public float waitTime;

    [Header("Change")]
    public GameObject Object;
    public bool isActive;

}
