﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    // Start is called before the first frame update
    public void RetryGame()
    {
        SceneManager.LoadScene("Level");
    }

    // Update is called once per frame
    public void QuitGame()
    {
        Application.Quit();
    }
}
