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

  // TODO: These will very likely be hard coded positions for each pre-generated goal photo
  private Vector3[] winPositions = new Vector3[] { new Vector3(0f, 0f, 0f),
                                                   new Vector3(0f, 0f, 0f),
                                                   new Vector3(0f, 0f, 0f) };

  private string[] basicInventory = new string[] {"link", "key", "key"};

  [SerializeField]
  GameObject basicInventoryPhoto;

  private string[] intermediateInventory = new string[] {"link", "key", "key"};

  [SerializeField]
  GameObject intermediateInventoryPhoto;

  private string[] advancedInventory = new string[] {"link", "key", "key"};

  [SerializeField]
  GameObject advancedInventoryPhoto;
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
        // Randomly Pick goal photo for game
        // Start cry  meter
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
    // Decrement cry meter only if game state is playing
    // Check cry meter for <= 0f, and if so, change game state to GAMEOVER
  }

  // TODO: finish me
  bool CheckDistanceOfPieces() {
    int i = 0;
    bool success = false;

    foreach (GameObject p in playerInventory) {
      float distance = Vector3.Distance(p.transform, winPositions[i]);
      if (distance >= 1f) {
        return false;
      }
      i++;
    }
    return false;
  }

  public void TakePhoto() {
    // method to be called from GameObject camera button?
    //
    // Check for if pieces match their respective "goal" positions
    // If not, decrement cry meter by a specific amount
  }
}
