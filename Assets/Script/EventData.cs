using UnityEngine;

public enum EventType
{
    Move,
    Talk,
    Wait
}


[System.Serializable]
public class EventData
{
    public EventType type;

    [Header("Move")]
    public Transform targetPosition;
    public float moveSpeed;

    [Header("Talk")]
    [TextArea]
    public string message;

    [Header("Wait")]
    public float waitTime;
}
