using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

  private float cryMeter;

  private AudioSource audio;

  private List<GameObject> playerInventory;

  private enum GameState {
    TITLE,
    PLAYING,
    GAMEOVER
  }

  // =============================
  // Photo Arrangements
  // =============================
  private string[] basicInventory = new string[] {"link", "key", "key"};
  private string[] intermediateInventory = new string[] {"link", "key", "key"};
  private string[] advancedInventory = new string[] {"link", "key", "key"};
  // =============================
  // =============================

  // =============================
  // Game Pieces
  // =============================
  [SerializeField]
  GameObject link;

  [SerializeField]
  GameObject key;
  // =============================
  // =============================

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
    Vector3 basePos = new Vector3(-4f, -4f, 1);
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
    cryMeter = 100f;
  }

  // Use this for initialization
  void Start () {
  }

  // Update is called once per frame
  void Update () {
  }
}
