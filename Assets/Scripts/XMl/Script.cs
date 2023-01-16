using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
{
    public GameObject Citizen;
    public TextAsset csvFile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        readCSV();


    }
    void readCSV()
    {
        string[] records = csvFile.text.Split('\n');
        for(int i=1; i< records.Length; i++)
        {
            string[] fields = records[i].Split(',');
            Citizen.transform.Rotate(float.Parse(fields[1]), float.Parse(fields[2]), float.Parse(fields[3]));

        }
    }
}
