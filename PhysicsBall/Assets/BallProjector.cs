using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallProjector : MonoBehaviour {
    public static BallProjector Instance;
    public List<Ball> WaitForProjectBall = new List<Ball>();

    public bool Shooting = false;

    void Awake() {
        Instance = this;
    }

    public void AddWaitForProjectBall(Ball b) {
        if(!WaitForProjectBall.Contains(b))
            WaitForProjectBall.Add(b);
        if (WaitForProjectBall.Count == Ball.Balls.Count) {
            Shooting = true;
        }
    }



    void Start () {
		
	}
	
	void Update () {
        if (Shooting) {
            if (WaitForProjectBall.Count > 0)
            {
                WaitForProjectBall[0].SetLayer((int)LayerCtrl.LayerIntValue.SelectedProjectBall);
                WaitForProjectBall.RemoveAt(0);
            }
            else {
                Shooting = false;
            }
        }
	}
}
