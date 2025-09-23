using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // This will be the method that the button calls
    public void OnButtonClick()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }
}
