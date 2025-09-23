using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuAppearScript : MonoBehaviour
{
    public GameObject menu;
    private bool isShowing = false;

    void Start()
    {
        menu.SetActive(isShowing);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isShowing = !isShowing;
            menu.SetActive(isShowing);
        }

        if (isShowing)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                SceneManager.LoadScene(sceneBuildIndex: 0);
            }
            else if (Input.GetKeyDown(KeyCode.X))
            {
                isShowing = !isShowing;
                menu.SetActive(isShowing);
            }
        }
    }
}
