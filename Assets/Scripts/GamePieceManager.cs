﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePieceManager : MonoBehaviour {

  private string displayName;
  private AudioSource audio;

  [SerializeField]
  AudioClip pickUp;

  [SerializeField]
  AudioClip putDown;

  // Timer for when pieces want to start moving after
  // being placed
  private float nextActionTime = 0.0f;
  private float timer = 0f;
  private float generationCooldown = 2.0f;

  private float mouseX;
  private float mouseY;

  private SpriteRenderer sr;
  private Animator animator;

  private BoxCollider2D bc;

  private bool toFlip;

  private enum InventoryState {
    SLEEP,
    MOVE
  }

  InventoryState inventoryState;

  void Awake() {
    audio = GetComponent<AudioSource>();
    animator = gameObject.GetComponent<Animator>();
    bc = gameObject.GetComponent<BoxCollider2D>();
    sr = gameObject.GetComponent<SpriteRenderer>();
    toFlip = false;
  }

  public void setFlip() {
    toFlip = true;
  }

  // Use this for initialization
  void Start () {
    SetInventoryState(InventoryState.SLEEP);
  }
  // Update is called once per frame
  void Update () {
    mouseX = Input.mousePosition.x;
    mouseY = Input.mousePosition.y;
  }

  // Pick up the piece
  void OnMouseDown() {
    audio.PlayOneShot(pickUp, 1f);
  }

  // Drop or reset the piece
  void OnMouseUp() {
    audio.PlayOneShot(putDown, 1f);
  }

  // Follow the mouse to place the piece
  void OnMouseDrag() {
    Vector3 movePos = Camera.main.ScreenToWorldPoint(new Vector3(mouseX,mouseY,11.0f));
    transform.position = movePos;

    // set animator to be ACTIVE
    // then adjanimator = gameObject.GetComponent<Animator>();ust box collider too
    // expect IDLE animation to be thumbnail inventory picture (the small one)
    SetInventoryState(InventoryState.MOVE);
  }

  void SetInventoryState(InventoryState state) {
    switch(state) {
      case InventoryState.SLEEP:
        break;
      case InventoryState.MOVE:
        animator.SetBool("Moved", true);

        // We must resize the collider now that it's bigger
        Vector3 v = sr.bounds.size;
        bc.size = v;
        if (toFlip) {
          sr.flipX = true;
        }
        break;
    }
  }

}
