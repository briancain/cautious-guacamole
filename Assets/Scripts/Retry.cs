using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retry : MonoBehaviour {
  private SpriteRenderer sr;
  private bool gameOver;

  [SerializeField]
  Sprite failButton;

  private BoxCollider2D bc;

  // Use this for initialization
  void Start () {
    sr = gameObject.GetComponent<SpriteRenderer>();
    gameOver = false;
  }
  // Update is called once per frame
  void Update () {
  }

  public void TurnOn() {
    if (gameOver) {
      sr.sprite = failButton;
      Vector3 v = sr.bounds.size;
      bc.size = v;
      Debug.Log(transform.position);
    }

    sr.enabled = true;
    GetComponent<BoxCollider2D> ().enabled = true;
  }

  void OnMouseDown() {
    GameManager gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();


    gameManager.ReloadGame();
  }
}
