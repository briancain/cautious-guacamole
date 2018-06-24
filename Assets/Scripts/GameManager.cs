using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

  private AudioSource audio;

  private enum GameState {
    TITLE,
    PLAYING,
    GAMEOVER
  }

  [SerializeField]
  List<GameObject> playerInventory;

  GameState gameState;

  void SetGameState(GameState newState) {
    switch(newState) {
      case GameState.TITLE:
        break;
      case GameState.PLAYING:
        break;
      case GameState.GAMEOVER:
        break;
      default:
        Debug.LogError("Given unknown GameState: " + newState);
        break;
    }
  }

  void Awake() {
    initVars();
    initPlayerObjects();
    // TODO: Update this if we get a title
    SetGameState(GameState.PLAYING);
  }

  void initPlayerObjects() {
    playerInventory = new List<GameObject>();

  }

  void initVars() {
    audio = GetComponent<AudioSource>();
  }

  // Use this for initialization
  void Start () {
  }

  // Update is called once per frame
  void Update () {
  }
}
