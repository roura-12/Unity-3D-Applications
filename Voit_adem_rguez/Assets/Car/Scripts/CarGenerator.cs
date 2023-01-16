using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mapbox.Unity.Map;
using Mapbox.Examples;
using System;
using Mapbox.Unity.Location;
using UnityEngine.SceneManagement;
public class CarGenerator : MonoBehaviour 
{
  
	public GameObject car, camera; 
	private GameObject newcar,newcam;
	public Camera cam ;
	public int i=0 , j=0;
	public Text location , nbrCars , currentCar;
	public AbstractMap map;
	public GameObject[] cars , cams;
	private int l;
	public Transform par;
	public EditorLocationProvider elp;
	
	void Start() {}

	void FixedUpdate()
	{ Debug.Log("current car index : " + i);
	  cars = new GameObject[GameObject.FindGameObjectsWithTag("Car").Length];
	  cars = GameObject.FindGameObjectsWithTag("Car");
	  cams = GameObject.FindGameObjectsWithTag("MainCamera");
	  Vector3 v = cars[i].transform.position;
	  location.text = v.ToString();
	  nbrCars.text = l.ToString();
	  currentCar.text = "car : " + (i+1).ToString() ;
	  l = GameObject.FindGameObjectsWithTag("Car").Length;
	  DisableOthers(i);
	  cams[i].transform.position = new Vector3(v.x-100.4657f,v.y+327.6001f,v.z-445.4682f);
	  cars[i].GetComponent<AstronautMouseController>().character = cars[i];
	  //cars[i].GetComponent<AstronautMouseController>().CamControl();
	 

	}
	public void AddCar () 
	{
	  newcar = Instantiate(car, new Vector3(0, 0, 0)  , Quaternion.identity);
	  newcar.transform.parent = this.transform;
	  j++;
	  newcar.name = "car" + (l+1).ToString();
	  newcam = Instantiate(camera, new Vector3(-100.4657f,327.6001f,-445.4682f) , camera.transform.rotation);
	  newcam.transform.parent = par;
	  newcar.GetComponent<AstronautMouseController>().map = map ; 	
	  newcar.GetComponent<AstronautMouseController>().cam = newcam.GetComponent<Camera>(); 	  
      newcar.GetComponent<AstronautMouseController>().enabled = false ; 
	  newcar.GetComponent<AstronautDirections>().enabled = false ;
      newcar.GetComponent<CharacterMovement>().enabled = false ;
      newcam.GetComponent<Camera>().enabled = false ; 
    }
	public void Right()
	{ 
      Debug.Log("swiping right");
	  if (i<l-1)
	   {
	   	i++;
	   }
	  else
	   {i = 0 ;}
	  Debug.Log("right button clicked! ");
	}
	public void Left()
	{ 
	  
      Debug.Log("swiping left");
      if ( i > 0 )
	   {
	    i--;
	   }
	  else 
	   {
	   	i=l-1;
	   }
	}
	
	

    private void DisableOthers(int x) 
    {
      //cam.transform.position = new Vector3(cars[x].transform.position.x,cam.transform.position.y,cars[x].transform.position.z);
      cars[x].GetComponent<AstronautDirections>().enabled = true ;
      cars[x].GetComponent<CharacterMovement>().enabled = true ;
      cars[x].GetComponent<AstronautMouseController>().enabled = true;
      cams[x].GetComponent<Camera>().enabled = true ; 



      for (int j = 0 ; j<l ; j++)
       { 
         if (j != x )
         {
           cars[j].GetComponent<AstronautMouseController>().enabled = false;
           cars[j].GetComponent<AstronautDirections>().enabled = false ;
           cars[j].GetComponent<CharacterMovement>().enabled = false ;
           cams[j].GetComponent<Camera>().enabled = false ;

         }
       }
      Debug.Log("#"+x+" is the active camera ");
    }
    public void Replay ()
	{ 
	  SceneManager.LoadScene(0);
	  Debug.Log("Scene restarestarted!");
	}


}