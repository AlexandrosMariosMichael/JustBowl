using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BowllingPins : MonoBehaviour {

    public Transform pin;
    public int point = 1;

    public Score scoreUI;//mpori na 8eli allagi 

    private Vector3 initialPos;
    private Quaternion originalRotation;

    void Start()
    {
        initialPos = transform.position;
        originalRotation = transform.rotation;

    }


    public void ResetPin()
    {
   
            pin.position = initialPos;
            transform.position = pin.position;

            pin.rotation = originalRotation;
            transform.rotation = pin.rotation;

            pin.GetComponent<Rigidbody>().velocity = Vector3.zero;
            pin.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            gameObject.GetComponent<Collider>().enabled = true;
            pin.GetComponent<CapsuleCollider>().enabled = true;
      
    }

   public void PinFell()
    {
        pin.GetComponent<CapsuleCollider>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        scoreUI.Add(point);  
    

    }



    void FixedUpdate()
    {

        if (scoreUI.resetPin==true)
        {
            ResetPin();
        }
       
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainLane" || other.tag == "Deathzone" || other.tag == "MainSideBar")
        { 
            PinFell();       
        }

        if (other.tag == "MainBall")
        {
            scoreUI.audioPLay();
            
        }

        

    }









}
