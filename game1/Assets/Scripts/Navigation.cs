using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
    public void goToPlayScreen()
    {
        SceneManager.LoadScene("Play Screen");
    }
}
