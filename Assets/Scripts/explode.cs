using UnityEngine;
using System.Collections;

public class explode : MonoBehaviour {

	// Use this for initialization	
	public GameObject[] objects;
	public Vector3[] initial_pos;
	public Transform[] final_pos;
	static public bool exp;
	public float speed;

	void Start () {
		for(int i = 0; i< objects.Length ; i++){
			initial_pos[i] = objects[i].transform.position;
		}
		if (Application.platform==RuntimePlatform.WebGLPlayer) {
			speed = speed*5;
		}
		else if(Application.platform==RuntimePlatform.Android){
			speed = 0.03f;
		}
		else{
			speed = 0.03f;
		}

	}

	
	// Update is called once per frame
	void Update () {
//		if(buttonsSelection.Explode_b){
			for(int i = 0;i<objects.Length;i++){
				objects[i].transform.position = Vector3.Lerp(objects[i].transform.position,final_pos[i].position,speed);
			}
//		}else if(!buttonsSelection.Explode_b && !peelDrag.stic_enab/*!Buttons_Selection.Peel_b*/){
			for(int j = 0;j<objects.Length;j++){
				objects[j].transform.position = Vector3.Lerp(objects[j].transform.position,initial_pos[j],speed);
			}
//		}
	}
}
