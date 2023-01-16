using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour 
{
  public GameObject Car;
  Vector3 offset;
 
  void Start()
  {
    offset = transform.position - Car.transform.position ;
  }
 
  void LateUpdate()
  {
    float newXPosition = Car.transform.position.x ;
    float newZPosition = Car.transform.position.z ;
    transform.position = new Vector3(newXPosition , transform.position.y , newXPosition);
  }
}
