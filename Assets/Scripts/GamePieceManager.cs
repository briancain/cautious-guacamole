using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePieceManager : MonoBehaviour {

  private bool isPlaced;
  private string displayName;
  private Transform finalPiecePosition;

  // Timer for when pieces want to start moving after
  // being placed
  private float nextActionTime = 0.0f;
  private float timer = 0f;
  private float generationCooldown = 2.0f;

  private float mouseX;
  private float mouseY;

  void Awake() {
    isPlaced = false;
  }

  // Use this for initialization
  void Start () {
    Debug.Log("Started");
  }
  // Update is called once per frame
  void Update () {
    mouseX = Input.mousePosition.x;
    mouseY = Input.mousePosition.y;
  }

  // Pick up the piece
  void OnMouseDown() {
  }

  // Drop or reset the piece
  void OnMouseUp() {
  }

  // Follow the mouse to place the piece
  void OnMouseDrag() {
    transform.position = Camera.main.ScreenToWorldPoint(
        new Vector3(mouseX,mouseY,10.0f));

  }
}
