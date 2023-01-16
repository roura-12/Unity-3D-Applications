using Mapbox.Unity.Map;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mapModif : MonoBehaviour {
    private AbstractMap _abstractMap;
   /* public Dropdown buildingDropdown;
    public Dropdown parkDropdown;
    public Dropdown RoadDropdown;
    public Dropdown PoiLabelsDropdown;
    public Dropdown PoisDropdown;
    public Dropdown WaterDropdown;
    public Dropdown WaterwayDropdown;
    public Dropdown AerowayDropdown;
    public Dropdown BarrierLineDropdown;*/
    public string Number;
    public string MyLayer;
    public GameObject inputField;
    public GameObject stringinputField;
    string fname;
   // List<string> names = new List<string>() { "Enable/Disable Layer", "Buildings", "Parks", "Roads", "PoiLabels", "Pois", "Water", "Waterway", "Aeroway", "BarrierLine", "LanduseOverlay", "Admin", "CountryLabel", "MarineLabel", "StateLabel", "WaterLabel", "PlaceLabel", "RoadLabel", "WaterwayLabel", "AirportLabel", "RailStationLabel", "MountainPeakLabel", "HouseNumberLabel", "MotorwayJunction", "Landcover", "Hillshade", "Contour", "LowTrafficCongestion", "ModerateTrafficCongestion", "HeavyTrafficCongestion", "SevereTrafficCongestion" };

    // Use this for initialization
    void Start () {
        _abstractMap = FindObjectOfType<AbstractMap>();
      
    }

    // Update is called once per frame
    void Update()
    {   
      
    }
    public void ChangeExtentType()
    { _abstractMap.SetExtent(MapExtentType.CameraBounds); }
    public void ChangeExtType()
    { _abstractMap.SetExtent(MapExtentType.RangeAroundCenter); }

    public void EnableLayer()
    {
        Number = inputField.GetComponent<Text>().text;
        int Num;
        int.TryParse(Number, out Num);

        var layer = _abstractMap.VectorData.GetFeatureSubLayerAtIndex(Num);
        if (layer != null)
        { layer.SetActive(true); }
        else
        { Debug.Log("Layer not found"); }
    }

    public void DisableLayer()
    {
        Number = inputField.GetComponent<Text>().text;
        int Num;
        int.TryParse(Number, out Num);

        var layer = _abstractMap.VectorData.GetFeatureSubLayerAtIndex(Num);
        if (layer != null)
        { layer.SetActive(false); }
        else { Debug.Log("Layer not found"); }
    }
    public void RemoveLayer()
    {
        MyLayer = stringinputField.GetComponent<Text>().text;

        _abstractMap.VectorData.RemoveFeatureSubLayerWithName(MyLayer);
            }
    public void AddLayer()
    {
        MyLayer = stringinputField.GetComponent<Text>().text;
        VectorSubLayerProperties subLayerProperties = new VectorSubLayerProperties();
        subLayerProperties.coreOptions.geometryType = VectorPrimitiveType.Polygon;
        subLayerProperties.coreOptions.layerName = MyLayer;
        _abstractMap.VectorData.AddFeatureSubLayer(subLayerProperties);

    }
    public void AddMeshModif()
    {
        Number = inputField.GetComponent<Text>().text;
        int Num;
        int.TryParse(Number, out Num);
        
        var layer = _abstractMap.VectorData.GetFeatureSubLayerAtIndex(Num);
       // layer.BehaviorModifiers.AddGameObjectModifier(ScriptableObject.CreateInstance<>());

    }
    /*public void ChangeBuildingMaterial()
    {
        MyLayer = DeleteinputField.GetComponent<Text>().text;
        _abstractMap.VectorData.FindFeatureSubLayerWithName(MyLayer);
        if (MyLayer == "Buildings")
        {

        }
    }
    /*  public void EnableBuildingLayer()
      {
          switch (buildingDropdown.value)
          {
              case 1:

                  var layer = _abstractMap.VectorData.FindFeatureSubLayerWithName("Buildings");
                  if (layer != null)
                  { layer.SetActive(true); }
                  else { Debug.Log("Layer not found"); }
                  break;
              case 2:
                  layer = _abstractMap.VectorData.FindFeatureSubLayerWithName("Buildings");
                  if (layer != null)
                  { layer.SetActive(false); }
                  else
                  { Debug.Log("Layer not found"); }
                  break;

          }
      }
      public void EnableParkLayer()
      {
          switch (parkDropdown.value)
          {
              case 1:
                  var layer = _abstractMap.VectorData.FindFeatureSubLayerWithName("Parks");
                  if (layer != null)
                  { layer.SetActive(true); }
                  else { Debug.Log("Layer not found"); }
               break;
              case 2:
                  layer = _abstractMap.VectorData.FindFeatureSubLayerWithName("Parks");
                  if (layer != null)
                  { layer.SetActive(false); }
                  else
                  { Debug.Log("Layer not found"); }
               break;
          }
      }
      public void EnableRoadsLayer()
      {
          switch (RoadDropdown.value)
          {
              case 1:
                  var layer = _abstractMap.VectorData.FindFeatureSubLayerWithName("Roads");
                  if (layer != null)
                  { layer.SetActive(true); }
                  else { Debug.Log("Layer not found"); }
                  break;
              case 2:
                  layer = _abstractMap.VectorData.FindFeatureSubLayerWithName("Roads");
                  if (layer != null)
                  { layer.SetActive(false); }
                  else
                  { Debug.Log("Layer not found"); }
                  break;
          }
      }
      public void EnablePoiLabelsLayer()
      {
          switch (PoiLabelsDropdown.value)
          {
              case 1:
                  var layer = _abstractMap.VectorData.FindFeatureSubLayerWithName("PoiLabels");
                  if (layer != null)
                  { layer.SetActive(true); }
                  else { Debug.Log("Layer not found"); }
                  break;
              case 2:
                  layer = _abstractMap.VectorData.FindFeatureSubLayerWithName("PoiLabels");
                  if (layer != null)
                  { layer.SetActive(false); }
                  else
                  { Debug.Log("Layer not found"); }
                  break;
          }
      }
      public void EnablePoisLayer()
      {
          switch (PoisDropdown.value)
          {
              case 1:
                  var layer = _abstractMap.VectorData.FindFeatureSubLayerWithName("Pois");
                  if (layer != null)
                  { layer.SetActive(true); }
                  else { Debug.Log("Layer not found"); }
                  break;
              case 2:
                  layer = _abstractMap.VectorData.FindFeatureSubLayerWithName("Pois");
                  if (layer != null)
                  { layer.SetActive(false); }
                  else
                  { Debug.Log("Layer not found"); }
                  break;
          }
      }
      public void EnableWaterLayer()
      {
          switch (WaterDropdown.value)
          {
              case 1:
                  var layer = _abstractMap.VectorData.FindFeatureSubLayerWithName("Water");
                  if (layer != null)
                  { layer.SetActive(true); }
                  else { Debug.Log("Layer not found"); }
                  break;
              case 2:
                  layer = _abstractMap.VectorData.FindFeatureSubLayerWithName("Water");
                  if (layer != null)
                  { layer.SetActive(false); }
                  else
                  { Debug.Log("Layer not found"); }
                  break;
          }
      }
      public void EnableWaterwayLayer()
      {
          switch (WaterwayDropdown.value)
          {
              case 1:
                  var layer = _abstractMap.VectorData.FindFeatureSubLayerWithName("Waterway");
                  if (layer != null)
                  { layer.SetActive(true); }
                  else { Debug.Log("Layer not found"); }
                  break;
              case 2:
                  layer = _abstractMap.VectorData.FindFeatureSubLayerWithName("Waterway");
                  if (layer != null)
                  { layer.SetActive(false); }
                  else
                  { Debug.Log("Layer not found"); }
                  break;
          }
      }
      public void EnableAerowayLayer()
      {
          switch (AerowayDropdown.value)
          {
              case 1:
                  var layer = _abstractMap.VectorData.FindFeatureSubLayerWithName("Aeroway");
                  if (layer != null)
                  { layer.SetActive(true); }
                  else { Debug.Log("Layer not found"); }
                  break;
              case 2:
                  layer = _abstractMap.VectorData.FindFeatureSubLayerWithName("Aeroway");
                  if (layer != null)
                  { layer.SetActive(false); }
                  else
                  { Debug.Log("Layer not found"); }
                  break;
          }
      }
      public void EnableBarrierLineLayer()
      {
          switch (BarrierLineDropdown.value)
          {
              case 1:
                  var layer = _abstractMap.VectorData.FindFeatureSubLayerWithName("BarrierLine");
                  if (layer != null)
                  { layer.SetActive(true); }
                  else { Debug.Log("Layer not found"); }
                  break;
              case 2:
                  layer = _abstractMap.VectorData.FindFeatureSubLayerWithName("BarrierLine");
                  if (layer != null)
                  { layer.SetActive(false); }
                  else
                  { Debug.Log("Layer not found"); }
                  break;
          }
      }*/
}
