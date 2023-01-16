using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Messaging : MonoBehaviour {

	// Use this for initialization
	private ModelGenerator script;
	public GameObject menu;
	public Dropdown sendTo;
	public Text msg, Textarea;
	public Transform Received;
	public GameObject msgCanvas; 
	public void Start ()
	{ 
	  menu.SetActive(false);
	  script = GameObject.FindWithTag("Models").GetComponent<ModelGenerator>();
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
          {script.models[sendTo.value].SendMessage("MsgReceive" , "from "+script.models[script.i].name+": "+Textarea.text );}
          else
          {script.models[sendTo.value].SendMessage("MsgReceive" , "from "+script.models[script.i].name+": "+Textarea.text+ location );}
          Debug.Log("message sent from "+script.models[script.i].name + " to " + script.models[sendTo.value].name);

        }
        public void ShareLocation()
        {
          String location = " location :  " + script.models[script.i].transform.position.ToString();
          Debug.Log("location shared!");
          send(location);
        }

        // Update is called once per frame
        void Update () 
        { 	 
          if (script.models[script.i].name == this.name)
          {
            msgCanvas.SetActive(true);
          }
          else
           { 
            msgCanvas.SetActive(false);
           }
          sendTo.ClearOptions(); 
          foreach (GameObject c in script.models)
          {
            Dropdown.OptionData option = new Dropdown.OptionData();
            option.text = c.name;
            sendTo.options.Add(option);
          }

        }
}
