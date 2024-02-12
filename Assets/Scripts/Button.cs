
using UnityEngine;
using UnityEngine.SceneManagement;

//https://www.youtube.com/watch?v=Dn8fCuaL-RA&ab_channel=AIA

public class Button : MonoBehaviour
{
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
