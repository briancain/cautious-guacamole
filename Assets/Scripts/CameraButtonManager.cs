using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraButtonManager : MonoBehaviour {

  [SerializeField]
  Sprite camera;

  [SerializeField]
  Sprite cameraFlash;

  private SpriteRenderer sr;

  // Use this for initialization
  void Start () {
    sr = gameObject.GetComponent<SpriteRenderer>();
  }
  // Update is called once per frame
  void Update () {
  }


  void OnMouseUp() {
    sr.sprite = camera;
  }

  // Photo taken!!
  void OnMouseDown() {
    GameManager gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();


    sr.sprite = cameraFlash;
    gameManager.TakePhoto();
  }
}
