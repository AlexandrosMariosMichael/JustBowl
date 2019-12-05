using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour {



    public AudioClip pinClip;
    public AudioClip strikeclap;
    private AudioSource pinCrash;

    private int audioCount = 0;
    public int playerNum;
    private int[] score;
    private int[] mainScore;
    private int playerTurn=1;
    private int frame = 1;
    private int playerLevelcount = 1;
    private int maxlevel;
    private int maxscore;
    private int fspeed = 30;
    private float bspeed = 1f;
    private float delta = 100f;
    public bool curveStrike = false;

    // private int[] consecutiveStrikes;
    // private bool[] prevFrameStrike;
    //mpori na min xriazonte ta kato
    private int[] firstThrowScore;

    private string temp;

   
    public bool pvpMode = false;
    public bool aiMode = false;
    private bool strike = false;
    public bool resetPin = false;

    private Vector3 startPosB;
    private Vector3 tempStartPosB;
    private GameObject pressB;
    private GameObject playerPanel;
    private GameObject playerMainScore;
    private GameObject playerPanelScore;
    private GameObject playerPanelScoreType;
    private GameObject playerLevel;



    
    public void Add (int amount)
    {
        score[playerTurn - 1] += amount;     

    }



    public void audioPLay()
    {
         audioCount += 1;//ine gia na pezi mono mia fora
        if (audioCount == 1 && GameObject.FindGameObjectWithTag("MainBall").GetComponent<RollBall>().ballThrows == 0)
        {     
                pinCrash.Play();          

        }
        else if (GameObject.FindGameObjectWithTag("MainBall").GetComponent<RollBall>().ballThrows == 1)//and score>5
        {
            pinCrash.PlayOneShot(pinClip, 0.7f);
        }
    }


    public	void StartScore ()
    {

        maxlevel = GameObject.Find("GameManager").GetComponent<GameManager>().LoadLevel();
        maxscore = GameObject.Find("GameManager").GetComponent<GameManager>().LoadScore();
        if (aiMode == true)
        {
            pressB = GameObject.Find("PressButton").gameObject;
            startPosB = pressB.transform.position;
            tempStartPosB = startPosB;
            if (playerLevelcount == 1)
            {
                try
                {
                    GameObject.Find("AngleBar").GetComponent<PingPongSlider>().speed = 1;
                }
                catch { }
                fspeed = 50;
                pressB.transform.position = startPosB;
            }
        }

        pinCrash = GetComponent<AudioSource>();     
        score = new int[playerNum];
        mainScore = new int[playerNum];
        firstThrowScore = new int[playerNum];
       // consecutiveStrikes = new int[playerNum];
       // prevFrameStrike = new bool[playerNum];
        for (int i = 0; i < playerNum; i++)
        {
            score[i] = 0;
          //  prevFrameStrike[i] = false;

        }

    }

	


    void PvpModeScore()
    {

     

        temp="PanelPlayer" + playerTurn.ToString();
        playerPanel = GameObject.Find(temp).gameObject;
        playerMainScore = playerPanel.transform.Find("PanelScoreMain").gameObject;
        if (frame <= 10)
        {
            temp = "PlayerPanelScore" + frame.ToString();
            playerPanelScore = playerPanel.transform.Find(temp).gameObject;
            playerPanelScoreType = playerPanelScore.transform.Find("PanelScoreMini").gameObject;
            playerMainScore.GetComponentInChildren<Text>().text = mainScore[playerTurn - 1].ToString();
            playerPanelScore.GetComponentInChildren<Text>().text = score[playerTurn - 1].ToString();

            CheckStrike();
        }
        else
        {
            
            temp = "TotalScore" + playerTurn.ToString();
            playerPanelScore =GameObject.Find(temp).gameObject; 
            playerPanelScore.GetComponent<Text> ().text = mainScore[playerTurn - 1].ToString();
        }

        
        



    }
	
	

    void CheckStrike()
    {


        if (pvpMode == true)
        {

            if (GameObject.FindGameObjectWithTag("MainBall").GetComponent<RollBall>().ballThrows == 1)
            {

                firstThrowScore[playerTurn - 1] = score[playerTurn - 1];
            }
            if (score[playerTurn - 1] == 10 && GameObject.FindGameObjectWithTag("MainBall").GetComponent<RollBall>().ballThrows == 1)
            {
                GameObject.Find("TutorialsUI").GetComponent<TutorialsBehavior>().StrikeText(true);
                pinCrash.PlayOneShot(strikeclap, 0.5f);
                /* prevFrameStrike[playerTurn - 1] = true;
                 if (prevFrameStrike[playerTurn-1] == true)
                 {
                     consecutiveStrikes[playerTurn - 1] += 1;
                 }*/

                score[playerTurn - 1] += 10;
                strike = true;
                playerPanelScoreType.GetComponentInChildren<Text>().text = "X";

            }
            else if (score[playerTurn - 1] == 10 && GameObject.FindGameObjectWithTag("MainBall").GetComponent<RollBall>().ballThrows == 2)
            {
                score[playerTurn - 1] += 5;
                playerPanelScoreType.GetComponentInChildren<Text>().text = "/";
            }/*else
                 {
                        // prevFrameStrike[playerTurn - 1] = false;
                 }*/


        }
        else if (aiMode == true)
        {
              if (score[playerTurn - 1] == 10 && GameObject.FindGameObjectWithTag("MainBall").GetComponent<RollBall>().ballThrows == 1)
              {
                GameObject.Find("TutorialsUI").GetComponent<TutorialsBehavior>().StrikeText(true);
                pinCrash.PlayOneShot(strikeclap, 0.5f);
                strike = true;
            }
            else
            {
                strike = false;
            }
        }
    }




    private IEnumerator Delay()
    {

        yield return new WaitForSeconds(0.30f);
        resetPin = false;
        strike = false;

        //oti prepi na gini meta pou 8a perimeni kalitera na mpeni edo


    }

    public void onModeadd()
    {
        if (pvpMode == true)
        {
            GameObject.Find("ForceBar").GetComponent<PingPongSlider>().speed = 300;
        }
        else if (aiMode == true)
        {
            GameObject.Find("ForceBar").GetComponent<PingPongSlider>().pos = 0;
            GameObject.Find("ForceBar").GetComponent<PingPongSlider>().speed = fspeed;
        }

    }

    private void FixedUpdate()
    {
       
        if (aiMode == true)
        {
            if (playerLevelcount > 10)
            {
                try
                {
                    tempStartPosB.x += delta * Mathf.Sin(Time.time * bspeed);
                    pressB.transform.position = new Vector3(tempStartPosB.x, pressB.transform.position.y, pressB.transform.position.z);
                }
                catch { }
            }
            else if (playerLevelcount > 25)
            {
                try
                {
                    tempStartPosB.x += delta * Mathf.Sin(Time.time * bspeed);
                    tempStartPosB.y += delta * Mathf.Sin(Time.time * bspeed);
                    pressB.transform.position = new Vector3(tempStartPosB.x, tempStartPosB.y, pressB.transform.position.z);
                }
                catch { }

            }

        }


        
    }


    public void AiModeScore()
    {
        CheckStrike();

        if (strike==true) {
            playerLevelcount += 1;
            if (playerLevelcount > maxlevel)
            {
                maxlevel = playerLevelcount;
                GameObject.Find("GameManager").GetComponent<GameManager>().SaveLevel(maxlevel);
            }
            
            mainScore[playerTurn - 1] += score[playerTurn - 1];
            if (mainScore[playerTurn - 1]>maxscore)
            {
                maxscore = mainScore[playerTurn - 1];
                GameObject.Find("GameManager").GetComponent<GameManager>().SaveScore(mainScore[playerTurn - 1]);
            }
            if (curveStrike == true)
            {
                mainScore[playerTurn - 1] += 20;
                curveStrike = false;
            }


            if (playerLevelcount <= 10)
            {
                GameObject.Find("AngleBar").GetComponent<PingPongSlider>().speed += 1;
                fspeed += 30;
            }else if (playerLevelcount >= 10 )
            {
                
                bspeed += 0.5f;
               // delta += 25f;
            }


        }
        else if (strike == false)
        {
            mainScore[playerTurn - 1] = 0;
            playerLevelcount = 1;
            curveStrike = false;
            GameObject.Find("AngleBar").GetComponent<PingPongSlider>().speed = 1;
            fspeed = 30;
             bspeed = 1f;
            delta = 100f;
        }
        playerLevel = GameObject.Find("LevelNum");
        playerLevel.GetComponent<Text>().text = playerLevelcount.ToString();
        GameObject.Find("ScoreNumText").GetComponent<Text>().text = mainScore[playerTurn - 1].ToString();

    }




    public void BowlUpdate()
    {
        
        audioCount = 0;
        if (aiMode == true)
        {              
            AiModeScore();
            resetPin = true;
            StartCoroutine(Delay());
            GameObject.FindGameObjectWithTag("MainBall").GetComponent<RollBall>().ballThrows = 0;
            score[playerTurn - 1] = 0;
        }
        else if (pvpMode == true)
        {
            PvpModeScore();
            if (GameObject.FindGameObjectWithTag("MainBall").GetComponent<RollBall>().ballThrows == 2 || strike == true)
            {
                /*
                switch (consecutiveStrikes[playerTurn - 1])
                {
                    case 1: {
                            score[playerTurn - 1]+= score[playerTurn - 1];//8a prepi na kani tou epomenuo pros8esi 
                            break;//8a ipologizete to mainscore katalila gia ka8e frame 
                     }
                }
                */

                mainScore[playerTurn - 1] += score[playerTurn - 1];
                resetPin = true;
                StartCoroutine(Delay());
                GameObject.FindGameObjectWithTag("MainBall").GetComponent<RollBall>().ballThrows = 0;
                score[playerTurn - 1] = 0;
                if (playerTurn == playerNum)
                {
                    frame += 1;
                    playerTurn = 1;
                }
                else
                {
                    playerTurn += 1;
                }


            }
        }

        
    }
    
}




