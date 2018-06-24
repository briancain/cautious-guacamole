using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePieceManager : MonoBehaviour {

  private bool isPlaced;
  private string displayName;
  private Transform piecePosition;

  // Timer for when pieces want to start moving after
  // being placed
  private float nextActionTime = 0.0f;
  private float timer = 0f;
  private float generationCooldown = 2.0f;

  void Awake() {
    isPlaced = false;
  }

  // Use this for initialization
  void Start () {
  }
  // Update is called once per frame
  void Update () {
  }
}
