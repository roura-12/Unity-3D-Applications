using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Map;

public class scaling : MonoBehaviour {
    public AbstractMap map;
	void Start () 
	{
     map = GameObject.FindWithTag("Map").GetComponent<AbstractMap>();
	}
	void Update ()
	{
	 transform.localScale = 30f*Vector3.one * Mathf.Pow(2, map.differenceInZoom);
	}
}
