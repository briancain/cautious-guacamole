using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenManager : MonoBehaviour {

  [SerializeField]
  Sprite basicInventoryPhoto1;

  [SerializeField]
  Sprite basicInventoryPhoto2;

  [SerializeField]
  Sprite intermediateInventoryPhoto1;

  [SerializeField]
  Sprite intermediateInventoryPhoto2;

  [SerializeField]
  Sprite advancedInventoryPhoto1;

  [SerializeField]
  Sprite advancedInventoryPhoto2;

  [SerializeField]
  Sprite gameOverPhoto;

  private SpriteRenderer sr;
  private string endingVar;

  // Use this for initialization
  void Start () {
    sr = gameObject.GetComponent<SpriteRenderer>();
    sr.enabled = false;
  }
  // Update is called once per frame
  void Update () {
  }

  public void SetEndingSprite(string ending) {
    endingVar = ending;
  }

  public void DrawEnding() {
    sr = gameObject.GetComponent<SpriteRenderer>();
    Sprite sp;
    switch(endingVar) {
      case "gameover":
        sp = gameOverPhoto;
        break;
      case "basic1":
        sp = basicInventoryPhoto1;
        break;
      case "basic2":
        sp = basicInventoryPhoto2;
        break;
      case "int1":
        sp = intermediateInventoryPhoto1;
        break;
      case "int2":
        sp = intermediateInventoryPhoto2;
        break;
      case "adv1":
        sp = advancedInventoryPhoto1;
        break;
      case "adv2":
        sp = advancedInventoryPhoto2;
        break;
      default:
        sp = basicInventoryPhoto1;
        break;
    }

    sr.sprite = sp;
    sr.enabled = true;
  }
}
