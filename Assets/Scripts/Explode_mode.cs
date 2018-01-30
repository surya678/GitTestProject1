using UnityEngine;
using System.Collections;

public class Explode_mode : MonoBehaviour {
	public Color color_Normal=new Color();
	public Color color_Selected=new Color();
	public Controller ctrl;
//	public GameObject body;
	// Use this for initialization
	void Start () {
	
	}
	void OnClick(){
		orbit.distance=4.13f;
			if (Controller.expld) {
				//Controller.TrancMode = false;
				//Controller.IsoMode = true;
				Controller.expld = false;
			transform.GetComponent<UISprite>().color = color_Normal;
			} else {
				Controller.expld = true;
			transform.GetComponent<UISprite>().color = color_Selected;
//			body.SetActive (false);
//			Annotation.anno = false;

			}
	}
	void Update(){
		if (!Controller.expld) {
			transform.GetComponent<UISprite>().color = color_Normal;
//			body.SetActive (true);
		}
	}
}

