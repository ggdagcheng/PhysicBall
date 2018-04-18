using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLayer : MonoBehaviour {
    public LayerCtrl.LayerIntValue Layer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other) {
        Ball b = other.GetComponent<Ball>();
        if (b) {
            if (b.gameObject.layer == (int)LayerCtrl.LayerIntValue.SelectedProjectBall && Layer == LayerCtrl.LayerIntValue.RevertBallSelfCollide)
                return;
            if(b.gameObject.layer != (int)Layer)
                b.SetLayer((int)Layer);
        }
    }
}
