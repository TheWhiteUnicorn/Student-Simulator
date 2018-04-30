using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {


    //private float timer = 60;
    public Text text;
    public GameObject GameOverPanel;
    private int sec = 60;

    void Sec()
    {
        sec--;
    }



    // Use this for initialization
    void Start ()
    {
        GameOverPanel.SetActive(false);
    }
    

    // Update is called once per frame
    public void Update ()
    {
        if (GameOverPanel.activeSelf)
        {
            text.GetComponent<Text>().text = sec.ToString();
        }
        else
        {
            if (sec >= 1)
            {
                if (!IsInvoking("Sec"))
                {
                    Invoke("Sec", 1);
                }
                text.GetComponent<Text>().text = sec.ToString();
            }
            if (sec == 5)
            {
                text.GetComponent<Text>().text = sec.ToString();
                text.GetComponent<Text>().color = new Color(255, 0, 0);

            }
            if (sec == 0)
            {
                text.GetComponent<Text>().text = sec.ToString();
                GameOverPanel.SetActive(true);
                sec = 0;

            }
        }
    }
    void Simpletimer()
    {

    }
}
