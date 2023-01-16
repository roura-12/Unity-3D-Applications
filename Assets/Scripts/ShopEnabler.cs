using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Map;
using UnityEngine.SceneManagement;
public class ShopEnabler : MonoBehaviour
{
    private AbstractMap _abstractMap;
    // Start is called before the first frame update
    void Start()
    {
        _abstractMap = FindObjectOfType<AbstractMap>();
    }
   /* public void EnableNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       


    }*/
    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("ShopsOppening"))
        {
            EnableCommercialBuildingsLayer();
            EnableSchoolLayer();
        }
    }
    public void EnableParkLayer()
    {
        var layer = _abstractMap.VectorData.FindFeatureSubLayerWithName("Parks");
        if (layer != null)
        {
            layer.SetActive(true);
        }
        else
        {
            Debug.Log("Layer not found");
        }
    }


    public void EnableSchoolLayer()
    {
        var layer = _abstractMap.VectorData.FindFeatureSubLayerWithName("Schools");
        if (layer != null)
        {
            layer.SetActive(true);
        }
        else
        {
            Debug.Log("Layer not found");
        }
    }
    public void EnableUniversityLayer()
    {
        var layer = _abstractMap.VectorData.FindFeatureSubLayerWithName("University");
        if (layer != null)
        {
            layer.SetActive(true);
        }
        else
        {
            Debug.Log("Layer not found");
        }
    }

    public void EnableCommercialBuildingsLayer()
        {
            var layer = _abstractMap.VectorData.FindFeatureSubLayerWithName("CommercialBuildings");
            if (layer != null)
            {
                layer.SetActive(true);
            }
            else
            {
                Debug.Log("Layer not found");
            }
        }


    public void EnableIndustrialLayer()
    {
        var layer = _abstractMap.VectorData.FindFeatureSubLayerWithName("IndustrialBuildings");
        if (layer != null)
        {
            layer.SetActive(true);
        }
        else
        {
            Debug.Log("Layer not found");
        }
    }
    public void EnableReligiousLayer()
    {
        var layer = _abstractMap.VectorData.FindFeatureSubLayerWithName("ReligiousBuildings");
        if (layer != null)
        {
            layer.SetActive(true);
        }
        else
        {
            Debug.Log("Layer not found");
        }
    }

}
