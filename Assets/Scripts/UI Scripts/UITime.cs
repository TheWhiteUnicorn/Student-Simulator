using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITime : MonoBehaviour {

    public void PauseGame()
    {
        Time.timeScale = 0.0F;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0F;
    }
}
