using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeToScene : MonoBehaviour
{
    [SerializeField] private int sceneIndex;
    
    public void changeScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
