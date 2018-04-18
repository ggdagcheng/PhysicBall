using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Ball : MonoBehaviour {

    public static List<Ball> Balls = new List<Ball>();

    public Rigidbody2D rigid;
    public int[] RandomPulsis = new int[] {4,5,6,7,8,9};
    int RandomPulsisIndex = 0;

    public ReactiveProperty<int> MyLayer = new ReactiveProperty<int>(0);

    public SpriteRenderer SR;


    public void SetLayer(int Layer) {
        MyLayer.Value = Layer;
        gameObject.layer = Layer;
        if (Layer == (int)LayerCtrl.LayerIntValue.RevertBallSelfCollide)
        {
            BallProjector.Instance.AddWaitForProjectBall(this);
        }
    }


    void Awake() {
        Balls.Add(this);

        rigid = GetComponent<Rigidbody2D>();
        MyLayer.Value = (int)LayerCtrl.LayerIntValue.Ball;
        SR = GetComponent<SpriteRenderer>();
    }
	void Start () {
        MyLayer.Subscribe( x => {
            if (x == (int)LayerCtrl.LayerIntValue.Ball) {
                SR.color = Color.white;
            }
            else if (x == (int)LayerCtrl.LayerIntValue.RevertBall) {
                SR.color = Color.yellow;
            }
            else if (x == (int)LayerCtrl.LayerIntValue.RevertBallSelfCollide)
            {
                SR.color = Color.red;
            }
        });
	}
	
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (MyLayer.Value == (int)LayerCtrl.LayerIntValue.SelectedProjectBall)
            return;

        if(other.gameObject.layer == (int)LayerCtrl.LayerIntValue.BounceWall || other.gameObject.layer == (int)LayerCtrl.LayerIntValue.Brick) { 
            Vector2 direction = other.contacts[0].normal;
            rigid.AddForce(direction * RandomPulsis[RandomPulsisIndex], ForceMode2D.Impulse);
            RandomPulsisIndex++;
            if (RandomPulsisIndex == RandomPulsis.Length) {
                RandomPulsisIndex = 0;
            }
        }
    }
}
