using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mapbox.Unity.Map;
using Mapbox.Examples;
using System;
using Mapbox.Unity.Location;
using UnityEngine.SceneManagement;
public class ModelGenerator : MonoBehaviour
{
    public GameObject camera, nearbyCam;
    private GameObject newModel, newcam;
    public Camera cam;
    public int i = 0, j = 0;
    public Text location, nbrModels, currentModel;
    public AbstractMap map;
    public List<GameObject> models, modelsPrefabs;
    private int l;
    public EditorLocationProvider elp;
    public List<string> tags;
    public Dropdown choices;
    public Transform previewCanvas;


    void Start()
    {

        cam.transform.position = new Vector3(-100.4657f, 327.6001f, -445.4682f);
       UpdateCreationDropdown();
        SyncChoiceWithPreview();
    }

    void FixedUpdate()
    {
       // Debug.Log("current models index : " + i);
        models = new List<GameObject>();
       SyncChoiceWithPreview();
        foreach (string tag in tags)
        {
            models.AddRange(GameObject.FindGameObjectsWithTag(tag));
        }
        Vector3 v = models[i].transform.position;




        location.text = v.ToString();
        nbrModels.text = l.ToString();
        currentModel.text = models[i].name;
        l = models.Count;
        DisableOthers(i);
        cam.transform.position = new Vector3(v.x - 100.4657f, v.y + 327.6001f, v.z - 445.4682f);
        models[i].GetComponent<AstronautMouseController>().character = models[i];
        //cars[i].GetComponent<AstronautMouseController>().CamControl();
        UpdateCreationDropdown();

    }
   public void AddModel()
    {
        newModel = Instantiate(modelsPrefabs[choices.value], new Vector3(0, 0, 0), Quaternion.identity);
        newModel.transform.parent = this.transform;
        j++;
        newModel.name = modelsPrefabs[choices.value].name + (l + 1).ToString();
        /* newcam = Instantiate(camera, new Vector3(-100.4657f,327.6001f,-445.4682f) , camera.transform.rotation);
         newcam.transform.parent = par;*/
        newModel.GetComponent<AstronautMouseController>().enabled = false;
        newModel.GetComponent<AstronautMouseController>().map = map;
        newModel.GetComponent<AstronautMouseController>().cam = cam.GetComponent<Camera>();
        newModel.GetComponent<AstronautDirections>().enabled = false;
        newModel.GetComponent<CharacterMovement>().enabled = false;
        if (nearbyCam.activeSelf == true)
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                nearbyCam.transform.Rotate(0, Input.GetAxis("Horizontal"), 0);
            }
        }
        //newcam.GetComponent<Camera>().enabled = false ; 
   }
    public void Right()
    {
        Debug.Log("swiping right");
        if (i < l - 1)
        {
            i++;
        }
        else
        { i = 0; }
        Debug.Log("right button clicked! ");
    }
    public void Left()
    {

        Debug.Log("swiping left");
        if (i > 0)
        {
            i--;
        }
        else
        {
            i = l - 1;
        }
    }



    private void DisableOthers(int x)
    {
        //cam.transform.position = new Vector3(cars[x].transform.position.x,cam.transform.position.y,cars[x].transform.position.z);
        models[x].GetComponent<AstronautDirections>().enabled = true;
        models[x].GetComponent<CharacterMovement>().enabled = true;
        models[x].GetComponent<AstronautMouseController>().enabled = true;
        for (int j = 0; j < l; j++)
        {
            if (j != x)
            {
                models[j].GetComponent<AstronautMouseController>().enabled = false;
                models[j].GetComponent<AstronautDirections>().enabled = false;
                models[j].GetComponent<CharacterMovement>().enabled = false;
            }
        }
       //Debug.Log("#" + x + " is the active camera ");
    }
    public void Replay()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Scene restarestarted!");
    }

   void UpdateCreationDropdown()
    {
        choices.ClearOptions();
        foreach (GameObject c in modelsPrefabs)
        {
            Dropdown.OptionData option = new Dropdown.OptionData();
            option.text = c.name;
            choices.options.Add(option);
        }
        choices.captionText.text = choices.options[choices.value].text;
        SyncChoiceWithPreview();
    }
    public void SyncChoiceWithPreview()
    {
        for (int comp = 0; comp < previewCanvas.childCount; comp++)
        {
            previewCanvas.GetChild(comp).gameObject.SetActive(false);
        }
        previewCanvas.GetChild(choices.value).gameObject.SetActive(true);
    }
    public void SwitchCams()
    {
        nearbyCam.transform.parent = models[i].transform;
        nearbyCam.transform.position += models[i].transform.position + new Vector3(0, 2.15f, 0);
        nearbyCam.SetActive(!nearbyCam.activeSelf);
    }
}