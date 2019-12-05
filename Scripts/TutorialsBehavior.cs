using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialsBehavior : MonoBehaviour {

    public GameObject strikeText1;
    public GameObject strikeText2;
    public GameObject strikeText3;

    public GameObject line1;
    public GameObject line2;

    public GameObject tutorialUI1;
    public GameObject tutorialUI2;
    public GameObject tutorialUI3;
    public GameObject tutorialUI4;
    public GameObject tutorialUI5;
    public GameObject tutorialUI6;
    public GameObject tutorialUI7;
    public GameObject tutorialUI8;
    public GameObject tutorialUI9;
    public GameObject tutorialUI10;



    private IEnumerator DelayText()
    {

        yield return new WaitForSeconds(3f);

        //oti prepi na gini meta pou 8a perimeni kalitera na mpeni edo

        StrikeText(false);
    }


    public void StrikeText(bool active)
    {
        if (active == true)
        {
            int temp = Random.Range(1, 3);
            switch (temp)
            {
                case 1:
                    {
                        strikeText1.SetActive(true);
                        break;
                    }
                case 2:
                    {
                        strikeText2.SetActive(true);
                        break;
                    }
                case 3:
                    {
                        strikeText3.SetActive(true);
                        break;
                    }
            }
            StartCoroutine(DelayText());
        }
        else
        {
            strikeText1.SetActive(false);
            strikeText2.SetActive(false);
            strikeText3.SetActive(false);
        }



    }
    void Awake() {
        if (GameObject.Find("GameManager").GetComponent<GameManager>().LoadTutorial() == true.ToString() || GameObject.Find("GameManager").GetComponent<GameManager>().LoadTutorial() == null)
        {
            tutorialUI1.SetActive(true);
            tutorialUI2.SetActive(true);
            tutorialUI3.SetActive(true);
            tutorialUI9.SetActive(true);
            line1.SetActive(true);
            line2.SetActive(false);
        }
        else
        {
            tutorialUI1.SetActive(false);
            tutorialUI2.SetActive(false);
            tutorialUI3.SetActive(false);
            tutorialUI9.SetActive(false);
            line1.SetActive(false);
            line2.SetActive(true);
        }
    }

    public void TutorialsToggle()
    {
        if (GameObject.Find("GameManager").GetComponent<GameManager>().LoadTutorial() == true.ToString() )
        {
            tutorialUI1.SetActive(true);
            tutorialUI2.SetActive(true);
            tutorialUI3.SetActive(true);
            tutorialUI9.SetActive(true);
            line1.SetActive(true);
            line2.SetActive(false);
        }
        else
        {
            line1.SetActive(false);
            line2.SetActive(true);
            tutorialUI1.SetActive(false);
            tutorialUI2.SetActive(false);
            tutorialUI3.SetActive(false);
            tutorialUI4.SetActive(false);
            tutorialUI5.SetActive(false);
            tutorialUI6.SetActive(false);
            tutorialUI7.SetActive(false);
            tutorialUI8.SetActive(false);
            tutorialUI9.SetActive(false);
            tutorialUI10.SetActive(false);
        }
    }
    /*

    public void TutorialOn(int num)
    {
        if (GameObject.Find("GameManager").GetComponent<GameManager>().LoadTutorial() == true.ToString())
        {
          //  temp = "TutorialText" + num.ToString();
           temp=  "tutorialUI" + num.ToString();
         //   GameObject.Find("TutorialsUI").GetComponent<TutorialsBehavior>().gameObjec= GameObject.Find("TutorialsUI").GetComponent<TutorialsBehavior>().temp;
           GameObject.Find(temp).SetActive(true);

        }
        else
        {
            temp = "TutorialText" + num.ToString();
             GameObject.Find(temp).SetActive(false);

        }
    }

    public void TutorialOff(int num)
    {
        if (GameObject.Find("GameManager").GetComponent<GameManager>().LoadTutorial() == true.ToString())
        {
            temp = "TutorialText" + num.ToString();
             GameObject.Find(temp).SetActive(false);

        }
        else
        {
            temp = "TutorialText" + num.ToString();
            GameObject.Find(temp).SetActive(false);

        }
    }



    */


    public void Tutorial4On()
    {
        if (GameObject.Find("GameManager").GetComponent<GameManager>().LoadTutorial() == true.ToString())
        {
            tutorialUI4.SetActive(true);
            
        }
        else
        {
            tutorialUI4.SetActive(false);
            
        }
    }

    public void Tutorial4Off()
    {
        if (GameObject.Find("GameManager").GetComponent<GameManager>().LoadTutorial() == true.ToString())
        {
            tutorialUI4.SetActive(false);

        }
        else
        {
            tutorialUI4.SetActive(false);

        }
    }

    public void Tutorial5On()
    {
        if (GameObject.Find("GameManager").GetComponent<GameManager>().LoadTutorial() == true.ToString())
        {
            tutorialUI5.SetActive(true);

        }
        else
        {
            tutorialUI5.SetActive(false);

        }
    }
    public void Tutorial5Off()
    {
        if (GameObject.Find("GameManager").GetComponent<GameManager>().LoadTutorial() == true.ToString())
        {
            tutorialUI5.SetActive(false);

        }
        else
        {
            tutorialUI5.SetActive(false);

        }
    }

    public void Tutorial6On()
    {
        if (GameObject.Find("GameManager").GetComponent<GameManager>().LoadTutorial() == true.ToString())
        {
            tutorialUI6.SetActive(true);

        }
        else
        {
            tutorialUI6.SetActive(false);

        }
    }

    public void Tutorial6Off()
    {
        if (GameObject.Find("GameManager").GetComponent<GameManager>().LoadTutorial() == true.ToString())
        {
            tutorialUI6.SetActive(false);

        }
        else
        {
            tutorialUI6.SetActive(false);

        }
    }

    public void Tutorial7On()
    {
        if (GameObject.Find("GameManager").GetComponent<GameManager>().LoadTutorial() == true.ToString())
        {
            tutorialUI7.SetActive(true);

        }
        else
        {
            tutorialUI7.SetActive(false);

        }
    }

    public void Tutorial7Off()
    {
        if (GameObject.Find("GameManager").GetComponent<GameManager>().LoadTutorial() == true.ToString())
        {
            tutorialUI7.SetActive(false);

        }
        else
        {
            tutorialUI7.SetActive(false);

        }
    }


    public void Tutorial8On()
    {
        if (GameObject.Find("GameManager").GetComponent<GameManager>().LoadTutorial() == true.ToString())
        {
            tutorialUI8.SetActive(true);

        }
        else
        {
            tutorialUI8.SetActive(false);

        }
    }

    public void Tutorial8Off()
    {
        if (GameObject.Find("GameManager").GetComponent<GameManager>().LoadTutorial() == true.ToString())
        {
            tutorialUI8.SetActive(false);

        }
        else
        {
            tutorialUI8.SetActive(false);

        }
    }

    public void Tutorial10On()
    {
        if (GameObject.Find("GameManager").GetComponent<GameManager>().LoadTutorial() == true.ToString())
        {
            tutorialUI10.SetActive(true);

        }
        else
        {
            tutorialUI10.SetActive(false);

        }
    }

    public void Tutorial10Off()
    {
        if (GameObject.Find("GameManager").GetComponent<GameManager>().LoadTutorial() == true.ToString())
        {
            tutorialUI10.SetActive(false);

        }
        else
        {
            tutorialUI10.SetActive(false);

        }
    }




}
