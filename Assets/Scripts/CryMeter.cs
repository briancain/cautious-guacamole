using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CryMeter : MonoBehaviour {
   
    float cry;
	// Use this for initialization
	void Start () {
      
    }
	
	// Update is called once per frame
	void Update () {
        GameManager gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        cry = gm.GetCryMeter();
        Debug.Log(cry);
        this.GetComponent<Image>().fillAmount = cry;
	}
}
