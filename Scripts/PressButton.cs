using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Utility;

public class PressButton : MonoBehaviour {

    public AudioClip tapAudio;
    private AudioSource sourceAudio;
    public GameObject fSlider;
    private GameObject bowlingBall;

    public GameObject curveButtons;

    private GameObject aSlider;
    private Vector3 startPos;

    private float timer=0;
    private bool buttonPressed=false;

    private float rtimer = 0;
    private bool rightPressed = false;

    private float ltimer = 0;
    private bool leftPressed = false;




    private int clickCount = 0;

    private void Awake()
    {
        sourceAudio = GetComponent<AudioSource>();
        bowlingBall = GameObject.Find("Ball").gameObject;
        startPos = bowlingBall.transform.position;
        aSlider = GameObject.Find("AngleBar").gameObject;
       

    }



    public void LeftCurve()
    {
        bowlingBall.GetComponent<RollBall>().curve += 0.002f;// 0.5f;
      
    }

    public void RightCurve()
    {
        bowlingBall.GetComponent<RollBall>().curve += -0.002f;// -0.5f;

    }



    private void FixedUpdate()
    {

        if (buttonPressed == true)
        {
             timer += Time.deltaTime;
            
            if (timer > 0.2f)
            {
                GameObject.Find("TutorialsUI").GetComponent<TutorialsBehavior>().Tutorial5Off();
                GameObject.Find("TutorialsUI").GetComponent<TutorialsBehavior>().Tutorial6On();
                curveButtons.SetActive(true);
               
            }
            if (timer>0.2f && buttonPressed == false )
            {
                GameObject.Find("TutorialsUI").GetComponent<TutorialsBehavior>().Tutorial6Off();
                curveButtons.SetActive(false);;
            }
        }else if (buttonPressed == false && timer<0.2)
        {
            GameObject.Find("TutorialsUI").GetComponent<TutorialsBehavior>().Tutorial6Off();
            timer = 0;
        }


        if (rightPressed == true)
        {
             rtimer += Time.deltaTime;
             if (rtimer > 0.1f)
            {
                GameObject.Find("TutorialsUI").GetComponent<TutorialsBehavior>().Tutorial6Off();
                GameObject.Find("TutorialsUI").GetComponent<TutorialsBehavior>().Tutorial7On();
                GameObject.Find("UIGameManager").GetComponent<Score>().curveStrike = true;
            RightCurve();
        }
            

        }
        if (rtimer > 0.1f && rightPressed == false)
        {
            curveButtons.SetActive(false);
        }

        if (leftPressed == true)
        {
            ltimer += Time.deltaTime;
            if (ltimer > 0.1f)
            {
                GameObject.Find("TutorialsUI").GetComponent<TutorialsBehavior>().Tutorial6Off();
                GameObject.Find("TutorialsUI").GetComponent<TutorialsBehavior>().Tutorial7On();
                GameObject.Find("UIGameManager").GetComponent<Score>().curveStrike = true;
                LeftCurve();
            }            

        }
        if (ltimer > 0.1f && leftPressed == false)
        {
            curveButtons.SetActive(false);
        }








        if (GameObject.Find("AngleBar").GetComponent<PingPongSlider>().enabled == true)
        {
            GameObject.Find("Player").GetComponent<FollowTarget>().enabled = false;      
            bowlingBall.transform.position = new Vector3(((startPos.x + 1) - aSlider.GetComponent<Slider>().value), startPos.y, startPos.z);
         
        }


    }

    public void OnRightDown()
    {
        rightPressed = true;
    }
    public void OnRightUp()
    {
        rightPressed = false;
    }
    public void OnLeftDown()
    {
        leftPressed = true;
    }

    public void OnLeftUp()
    {
        leftPressed = false;
    }

    public void onbuttondown()
    {

        buttonPressed = true;
     ;

    }
    public void onbuttonup()
    {
        buttonPressed = false;
        

    }


        public void onPressButton(bool enable) {
       
        if (enabled==true)
        {
            clickCount += 1;
            onPressButtonAudio();
            switch (clickCount)
            {
                case 1:
                    {
                        timer = 0;
                        rtimer = 0;
                        ltimer = 0;
                        fSlider.SetActive(true);
                        GameObject.Find("UIGameManager").GetComponent<Score>().onModeadd();
                        GameObject.Find("AngleBar").GetComponent<PingPongSlider>().enabled = false;
                        GameObject.Find("TutorialsUI").GetComponent<TutorialsBehavior>().Tutorial4Off();
                        GameObject.Find("TutorialsUI").GetComponent<TutorialsBehavior>().Tutorial5On();
                        GameObject.Find("TutorialsUI").GetComponent<TutorialsBehavior>().Tutorial8Off();
                        break;
                    }
                case 2:
                    {
                        timer = 0;
                        rtimer = 0;
                        ltimer = 0;
                        GameObject.Find("TutorialsUI").GetComponent<TutorialsBehavior>().Tutorial6Off();
                        GameObject.Find("TutorialsUI").GetComponent<TutorialsBehavior>().Tutorial7Off();
                        GameObject.Find("TutorialsUI").GetComponent<TutorialsBehavior>().Tutorial8On();
                        GameObject.Find("TutorialsUI").GetComponent<TutorialsBehavior>().Tutorial10Off();
                        GameObject.Find("ForceBar").GetComponent<PingPongSlider>().enabled = false;
                        GameObject.Find("AngleBar").SetActive(false);
                        fSlider.SetActive(false);
                       
                        GameObject.Find("Ball").GetComponent<RollBall>().Roll();
                        GameObject.Find("PressButton").SetActive(false);
                        clickCount = 0;
                        enable = false;
                        GameObject.Find("Player").GetComponent<FollowTarget>().enabled = true;
                        break;
                    }
                default: break;
            }
           
        }
    }



  

    public void onPressButtonAudio()
    {
        sourceAudio.PlayOneShot(tapAudio, 1f);
    }

   
   
   
}
