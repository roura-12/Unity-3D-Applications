using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Character", menuName ="Character")]
public class Charater : ScriptableObject {
    public string characterName = "New character";
    public int characterAge;
    public enum Sex { Male, Female}
    public Sex sex;
    public string Temperature;
    public enum HealthState { Safe, Suspected_Infected };
    public HealthState healthstate;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
