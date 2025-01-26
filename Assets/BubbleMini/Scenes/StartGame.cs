using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void PlayGame() {
        SceneManager.LoadSceneAsync("Game Screen");
    }
}
