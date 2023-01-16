using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Messaging : MonoBehaviour {

	// Use this for initialization
	public CarGenerator CarsScript;
	public GameObject menu;
	public Dropdown sendTo;
	public Text msg, Textarea;
	public Transform Received;
	public GameObject msgCanvas; 
	public void Start ()
	{ 
	  menu.SetActive(false);
	  CarsScript = GameObject.FindWithTag("Cars").GetComponent<CarGenerator>();
	}
	public void MsgButton ()
    {
      menu.SetActive(!menu.activeSelf);
    }
    public void MsgReceive (String m)
    { 
      msg.text = m;
      Instantiate(msg,Received);
    }
    public void send(String location)
    { 
      if ( location == "")
      {CarsScript.cars[sendTo.value].SendMessage("MsgReceive" , "from "+CarsScript.cars[CarsScript.i].name+": "+Textarea.text );}
      else
      {CarsScript.cars[sendTo.value].SendMessage("MsgReceive" , "from "+CarsScript.cars[CarsScript.i].name+": "+Textarea.text+ location );}
      Debug.Log("message sent from "+CarsScript.cars[CarsScript.i].name + " to " + CarsScript.cars[sendTo.value].name);

    }
    public void ShareLocation()
    {
      String location = " location :  " + CarsScript.cars[CarsScript.i].transform.position.ToString();
      Debug.Log("location shared!");
      send(location);
    }
	
	// Update is called once per frame
	void Update () 
	{ 	 
      if (CarsScript.cars[CarsScript.i].name == this.name)
      {
      	msgCanvas.SetActive(true);
      }
      else
       { 
       	msgCanvas.SetActive(false);
       }
	  sendTo.ClearOptions(); 
	  foreach (GameObject c in CarsScript.cars)
      {
      	Dropdown.OptionData option = new Dropdown.OptionData();
      	option.text = c.name;
      	sendTo.options.Add(option);
      }
		
	}
}
