using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {


  private  bool choice = true;


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        GameObject.Find("MusicSlider").GetComponent<Slider>().value = LoadVolume();


        GameObject.Find("BackroundAudioSource").GetComponent<AudioSource>().volume = LoadVolume();  //mpori ke na alla3i an exi lista me songs
        GameObject.Find("Ball").GetComponent<AudioSource>().volume = LoadVolume();
        GameObject.Find("HighestLevelTextNum").GetComponent<Text>().text = LoadLevel().ToString();
        GameObject.Find("BestScoreTextNum").GetComponent<Text>().text = LoadScore().ToString();

        GameObject.Find("UIGameManager").GetComponent<AudioSource>().volume = LoadVolume();
       

    }

    public void UpdateVolume()
    {
         
       SaveVolume(GameObject.Find("MusicSlider").GetComponent<Slider>().value);
        
    }

    public void SaveScore(int totalscore)
    {
        PlayerPrefs.SetInt("SAVESCORE", totalscore);
    }

    public int LoadScore()
    {
        return PlayerPrefs.GetInt("SAVESCORE");
    }


    public void SaveTutorial()
    {
        choice = GameObject.Find("TutorialsToggle").GetComponent<Toggle>().isOn;
        PlayerPrefs.SetString("SAVETUTORIAL", choice.ToString());
    }

    public string LoadTutorial()
    {
        return PlayerPrefs.GetString("SAVETUTORIAL");
    }


    public void SaveVolume(float volume)
    {
        PlayerPrefs.SetFloat("SAVEVOLUME", volume);
    }
    public float LoadVolume()
    {
        return PlayerPrefs.GetFloat("SAVEVOLUME");
    }

    public void SaveLevel(int level)
    {
        PlayerPrefs.SetInt("SAVEFILE", level);
    }
    public int LoadLevel()
    {
        return PlayerPrefs.GetInt("SAVEFILE");
    }

    
}
