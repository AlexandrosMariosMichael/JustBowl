using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlayScript : MonoBehaviour {




    public GameObject aslider;
    public GameObject player;
    public GameObject pressB;
    public GameObject panel1;
    public GameObject panel2;
    public GameObject backB;
    public GameObject levelP;
    public GameObject gutters;
    public GameObject rails;
    public GameObject aiscore;
    public GameObject ground;
    public GameObject pvpwarning;
    public GameObject underscore1;
    public GameObject underscore2;
    public GameObject tutorialtogglebutton;//new

 
    public void playButton(bool enable)
    {
        if (enable == true)
        {
            if (GameObject.Find("PvPButton").GetComponent<Button>().interactable == false && GameObject.Find("GameManager").GetComponent<GameManager>().LoadLevel() < 10)
            {
                pvpwarning.SetActive(true);
            }
            if (GameObject.Find("PvPButton").GetComponent<Button>().interactable == false && GameObject.Find("GameManager").GetComponent<GameManager>().LoadLevel()>=10)
            {
                GameObject.Find("PlayButton").SetActive(false);
                GameObject.Find("PvPButton").SetActive(false);
                GameObject.Find("AIButton").SetActive(false);
                GameObject.Find("MusicSlider").SetActive(false);
                aslider.SetActive(true);
                player.SetActive(true);
                GameObject.Find("MenuCamera").SetActive(false);
                pressB.SetActive(true);
                backB.SetActive(true);
                GameObject.Find("DifficultyToggle").SetActive(false);
                pvpwarning.SetActive(false);
                pressB.GetComponent<AudioSource>().volume = GameObject.Find("GameManager").GetComponent<GameManager>().LoadVolume();
                if (GameObject.Find("GameManager").GetComponent<GameManager>().LoadTutorial() == true.ToString())
                {
                    tutorialtogglebutton.SetActive(true);
                }
                else
                {
                    tutorialtogglebutton.SetActive(false);
                }
                GameObject.Find("TutorialsUI").GetComponent<TutorialsBehavior>().tutorialUI9.SetActive(false);
                GameObject.Find("TutorialsUI").GetComponent<TutorialsBehavior>().Tutorial4On();
                GameObject.Find("TutorialsUI").GetComponent<TutorialsBehavior>().Tutorial10On();
                GameObject.Find("StatsText").SetActive(false);

                //unique
                GameObject.Find("AngleBar").GetComponent<PingPongSlider>().speed = 10;
                panel1.SetActive(true);
                panel2.SetActive(true);
                GameObject.Find("UIGameManager").GetComponent<Score>().pvpMode = true;
                GameObject.Find("UIGameManager").GetComponent<Score>().aiMode = false;
                GameObject.Find("UIGameManager").GetComponent<Score>().playerNum = 2;//pvp number of players
                GameObject.Find("UIGameManager").GetComponent<Score>().StartScore();


            }
            else if (GameObject.Find("AIButton").GetComponent<Button>().interactable == false)
            {
                GameObject.Find("PlayButton").SetActive(false);
                GameObject.Find("PvPButton").SetActive(false);
                GameObject.Find("AIButton").SetActive(false);
                GameObject.Find("MusicSlider").SetActive(false);
                aslider.SetActive(true);
                player.SetActive(true);
                GameObject.Find("MenuCamera").SetActive(false);
                pressB.SetActive(true);
                backB.SetActive(true);
                GameObject.Find("DifficultyToggle").SetActive(false);
                pvpwarning.SetActive(false);
                pressB.GetComponent<AudioSource>().volume = GameObject.Find("GameManager").GetComponent<GameManager>().LoadVolume();
                if (GameObject.Find("GameManager").GetComponent<GameManager>().LoadTutorial() == true.ToString())
                {
                    tutorialtogglebutton.SetActive(true);
                }
                else
                {
                    tutorialtogglebutton.SetActive(false);
                }
                GameObject.Find("TutorialsUI").GetComponent<TutorialsBehavior>().tutorialUI9.SetActive(false);
                GameObject.Find("TutorialsUI").GetComponent<TutorialsBehavior>().Tutorial4On();
                GameObject.Find("TutorialsUI").GetComponent<TutorialsBehavior>().Tutorial10On();
                GameObject.Find("StatsText").SetActive(false);

                //unique   
                aiscore.SetActive(true);
                GameObject.Find("AngleBar").GetComponent<PingPongSlider>().speed = 1;
                levelP.SetActive(true);
                GameObject.Find("UIGameManager").GetComponent<Score>().aiMode = true;
                GameObject.Find("UIGameManager").GetComponent<Score>().pvpMode = false;
                GameObject.Find("UIGameManager").GetComponent<Score>().playerNum = 1;
                GameObject.Find("UIGameManager").GetComponent<Score>().StartScore();
            }





        }
        enable = false;
    }



    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }


    public void ToggleDifficulty ()
    {
        if (GameObject.Find("DifficultyToggle").GetComponent<Toggle>().isOn == true)
        {
            gutters.SetActive(true);
            rails.SetActive(false);
            ground.SetActive(false);
            underscore1.SetActive(false);
            underscore2.SetActive(true);
        }
        else
        {
            gutters.SetActive(false);
            rails.SetActive(true);
            ground.SetActive(true);
            underscore1.SetActive(true);
            underscore2.SetActive(false);
        }
       
    }
  

  
}
