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
  }

  // Use this for initialization
  void Start () {
    isPlaced = false;
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
    // This seems to be setting the Z to zero??
    // check camera position on home computer?
    Vector3 movePos = Camera.main.ScreenToWorldPoint(new Vector3(mouseX,mouseY,11.0f));
    transform.position = movePos;
  }
}
