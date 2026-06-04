using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MoveCelling : MonoBehaviour
{
    Vector3 firstPos;
    void Start()
    {
        firstPos = transform.position;
    }

    void Update()
    {

        if (gameObject.activeSelf&& gameObject.transform.position.y>1)
        {
            this.transform.position -= new Vector3(0, 0.1f, 0)*Time.deltaTime;
        }

        if (gameObject.activeSelf==false)
        {
            this.transform.position = firstPos;
        }
    }
}
