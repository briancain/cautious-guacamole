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

  private List<GameObject> playerInventory;

  private string[] basicInventory = new string[] {"link", "key", "key"};


  [SerializeField]
  GameObject link;

  [SerializeField]
  GameObject key;

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
    InitVars();
    InitPlayerObjects();
    // TODO: Update this if we get a title
    SetGameState(GameState.PLAYING);
  }

  void SpawnInventory(string[] invSet) {
    // TODO: Inventory should be about the same size in UI for easy placement
    Vector3 basePos = new Vector3(-8f, -2f, 1);
    int j = 0;
    int k = 0;
    foreach(string i in invSet) {

      Vector3 pos = new Vector3(basePos.x+j, basePos.y, basePos.z);
      j += 2;

      GameObject g;
      switch(i) {
        case "link":
          g = link;
          break;
        case "key":
          g = key;
          break;
        default:
          g = link;
          break;
      }

      GameObject obj = Instantiate(g, pos, Quaternion.identity);
      playerInventory.Add(obj);
    }
  }

  void ClearInventory() {
    playerInventory.Clear();
  }

  void InitPlayerObjects() {
    playerInventory = new List<GameObject>();

    var inventory = basicInventory;
    SpawnInventory(inventory);

  }

  void InitVars() {
    audio = GetComponent<AudioSource>();
  }

  // Use this for initialization
  void Start () {
  }

  // Update is called once per frame
  void Update () {
  }
}
