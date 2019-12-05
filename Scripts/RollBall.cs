using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollBall : MonoBehaviour {

    


    public float waitime=10f;
    public Transform bowlingBall;
    public int ballThrows=0;
    public float curve=0;
    private float spin;

    public AudioClip ballRolling;
    private AudioSource rollAudio;
    private float lowVol=.5f;
    private float highVol=1.0f;

    public GameObject fSlider;
    public GameObject aSlider;
    public GameObject b1;

    Vector3 startPosition;
    

     bool rolliing = false;
   
    void Start()
    {
        startPosition = transform.position;
        rollAudio = GetComponent<AudioSource>();
     
    }



      void FixedUpdate()
    {
       

        if (rolliing == true)
        {

             GetComponent<Rigidbody>().AddForce(curve, 0, 0, ForceMode.Impulse); //douleui 0.2f
            //
            spin = Random.Range(-13f, 13f);
            GetComponent<Rigidbody>().AddRelativeTorque(0, spin, 0, ForceMode.Force);//douleui -10
                                                                                         
        }

        
    }
    public void Roll()
    {

                float vol = Random.Range(lowVol, highVol);
                rollAudio.PlayOneShot(ballRolling, vol);
       
                bowlingBall.GetComponent<Rigidbody>().isKinematic = false;

                bowlingBall.position = new Vector3(((startPosition.x + 1.3f) - aSlider.GetComponent<Slider>().value), startPosition.y, startPosition.z);
                transform.position = bowlingBall.position;

                GetComponent<Rigidbody>().AddForce(0, 0, -fSlider.GetComponent<Slider>().value, ForceMode.Impulse);
                rolliing = true;
       

                StartCoroutine(Delay(waitime));
               
       

    }

    private IEnumerator Delay(float waittime)
    {

        yield return new WaitForSeconds(waittime);
        ResetBall();

    }




   

      public  void ResetBall()
    {

        bowlingBall.position = startPosition;
        transform.position = bowlingBall.position;

        

        bowlingBall.GetComponent<Rigidbody>().velocity = Vector3.zero;
        bowlingBall.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;


       
        aSlider.SetActive(true);
        aSlider.GetComponent<PingPongSlider>().enabled = true;
        b1.SetActive(true);
        fSlider.GetComponent<PingPongSlider>().enabled = true;

        bowlingBall.GetComponent<Rigidbody>().isKinematic = true;


        ballThrows += 1;       


        GameObject.Find("UIGameManager").GetComponent<Score>().BowlUpdate();

        curve = 0;
        rolliing = false;//new
        

    }
    }

