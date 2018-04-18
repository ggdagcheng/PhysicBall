using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerCtrl : MonoBehaviour {

    public static LayerCtrl Instance;

    public enum LayerIntValue {
        Ball = 21,
        RevertBall = 22,
        RevertBallSelfCollide = 23,
        SelectedProjectBall = 24,
        Brick = 29,
        Wall = 30,
        BounceWall = 28
    }


    void Awake() {
        Instance = this;
    }

    void Start () {
		
	}
	

	void Update () {
		
	}
}
