using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System.Diagnostics;
using System;

public class MainGame : MonoBehaviour
{
    public float timeRemaining;

    public GameObject table;
    public GameObject timeLabel;
    public GameObject moneyLabel;
    public GameObject timeOvenLabel;

    public Button btnFlour;
    public Button btnEgg;
    public Button btnMilk;
    public Button btnBerries;
    public Button btnSugar;

    public GameObject step1;
    public GameObject step2;
    public GameObject step3;
    public GameObject step4;
    public GameObject step5;
    public GameObject step6;

    public Button btnSell;
    public Button btnOven;
    public GameObject btnNext;

    public GameObject i1;
    public GameObject i2;
    public GameObject i3;
    public GameObject i4;
    public GameObject i5;
    public GameObject totalOven;

    // GAME STATE
    int[] currentRecipe;
    int[] goalRecipe;
    int   money;
    double totalTime;

    bool inOven;

    Stopwatch timer;

    // Start is called before the first frame update
    void Start()
    {
        btnNext = GameObject.Find("Next");
        btnNext.SetActive(false);
        // LOAD RECIPE FROM POOL

        goalRecipe = new int[] { 100, 3, 2, 1, 4, 3 , 5};
        initState();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateLevelTimer(timeRemaining);
        } else
        {
            EndGame();
        }

        if (inOven)
        {
            //totalTime += Time.deltaTime;
            //A: Setup and stuff you don't want timed
            //timer = new Stopwatch();
            //timer.Start();

            //B: Run stuff you want timed
            //timer.Stop();

            //TimeSpan timeTaken = timer.Elapsed;
            //string foo = "Time taken: " + timeTaken.ToString(@"m\:ss\.fff");
            //timeOvenLabel.GetComponent<Text>().text = foo;

            TimeSpan timeTaken = timer.Elapsed;
            string foo = "Time taken: " + timeTaken.ToString(@"m\:ss\.fff");
            //timeOvenLabel.GetComponent<Text>().text = foo;

            timeOvenLabel.GetComponent<Text>().text = timeTaken.TotalSeconds.ToString();
            UnityEngine.Debug.Log(timeTaken.TotalSeconds);
        }
    }

    public void initState ()
    {
        timeRemaining = 60f; // 1 MINUTE
        currentRecipe = new int[] { 0, 0, 0, 0, 0, 0, 0};
        money         = 0;
        inOven        = false;
        totalTime     = 0;
        timer         = new Stopwatch();


        table = GameObject.Find("Table");
        timeLabel     = GameObject.Find("Time");
        moneyLabel    = GameObject.Find("Money");
        timeOvenLabel = GameObject.Find("TimeOven");

        timeLabel.GetComponent<Text>().text     = "00 : 00";
        moneyLabel.GetComponent<Text>().text    = "0";
        timeOvenLabel.GetComponent<Text>().text = "-";

        step1 = GameObject.Find("Step1");
        step2 = GameObject.Find("Step2");
        step3 = GameObject.Find("Step3");
        step4 = GameObject.Find("Step4");
        step5 = GameObject.Find("Step5");
        step6 = GameObject.Find("Step6");

        step1.SetActive(false);
        step2.SetActive(false);
        step3.SetActive(false);
        step4.SetActive(false);
        step5.SetActive(false);
        step6.SetActive(false);

        btnFlour    = GameObject.Find("Flour")      .GetComponent<Button>();
        btnEgg      = GameObject.Find("Egg")        .GetComponent<Button>();
        btnMilk     = GameObject.Find("Milk")       .GetComponent<Button>();
        btnBerries  = GameObject.Find("Blueberries").GetComponent<Button>();
        btnSugar    = GameObject.Find("Sugar")      .GetComponent<Button>();


        btnFlour.onClick.AddListener(() => {
            AddIngredient(1);
            //OtherFunction(param);
        });

        btnEgg.onClick.AddListener(()       => { AddIngredient(2); });
        btnMilk.onClick.AddListener(()      => { AddIngredient(3); });
        btnBerries.onClick.AddListener(()   => { AddIngredient(4); });
        btnSugar.onClick.AddListener(()     => { AddIngredient(5); });

        btnOven = GameObject.Find("ToOven").GetComponent<Button>();
        btnOven.onClick.AddListener(Oven);
        btnOven.interactable = false;

        btnSell = GameObject.Find("ToSell").GetComponent<Button>();
        btnSell.onClick.AddListener(Sell);
        btnSell.interactable = false;

        i1 = GameObject.Find("Ingredient1");
        i2 = GameObject.Find("Ingredient2");
        i3 = GameObject.Find("Ingredient3");
        i4 = GameObject.Find("Ingredient4");
        i5 = GameObject.Find("Ingredient5");
        totalOven = GameObject.Find("TimeOvenRecipe");

        i1.GetComponent<Text>().text = "X " + goalRecipe[1].ToString();
        i2.GetComponent<Text>().text = "X " + goalRecipe[2].ToString();
        i3.GetComponent<Text>().text = "X " + goalRecipe[3].ToString();
        i4.GetComponent<Text>().text = "X " + goalRecipe[4].ToString();
        i5.GetComponent<Text>().text = "X " + goalRecipe[5].ToString();
        totalOven.GetComponent<Text>().text = goalRecipe[6].ToString() + " s";
    }

    private void AddIngredient(int i)
    {
        btnOven.interactable = true;
        //btnSell.interactable = true;

        step1.SetActive(false);
        step2.SetActive(false);
        step3.SetActive(false);
        step4.SetActive(false);
        step5.SetActive(false);
        step6.SetActive(false);

        switch (i)
        {
            case 1:
                step1.SetActive(true);
                currentRecipe[1] += 1;
                break;
            case 2:
                step2.SetActive(true);
                currentRecipe[2] += 1;
                break;
            case 3:
                step3.SetActive(true);
                currentRecipe[3] += 1;
                break;
            case 4:
                step4.SetActive(true);
                currentRecipe[4] += 1;
                break;
            case 5:
                step5.SetActive(true);
                currentRecipe[5] += 1;
                break;
        }

        UnityEngine.Debug.Log("Added ingredient!");

    }

    private void Oven()
    {
        
        if (inOven == false)
        {

            btnFlour.interactable   = false;
            btnEgg.interactable     = false;
            btnMilk.interactable    = false;
            btnSugar.interactable   = false;
            btnBerries.interactable = false;

            step1.SetActive(false);
            step2.SetActive(false);
            step3.SetActive(false);
            step4.SetActive(false);
            step5.SetActive(false);
            step6.SetActive(false);

            inOven = true;
            timer.Start();

            totalTime = 0;
            btnOven.GetComponentInChildren<Text>().text = "Detener";
            btnSell.interactable = false;
            //btnSell.GetComponentInChildren<Text>().text = "Detener y Vender";
            //btnSell.interactable = false;
        } else
        {
            step6.SetActive(true);
            inOven = false;
            timer.Stop();

            btnOven.GetComponentInChildren<Text>().text = "Hornear";

            TimeSpan timeTaken = timer.Elapsed;
            string foo = "Time taken: " + timeTaken.ToString(@"m\:ss\.fff");
            //timeOvenLabel.GetComponent<Text>().text = foo;

            totalTime = timeTaken.TotalSeconds;

            btnSell.interactable = true;
        }
        
    }

    private void Sell()
    {
        int finalPrice   = goalRecipe[0]; // SET FULL PRICE
        int accurateTime = goalRecipe[6]; // SET OVEN TIME


        for (int i = 1; i < 6; i++)
        {
            if (currentRecipe[i] != goalRecipe[i])
            {
                UnityEngine.Debug.Log("Current: " + currentRecipe[i] + "Goal:" + goalRecipe[i]);
                finalPrice -= 20;
            }
            //Console.WriteLine(i);
        }

        if (totalTime == accurateTime)
        {
            finalPrice += finalPrice * 10;
        }

        if (finalPrice < 0) {
            finalPrice = 0;
        }

        currentRecipe[0] = finalPrice;
        money += finalPrice;

        moneyLabel.GetComponent<Text>().text = money.ToString();

        newRecipe();
    }

    private void newRecipe()
    {
        currentRecipe = new int[] { 0, 0, 0, 0, 0, 0, 0 };
        btnSell.interactable = false;
        btnOven.interactable = false;
        inOven = false;
        totalTime = 0;
        timer = new Stopwatch();

        step1.SetActive(false);
        step2.SetActive(false);
        step3.SetActive(false);
        step4.SetActive(false);
        step5.SetActive(false);
        step6.SetActive(false);

        btnFlour.interactable   = true;
        btnEgg.interactable     = true;
        btnMilk.interactable    = true;
        btnSugar.interactable   = true;
        btnBerries.interactable = true;

        timeOvenLabel.GetComponent<Text>().text = "-";
    }

    private void UpdateLevelTimer(float totalSeconds)
    {
        int minutes = Mathf.FloorToInt(totalSeconds / 60f);
        int seconds = Mathf.RoundToInt(totalSeconds % 60f);

        string formatedSeconds = seconds.ToString();

        if (seconds == 60)
        {
            seconds = 0;
            minutes += 1;
        }

        string text = minutes.ToString("00") + ":" + seconds.ToString("00");
        timeLabel.GetComponent<Text>().text = text + " s";
    }

    private void EndGame()
    {
        btnFlour.interactable   = false;
        btnEgg.interactable     = false;
        btnMilk.interactable    = false;
        btnSugar.interactable   = false;
        btnBerries.interactable = false;
        btnOven.interactable    = false;
        btnSell.interactable    = false;

        timeLabel.GetComponent<Text>().text = "00 : 00";
        btnNext.SetActive(true);
    }

    public void Next()
    {
        UnityEngine.Debug.Log("next");
        SceneManager.UnloadSceneAsync("CookingScene");
        DialogueMotor.GoToDialogue(Dialogues.after);
    }

}
