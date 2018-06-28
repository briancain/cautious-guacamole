using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPhotoManager : MonoBehaviour {

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

  private SpriteRenderer sr;
  void Awake() {
    sr = gameObject.GetComponent<SpriteRenderer>();
  }

  // Use this for initialization
  void Start () {
  }
  // Update is called once per frame
  void Update () {
  }

  public void SetSprite(string sprite) {
    // need this for some reason when we build?!
    sr = gameObject.GetComponent<SpriteRenderer>();
    Sprite sp;
    switch(sprite) {
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
  }
}
