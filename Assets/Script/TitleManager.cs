using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public void OnStartButton()
    {
        SceneManager.LoadScene("Main");
    }

    public void Start()
    {

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true; ;
    }
}
