using UnityEngine;
using System.Collections;

public class DoorManager : MonoBehaviour
{
    [SerializeField]
    private Transform door;

    [SerializeField]
    private float openAngle = 90f;

    [SerializeField]
    private float openSpeed = 3f;

    private Quaternion closedRotation;
    private Quaternion openRotation;

    private Coroutine currentCoroutine;

    private void Start()
    {
        closedRotation = door.localRotation;

        openRotation = closedRotation *Quaternion.Euler(0f, openAngle, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        StartDoorAnimation(openRotation);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        StartDoorAnimation(closedRotation);
    }

    private void StartDoorAnimation(Quaternion target)
    {
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);

        currentCoroutine =
            StartCoroutine(RotateDoor(target));
    }

    private IEnumerator RotateDoor(Quaternion target)
    {
        while (Quaternion.Angle(door.localRotation, target) > 0.5f)
        {
            door.localRotation =
                Quaternion.Slerp(
                    door.localRotation,
                    target,
                    openSpeed * Time.deltaTime
                );

            yield return null;
        }

        door.localRotation = target;
    }
}
