using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOrShow : MonoBehaviour 
{
    private GameObject menu ; 
    public GameObject previewCanvas;
	void Start () 
	{
	  menu = transform.GetChild(0).gameObject;	
	}
	void Update()
	{
      previewCanvas.SetActive(menu.activeSelf);
	}
	public void OnClickHideOrShow()
	{
      menu.SetActive(!menu.activeSelf);
	}
}
