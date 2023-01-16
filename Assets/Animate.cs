using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour 
{
	public Animation anim;
	private Vector3 previousPosition;
	void Start () 
	{
	  previousPosition = transform.position;
	}
	void Update () 
	{
	  if(transform.position == previousPosition)
	   {
	     if(!anim.IsPlaying("AngryIdle"))
	      {
	      	anim.Play("AngryIdle");
	      }
	   }
	  else
	   {
	   	 if(!anim.IsPlaying("Run"))
	      {
	      	anim.Play("Run");
	      }
	   }
	  previousPosition = transform.position;
	}
}
