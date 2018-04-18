using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBall : MonoBehaviour {

    public GameObject Ball;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.F1)) {
            Instantiate(Ball);
        }
	}
}
