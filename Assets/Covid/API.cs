using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class API : MonoBehaviour {
    const string url = "http://coronavirusapi.com/time_series.csv";

    void Start() {
        GetTimeData();
    }

    public void GetTimeData()
    {
        StartCoroutine(GetTimeDataRoutine());
    }

   IEnumerator GetTimeDataRoutine()
    {
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();
        if (request.isNetworkError)
        {
            Debug.Log("Not found");
        } else
        {
            ParseData(request.downloadHandler.text);
        }
    }

   List<TimeData> ParseData(string data)
    {
        List<string> lines = data.Split('\n').ToList();
        lines.RemoveAt(0);
        lines.RemoveAt(lines.Count - 1);
        List<TimeData> dataList = new List<TimeData>();
        foreach (string line in lines)
        {   List<string> lineData = line.Split(',').ToList();
            TimeData timeData = new TimeData
            {
                date = DateTime.Parse(lineData[0]),
                tested = int.Parse(lineData[3]),
                positives = int.Parse(lineData[4]),
                deaths = int.Parse(lineData[5])
            };
            dataList.Add(timeData);
          
        }

        return dataList;
       // Debug.Log(data);
    }

    // Use this for initialization
    
	
	// Update is called once per frame
	void Update () {
		
	}
}
