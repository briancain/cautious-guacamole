using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

  private float cryMeter;

  private AudioSource audio;

  private List<GameObject> playerInventory;

  private SpriteRenderer sr;

  [SerializeField]
  float InventoryGoalDistance;

  [SerializeField]
  AudioClip cameraSuccessClip;

  [SerializeField]
  AudioClip cameraFailClip;

  private enum GameState {
    TITLE,
    PLAYING,
    LOSE,
    WIN
  }

  // =============================
  // Photo Arrangements
  // =============================

  // TODO: These will very likely be hard coded positions for each pre-generated goal photo
  private Vector3[] winPositions = new Vector3[] { new Vector3(0f, 0f, 0f),
                                                   new Vector3(0f, 0f, 0f),
                                                   new Vector3(0f, 0f, 0f) };

  private string[] basicInventory = new string[] {"link", "key", "key"};
  private string[] basicInventory1 = new string[] {"plant", "column"};
  private string[] basicInventory2 = new string[] {"plant", "bear"};

  // goal 2
  // Flip Column
  private Vector3[] basic1WinPositions = new Vector3[] { new Vector3(5.25f, 1.5f, 1f),
                                                         new Vector3(-3f, 0f, 1f) };

  // goal 6
  // Flip plant, bear
  private Vector3[] basic2WinPositions = new Vector3[] { new Vector3(-5f, 1f, 1f),
                                                         new Vector3(3f, 1f, 1f) };

  private string[] intermediateInventory = new string[] {"bear", "column"};

  // goal 3
  // Flip Column, Bear
  private Vector3[] int1WinPositions = new Vector3[] { new Vector3(4f, 0.5f, 1f),
                                                      new Vector3(-2f, -0.5f, 1f) };
  // goal 4
  // Flip Column
  private Vector3[] int2WinPositions = new Vector3[] { new Vector3(-4.5f, 0.5f, 1f),
                                                      new Vector3(-2f, -1f, 1f) };

  private string[] advancedInventory1 = new string[] {"bear", "column", "plant"};

  // goal 1
  private Vector3[] adv1WinPositions = new Vector3[] { new Vector3(-3.5f, 0.5f, 1f),
                                                       new Vector3(2.5f, -0.5f, 1f),
                                                       new Vector3(4f, 1f, 1f) };
  // goal 5
  // Flip Column,Bear,Plant
  private Vector3[] adv2WinPositions = new Vector3[] { new Vector3(4f, 1f, 1f),
                                                       new Vector3(-2.5f, -0.5f, 1f),
                                                       new Vector3(-4f, 1f, 1f) };

  // Determines the photo to use for the mini game
  private string[] goalPhotoGame = new string[] {"basic1", "basic2", "int1", "int2", "adv1", "adv2"};

  // =============================
  // =============================
  // =============================

  // =============================
  // Game Pieces
  // =============================
  [SerializeField]
  GameObject link;

  [SerializeField]
  GameObject key;

  [SerializeField]
  GameObject bear;

  [SerializeField]
  GameObject plant;

  [SerializeField]
  GameObject column;
  // =============================
  // =============================

  public void ReloadGame(){
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }

  GameState gameState;

  void SetGameState(GameState newState) {
     EndScreenManager endScreenManager = GameObject.FindGameObjectWithTag("EndScreen").GetComponent<EndScreenManager>();
    switch(newState) {
      case GameState.TITLE:
        break;
      case GameState.PLAYING:
        break;
      case GameState.LOSE:
        endScreenManager.SetEndingSprite("gameover");
        endScreenManager.DrawEnding();
        break;
      case GameState.WIN:
        // reloads scene entirely
        endScreenManager.DrawEnding();
        break;
      default:
        Debug.LogError("Given unknown GameState: " + newState);
        break;
    }
  }

  IEnumerator Waiter() {
    yield return new WaitForSeconds(10);
  }

  void Awake() {
    InitVars();
    InitPlayerObjects();
    // TODO: Update this if we get a title
    SetGameState(GameState.PLAYING);
  }

  void SpawnInventory(string[] invSet, bool[] toFlip) {
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
        case "bear":
          g = bear;
          break;
        case "column":
          g = column;
          break;
        case "plant":
          g = plant;
          break;
        default:
          g = link;
          break;
      }

      GameObject obj = Instantiate(g, pos, Quaternion.identity);
      if (toFlip[k] == true) {
        obj.GetComponent<GamePieceManager>().setFlip();
      }
      playerInventory.Add(obj);
      k++;
    }
  }

  void SelectGame() {
    // randomly pick from goalPhoto array and properly select the right inventory set and generate photos
    int index = Random.Range(0, goalPhotoGame.Length);

    var inventory = basicInventory;
    string inventoryName;
    bool[] toFlip = new bool[] {false, false, false};

    switch(index) {
      case 0:
        inventoryName = "basic1";
        inventory = basicInventory1;
        winPositions = basic1WinPositions;
        toFlip = new bool[] {false, true, false};
        break;
      case 1:
        inventoryName = "basic2";
        inventory = basicInventory2;
        winPositions = basic2WinPositions;
        toFlip = new bool[] {true, true, false};
        break;
      case 2:
        inventoryName = "int1";
        inventory = intermediateInventory;
        winPositions = int1WinPositions;
        toFlip = new bool[] {true, true, false};
        break;
      case 3:
        inventoryName = "int2";
        inventory = intermediateInventory;
        winPositions = int2WinPositions;
        toFlip = new bool[] {false, true, false};
        break;
      case 4:
        inventoryName = "adv1";
        inventory = advancedInventory1;
        winPositions = adv1WinPositions;
        break;
      case 5:
        inventoryName = "adv2";
        inventory = advancedInventory1;
        winPositions = adv2WinPositions;
        toFlip = new bool[] {true, true, true};
        break;
      default:
        inventoryName = "basic1";
        inventory = basicInventory;
        break;
    }

    Debug.Log("win positions:");
    foreach(Vector3 pos in winPositions) {
      Debug.Log(pos);
    }

    GoalPhotoManager goalPhotoManager = GameObject.FindGameObjectWithTag("GoalPhoto").GetComponent<GoalPhotoManager>();
    goalPhotoManager.SetSprite(inventoryName);

    EndScreenManager endScreenManager = GameObject.FindGameObjectWithTag("EndScreen").GetComponent<EndScreenManager>();
    endScreenManager.SetEndingSprite(inventoryName);
    SpawnInventory(inventory, toFlip);
  }

  void ClearInventory() {
    playerInventory.Clear();
  }

  void InitPlayerObjects() {
    playerInventory = new List<GameObject>();

    SelectGame();
  }

  void InitVars() {
    audio = GetComponent<AudioSource>();
    cryMeter = 0.01f;
    InventoryGoalDistance = 1.5f;
    sr = gameObject.GetComponent<SpriteRenderer>();
  }

  // Use this for initialization
  void Start () {
  }

  // Update is called once per frame
  void Update () {
   if  (gameState == GameState.PLAYING)
        { while (cryMeter < 1.01)
            {
                cryMeter += .01f;
            }
            // Check cry meter for >= 1f, and if so, change game state to GAMEOVER
            if (cryMeter >= 1.0f)
            {
                SetGameState(GameState.LOSE);
            }
        }
  }

  // Iterates over each inventory piece and checks against the "goal"
  // Vector3 array to see if each piece is within its goal position.
  bool CheckDistanceOfPieces() {
    int i = 0;

    foreach (GameObject p in playerInventory) {
      float distance = Vector3.Distance(p.transform.position, winPositions[i]);
      //Debug.Log(distance);
      if (distance >= InventoryGoalDistance) {
        break;
      }
      i++;
      if (i == playerInventory.Count){
        return true;
      }
    }
    return false;
  }

  public void TakePhoto() {
    if (CheckDistanceOfPieces()) {
      audio.PlayOneShot(cameraSuccessClip, 1f);
      Debug.Log("You win!");
      SetGameState(GameState.WIN);
    } else {
      audio.PlayOneShot(cameraFailClip, 1f);
      cryMeter += .10f;
    }
  }
}
