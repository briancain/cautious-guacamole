using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraButtonManager : MonoBehaviour {

  // Use this for initialization
  void Start () {
  }
  // Update is called once per frame
  void Update () {
  }

  // Photo taken!!
  void OnMouseDown() {
    GameManager gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    gameManager.TakePhoto();
  }
}
