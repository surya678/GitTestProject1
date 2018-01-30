using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttonclick : MonoBehaviour {

	// Use this for initialization
	public int id;
	public UIButtons uib;
	void Start () {
		
	}
	void OnClick (){
		if (id == 0) {
			uib.Reset ();
		}

		if (id == 1) {
			uib.Orbit ();
		}
		if (id == 2) {
			uib.Zoom ();
		}
		if (id == 3) {
			uib.Explode ();
		}
		if (id == 4) {
			uib.Peel ();
		}
		if (id == 5) {
			uib.Label_roll ();
		}
		if (id == 6) {
			uib.Label_mark ();
		}
		if (id == 7) {
			uib.Pan ();
		}
		if (id == 8) {
			uib.Pan_reset ();
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
