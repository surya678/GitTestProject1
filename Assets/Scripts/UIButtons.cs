using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtons : MonoBehaviour {

	// Use this for initialization
	public UISprite[] button_sprite;

	void Start () {
		
	}
	public void Reset (){
		Application.LoadLevel (0);
	}



	public void ResetFunctions(){
		
	}
	public void Orbit (){
		
		if (!orbit.orbit_enabled) {
			orbit.orbit_enabled = true;
			orbit.pan_bool = false;
			button_sprite[3].GetComponentInChildren<UILabel>().color = Color.white;
			//button_sprite [1].spriteName = "Orbit1_on";
			button_sprite[1].GetComponentInChildren<UILabel>().color = Color.red;

		} else {
			orbit.orbit_enabled = false;
			//button_sprite [1].spriteName = "Orbit1";
			button_sprite[1].GetComponentInChildren<UILabel>().color = Color.white;
		}
	}
	public void Zoom (){

		if (!orbit.Zoom_bool) {
			orbit.Zoom_bool = true;
			button_sprite[2].GetComponentInChildren<UILabel>().color = Color.red;
			//button_sprite [2].spriteName = "Zoom_on";
		} else {
			orbit.Zoom_bool = false;
			//button_sprite [2].spriteName = "Zoom";
			button_sprite[2].GetComponentInChildren<UILabel>().color = Color.white;
		}
	}
	public void Pan (){
		if (!orbit.pan_bool) {
			orbit.pan_bool = true;
			button_sprite[3].GetComponentInChildren<UILabel>().color = Color.red;
			orbit.orbit_enabled = false;
			//button_sprite [1].spriteName = "Orbit1";
			button_sprite[1].GetComponentInChildren<UILabel>().color = Color.white;
		} else {
			orbit.pan_bool = false;
			button_sprite[3].GetComponentInChildren<UILabel>().color = Color.white;
		}
	}

	public void Pan_reset (){
		Application.LoadLevel (0);
	}
	public void Explode (){

		if (!Controller.expld) {
			Controller.expld = true;
			button_sprite[4].GetComponentInChildren<UILabel>().color = Color.red;
			button_sprite[4].GetComponentInChildren<UILabel>().text = "Implode";
		} else {
			Controller.expld = false;
			button_sprite[4].GetComponentInChildren<UILabel>().color = Color.white;
			button_sprite[4].GetComponentInChildren<UILabel>().text = "Explode";
			//button_sprite [4].spriteName = "Explode";
//			button_sprite [5].spriteName = "Implode_on";
		}
	}
	public void Peel (){
		if (!Controller.peel) {
			Controller.peel = true;
			button_sprite[5].GetComponentInChildren<UILabel>().color = Color.red;
			button_sprite[5].GetComponentInChildren<UILabel>().text = "Stick";
			//button_sprite [6].spriteName = "stick_on";
		} else {
			Controller.peel = false;
			button_sprite[5].GetComponentInChildren<UILabel>().color = Color.white;
			button_sprite[5].GetComponentInChildren<UILabel>().text = "Peel";
		}
	}
	public void Label_roll (){
		if (!Controller.label_roll) {
			Controller.label_roll = true;
			//button_sprite [8].spriteName = "message_om";
		} else {
			Controller.label_roll = false;
			//button_sprite [8].spriteName = "message";
		}
	}
	public void Label_mark (){
		if (!Controller.mark) {
			Controller.mark = true;
			button_sprite[6].GetComponentInChildren<UILabel>().color = Color.red;
			//button_sprite [9].spriteName = "Mark_on";
		} else {
			Controller.mark = false;
			button_sprite[6].GetComponentInChildren<UILabel>().color = Color.white;
			//button_sprite [9].spriteName = "Mark";
		}
	}


	// Update is called once per frame
	void Update () {
		
	}
}
