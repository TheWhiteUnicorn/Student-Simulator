using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MathGame : MonoBehaviour
{
 
    public Text text2; // math text

    private int lvlCounter= 0;
    private int liveCounter = 3;
    public GameObject live1;
    public GameObject live2;
    public GameObject live3;
    public Text button1text;
    public Text button2text;
    public Text button3text;
    public Text button4text;
    private GameObject button1;
    private GameObject button2;
    private GameObject button3;
    private GameObject button4;

    private int but;

    public GameObject GameOverPanel;




    public void Another(int liveCounter)
    {
        GameObject button1 = GameObject.Find("Button1");
        GameObject button2 = GameObject.Find("Button2");
        GameObject button3 = GameObject.Find("Button3");
        GameObject button4 = GameObject.Find("Button4");

        but = 0;
        button1text.GetComponent<Text>().color = new Color(0, 0, 0);
        button2text.GetComponent<Text>().color = new Color(0, 0, 0);
        button3text.GetComponent<Text>().color = new Color(0, 0, 0);
        button4text.GetComponent<Text>().color = new Color(0, 0, 0);
        button1text.GetComponent<Text>().text = "";
        button2text.GetComponent<Text>().text = "";
        button3text.GetComponent<Text>().text = "";
        button4text.GetComponent<Text>().text = "";
        text2.GetComponent<Text>().text = "";

    
        int a = 0;
        int b = 0;
        int c = 0;
        int sign = 0;

        System.Random rand = new System.Random();
        if (lvlCounter <= 5)
        {
            a = rand.Next(1, 5);
            b = rand.Next(1, 5);

            sign = rand.Next(1, 3);
        }
        if ((lvlCounter <= 10) && (lvlCounter > 5))
        {
            a = rand.Next(5, 10);
            b = rand.Next(5, 10);
            c = rand.Next(2, 5);
            sign = rand.Next(2, 6);
        }
        if ((lvlCounter <= 30) && (lvlCounter > 10))
        {
            a = rand.Next(10, 15);
            b = rand.Next(10, 15);
            c = rand.Next(4, 10);
            sign = rand.Next(5, 8);
        }
        switch (sign)
        {
            case 1:
                text2.GetComponent<Text>().text = a.ToString() + " + " + b.ToString() + " = ";
                break;
            case 2:
                text2.GetComponent<Text>().text = a.ToString() + " * " + b.ToString() + " = ";
                break;
            case 3:
                text2.GetComponent<Text>().text = "( " + a.ToString() + " + " + b.ToString() + " )" + " * " + c.ToString() + " =";
                break;
            case 4:
                text2.GetComponent<Text>().text = "( " + a.ToString() + " * " + b.ToString() + " )" + " - " + c.ToString() + " =";
                break;
            case 5:
                text2.GetComponent<Text>().text = a.ToString() + " + " + b.ToString() + " * " + c.ToString() + " =";
                break;
            case 6:
                text2.GetComponent<Text>().text = "( " + a.ToString() + " * " + c.ToString() + " )" + " - " + c.ToString() + " =";
                break;
            case 7:
                text2.GetComponent<Text>().text = "( " + a.ToString() + " * " + c.ToString() + " - " + c.ToString() + " ) + " + b.ToString() + " =";
                break;



        }
        int count = 0;
        if (sign == 1)
        {
            count = a + b;

        }
        if (sign == 2)
        {
            count =a * b;
        }
        if (sign == 3)
        {
            int count1 = a +b;
            count = count1 *c;
        }
        if (sign == 4)
        {
            int count1 = a * b;
            count = count1 - c;
        }
        if (sign == 5)
        {
            int count1 = b * c;
            count = a + count1;
        }
        if (sign == 6)
        {
            int count1 = a * c;
            count = count1 - c;
        }
        if (sign == 7)
        {
            int count1 = a * c;
            int count2 = count1 - c;
           count = count2 + b;
        }
        int buttoncheck = 0;
        buttoncheck = rand.Next(1, 5);
        switch (buttoncheck)
        {
            case 1:
                button1text.GetComponent<Text>().text = count.ToString();
                but = 1;
                break;
            case 2:
                button2text.GetComponent<Text>().text = count.ToString();
                but = 2;
                break;
            case 3:
                button3text.GetComponent<Text>().text = count.ToString();
                but = 3;
                break;

            case 4:
                button4text.GetComponent<Text>().text = count.ToString();
                but = 4;
                break;

        }


        int answer = 0;

        if (button1text.GetComponent<Text>().text == "")

        {
            if (lvlCounter < 6)
            {
                answer = rand.Next(1, 15);
            }
            if (lvlCounter >= 6 && lvlCounter < 11)
            {
                answer = rand.Next(20, 110);
            }
            if (lvlCounter >= 11 && lvlCounter < 30)
            {
                answer = rand.Next(35, 280);
            }
            if (answer != count)
            {
                button1text.GetComponent<Text>().text = answer.ToString();
            }
            else
            {
                answer = 0;
                button1text.GetComponent<Text>().text = answer.ToString();
            }
        }
        if (button2text.GetComponent<Text>().text == "")

        {
            if (lvlCounter < 6)
            {
                answer = rand.Next(1, 15);
            }
            if (lvlCounter >= 6 && lvlCounter < 11)
            {
                answer = rand.Next(20, 110);
            }
            if (lvlCounter >= 11 && lvlCounter < 30)
            {
                answer = rand.Next(35, 280);
            }
            if (answer != count)
            {
                button2text.GetComponent<Text>().text = answer.ToString();
            }
            else
            {
                answer = 0;
                button2text.GetComponent<Text>().text = answer.ToString();
            }
        }
        if (button3text.GetComponent<Text>().text == "")

        {
            if (lvlCounter < 6)
            {
                answer = rand.Next(1, 15);
            }
            if (lvlCounter >= 6 && lvlCounter < 11)
            {
                answer = rand.Next(20, 110);
            }
            if (lvlCounter >= 11 && lvlCounter < 30)
            {
                answer = rand.Next(35, 280);
            }
            if (answer != count)
            {
                button3text.GetComponent<Text>().text = answer.ToString();
            }
            else
            {
                answer = 0;
                button3text.GetComponent<Text>().text = answer.ToString();
            }
        }
        if (button4text.GetComponent<Text>().text == "")

        {
            if (lvlCounter < 6)
            {
                answer = rand.Next(1, 15);
            }
            if (lvlCounter >= 6 && lvlCounter < 11)
            {
                answer = rand.Next(20, 90);
            }
            if (lvlCounter >= 11 && lvlCounter < 30)
            {
                answer = rand.Next(35, 225);
            }
            if (answer != count)
            {
                button4text.GetComponent<Text>().text = answer.ToString();
            }
            else
            {
                answer = 0;
                button4text.GetComponent<Text>().text = answer.ToString();
            }
        }


        // вот тут надо разобраться
        
        button1.GetComponent<Button>().onClick.AddListener(() => { pressButton1(but); });
        
        button2.GetComponent<Button>().onClick.AddListener(() => { pressButton2(but); });
      
        button3.GetComponent<Button>().onClick.AddListener(() => { pressButton3(but); });
       
        button4.GetComponent<Button>().onClick.AddListener(() => { pressButton4(but); });
        


    }
   

    public void pressButton1(int but)
    {
        

        if (but == 1)
        {
            button1text.GetComponent<Text>().color = new Color(0, 255, 0);
            lvlCounter++;

        }

        else
        {
            button1text.GetComponent<Text>().color = new Color(255, 0, 0);
            liveCounter--;
            if (liveCounter == 2)
            {
                live1.SetActive(false);
            }
            if (liveCounter == 1)
            {
                live2.SetActive(false);
            }
            if (liveCounter == 0)
            {
                live3.SetActive(false);
                GameOverPanel.SetActive(true);

            }
            

        }

        Another(liveCounter);
        button1.GetComponent<Button>().onClick.RemoveListener(() => { pressButton1(but); });

    }
    public void pressButton2(int but)
    {
        
        if (but == 2)
        {
            button2text.GetComponent<Text>().color = new Color(0, 255, 0);
            lvlCounter++;
          
        }
        else
        {
            button2text.GetComponent<Text>().color = new Color(255, 0, 0);
            liveCounter--;
            if (liveCounter == 2)
            {
                live1.SetActive(false);
            }
            if (liveCounter == 1)
            {
                live2.SetActive(false);
            }
            if (liveCounter == 0)
            {
                live3.SetActive(false);
                GameOverPanel.SetActive(true);

            }
        }

        Another(liveCounter);
        button2.GetComponent<Button>().onClick.RemoveListener(() => { pressButton2(but); });
    }
    public void pressButton3(int but)
    {
        
        if (but == 3)
        {
            button3text.GetComponent<Text>().color = new Color(0, 255, 0);
            lvlCounter++;
        }
        else
        {
            button3text.GetComponent<Text>().color = new Color(255, 0, 0);
            liveCounter--;
            if (liveCounter == 2)
            {
                live1.SetActive(false);
            }
            if (liveCounter == 1)
            {
                live2.SetActive(false);
            }
            if (liveCounter == 0)
            {
                live3.SetActive(false);
                GameOverPanel.SetActive(true);

            }
        }

        Another(liveCounter);
        button3.GetComponent<Button>().onClick.RemoveListener(() => { pressButton3(but); });
    }
    public void pressButton4(int but)
    {
   
        if (but == 4)
        {
            button4text.GetComponent<Text>().color = new Color(0, 255, 0);
            lvlCounter++;

        }
        else
        {
            button4text.GetComponent<Text>().color = new Color(255, 0, 0);
            liveCounter--;
            if (liveCounter == 2)
            {
                live1.SetActive(false);
            }
            if (liveCounter == 1)
            {
                live2.SetActive(false);
            }
            if (liveCounter == 0)
            {
                live3.SetActive(false);
                GameOverPanel.SetActive(true);

            }
        }

        Another(liveCounter);
        button4.GetComponent<Button>().onClick.RemoveListener(() => { pressButton4(but); });
    }
    void Start ()
    {
        
        GameOverPanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

}
