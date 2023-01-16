using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Map;

public class scaling : MonoBehaviour {
    public AbstractMap map;
	// Use this for initialization
	void Start () {
     map = GameObject.FindWithTag("Map").GetComponent<AbstractMap>();
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = 30f*Vector3.one * Mathf.Pow(2, map.differenceInZoom);
		
	}
}
