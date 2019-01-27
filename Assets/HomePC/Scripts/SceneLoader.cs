using UnityEngine;
using UnityEngine.SceneManagement;

namespace HomePC
{
    public class SceneLoader : MonoBehaviour
    {
        public void onStartClick()
        {
            Debug.Log("Scene loading");
            SceneManager.LoadScene("Scene1");
        }

        public void onExitClick()
        {
            Debug.Log("Exit");
            Application.Quit();
        }
    }
}