using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour {
    Animator animator;
  
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        GameManager gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        
        float cry = gm.GetCryMeter();
        animator.SetFloat("cryMeter", cry);
    }
}
