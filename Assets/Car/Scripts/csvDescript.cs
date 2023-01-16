using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class csvDescript : MonoBehaviour
{
    public ModelGenerator Script;
    public GameObject Citizen;
    //public GameObject[] Citizens;
    // Use this for initialization
    void Start()
    {
        ReadCSVFile();
    }

    void ReadCSVFile()
    {
        StreamReader strReader = new StreamReader("C:\\Users\\roura\\Music\\27juin20Bike\\Assets\\Resources\\ExampleCSV.csv");
        bool endOfFile = false;
        while (!endOfFile)
        {

            string data_string = strReader.ReadLine();
            if (data_string == null)
            {
                endOfFile = true;
                break;
            }
            var data_values = data_string.Split(',');
            /* for (int o = 0; o < data_values.Length; o++)
             {
                 Debug.Log("Value:" + o.ToString() + "" + data_values[o].ToString());
             }*/
            Debug.Log(data_values[0].ToString() + "" + data_values[1].ToString() + "" + data_values[3].ToString() + "" + data_values[4].ToString() + "" + data_values[5].ToString() + "" + data_values[6].ToString() + "");

            if (data_values[1].ToString() == Citizen.tag)
            {
                Instantiate(Citizen, new Vector3(0, 0, 0), Quaternion.identity);
            }
            else
            {
                Debug.Log("Not found");
            }


        }
    }
}
