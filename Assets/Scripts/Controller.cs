using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	// Use this for initialization
	public GameObject[] Objects;
	[SerializeField]
	private GameObject interactive_FBX;
	[SerializeField]
	public GameObject animation_FBX;
	[SerializeField]
	public GameObject Activity2_FBX;

	public Material[] HeightLighted_Materais;
	private Material[] Normal_Materais;

	public Material[] Transparency_mat;
	public GameObject[] disect_objs;
	public Vector3[] Initial_positions;
	public Transform[] Target_positions;
	public GameObject[] coolfact_Obj;
	public GameObject[] ann_obj;
	public GameObject[] Buttons;
	public GameObject[] Explode_objects_ThirdCam;
	public GameObject[] Labels;

	public static bool stdMode;
	public static bool TrancMode;
	public static bool IsoMode;
	public static bool MulSelMode;
	public static bool disect;
	public static bool undo_clk;
	public static bool rest;
	public static bool expld;
	public static bool peel;
	public static bool label_roll;
	public static bool mark;
	public static int clk;

	public static int selObj_count;
	public GameObject Ann_Panel;
	public GameObject[] anno_nums;


	public GameObject Third_cam;


	void Start () {
		stdMode = true;
		TrancMode = false;
		IsoMode = false;
		MulSelMode = false;
		disect = false;
		undo_clk = false;
		expld = false;
		peel = false;
		selObj_count = 0;
		label_roll = false;
		mark = false;


		for (int i = 0; i<Objects.Length; i++) {
			Initial_positions[i] = Objects [i].transform.localPosition;
		}

		Normal_Materais = new Material[Objects.Length];

		for (int j = 0; j < Objects.Length; j++) {

			if (Objects [j].GetComponent<Renderer> () != null) {
				Normal_Materais [j] = Objects [j].GetComponent<Renderer> ().material;
			} else {					
				try {
					foreach (Renderer renderer in Objects [j].GetComponentsInChildren<Renderer>()) {
						if (renderer != null) {
							Normal_Materais [j] = renderer.material;
						}

					}
				} catch {
				}
			}

		}

	}



	void Update () {
		
		if (stdMode) {
			StandardMode ();
		}
		if (TrancMode) {
			TransparencyMode ();
		}
		if (IsoMode) {
			IsolatedMode ();
		}
		Explode ();
		LabelsOn ();
//		if (expld || peel) {
//			Third_cam.SetActive(true);
//		} else{
//			Third_cam.SetActive(false);
//		}
		
	}
	public void LabelsOn(){
		if (mark) {
			for (int i = 0; i < Labels.Length; i++) {
				Labels [i].SetActive (true);
			}
		} else {
			for (int i = 0; i < Labels.Length; i++) {
				Labels [i].SetActive (false);
			}
		}
	}
	public void StandardMode(){

		for (int i = 0; i<Objects.Length; i++) {

			if(Objects[i].tag == "Selected"){

				if(Objects[i].GetComponent<Renderer>()){
					Objects[i].GetComponent<Renderer>().material = HeightLighted_Materais[i];
					Explode_objects_ThirdCam[i].GetComponent<Renderer>().material = HeightLighted_Materais[i];
				}
				else{

					Renderer[] renderers = Objects[i].GetComponentsInChildren<Renderer>();

					Renderer[] renderers_1= Explode_objects_ThirdCam[i].GetComponentsInChildren<Renderer>();
					foreach (Renderer frogChild in renderers){
						frogChild.material = HeightLighted_Materais[i];
					}
					foreach (Renderer frogChild in renderers_1){
						frogChild.material = HeightLighted_Materais[i];
					}
				}
			}
			else{
//				if(Objects[i].GetComponent<Renderer>()){
//					Objects[i].GetComponent<Renderer>().material = Normal_Materais[i];
//					Explode_objects_ThirdCam[i].GetComponent<Renderer>().material =Transparency_mat[i];
//				}
//				else{
//					Renderer[] renderers = Objects[i].GetComponentsInChildren<Renderer>();
//					Renderer[] renderers_1= Explode_objects_ThirdCam[i].GetComponentsInChildren<Renderer>();
//					foreach (Renderer frogChild in renderers){
//						frogChild.material = Normal_Materais[i];
//					}
//					foreach (Renderer frogChild in renderers_1){
//						frogChild.material =Transparency_mat[i];
//					}
//				}
			}

			Objects[i].SetActive(true);

		}
	}

	public void TransparencyMode(){

		for (int i = 0; i<Objects.Length; i++) {
			if(Objects[i].tag == "Selected"){

				if(Objects[i].GetComponent<Renderer>()){
					Objects[i].GetComponent<Renderer>().material = HeightLighted_Materais[i];
					Explode_objects_ThirdCam[i].GetComponent<Renderer>().material = HeightLighted_Materais[i];
				}
				else{
					Renderer[] renderers = Objects[i].GetComponentsInChildren<Renderer>();
					Renderer[] renderers_1= Explode_objects_ThirdCam[i].GetComponentsInChildren<Renderer>();
					foreach (Renderer frogChild in renderers){
						frogChild.material = HeightLighted_Materais[i];
					}
					foreach (Renderer frogChild in renderers_1){
						frogChild.material = HeightLighted_Materais[i];
					}
				}

			}
			else{
				if(Objects[i].GetComponent<Renderer>()){
					Objects[i].GetComponent<Renderer>().material = Transparency_mat[i];
					Explode_objects_ThirdCam[i].GetComponent<Renderer>().material =Transparency_mat[i];
				}
				else{
					Renderer[] renderers = Objects[i].GetComponentsInChildren<Renderer>();
					Renderer[] renderers_1= Explode_objects_ThirdCam[i].GetComponentsInChildren<Renderer>();
					foreach (Renderer frogChild in renderers){
						frogChild.material = Transparency_mat[i];
					}
					foreach (Renderer frogChild in renderers_1){
						frogChild.material =Transparency_mat[i];
					}
				}
			}
			Objects[i].SetActive(true);
		}
	}

	void IsolatedMode(){

		for (int i = 0; i<Objects.Length; i++) {
			if(Objects[i].tag == "Selected"){
				Objects[i].SetActive(true);
			}
			else{
				Objects[i].SetActive(false);
			}
		}		
	}
	public int j= 0;

	public void DisectMode(GameObject obj){

		if (obj.GetComponent<Renderer> ()) {

			obj.GetComponent<Renderer> ().enabled = false;
			obj.GetComponent<Collider> ().enabled = false;

		} else {
			Renderer[] renderers = obj.GetComponentsInChildren<Renderer>();
			Collider[] colliders = obj.GetComponentsInChildren<Collider>();

			foreach (Renderer frogChild in renderers){
				frogChild.GetComponent<Renderer> ().enabled = false;
			}
			foreach (Collider frogChild in colliders){
				frogChild.GetComponent<Collider> ().enabled = false;
			}
		}
		disect_objs [j] = obj;
		j = j + 1;
	}

	public void Undo_mode(){

		if (j > 0) {

			if (disect_objs[j-1].GetComponent<Renderer> ()) {
				disect_objs[j-1].GetComponent<Renderer>().enabled = true;
				disect_objs[j-1].GetComponent<Collider>().enabled = true;
			}
			else{
				Renderer[] renderers = disect_objs[j-1].GetComponentsInChildren<Renderer>();
				Collider[] colliders = disect_objs[j-1].GetComponentsInChildren<Collider>();

				foreach (Renderer frogChild in renderers){
					frogChild.GetComponent<Renderer> ().enabled = true;
				}
				foreach (Collider frogChild in colliders){
					frogChild.GetComponent<Collider> ().enabled = true;
				}
			}
			j--;
		}
	}







	public void Reset_mode(){
//		orbit.cameraRotSide = 10;
//		orbit.distance = 0.7036119f;
		j= 0;

		for (int i = 0; i<Objects.Length; i++) {
			Objects [i].tag = "Not_Selected";
			Objects [i].SetActive (true);

			if (Objects[i].GetComponent<Renderer> ()) {
				Objects [i].GetComponent<Renderer> ().material = Normal_Materais [i];
				Objects [i].GetComponent<Renderer> ().enabled = true;
				Objects [i].GetComponent<Collider> ().enabled = true;

			}
			else{
				Renderer[] renderers = Objects[i].GetComponentsInChildren<Renderer>();
				Collider[] colliders = Objects[i].GetComponentsInChildren<Collider>();

				foreach (Renderer frogChild in renderers){
					frogChild.GetComponent<Renderer> ().enabled = true;
					frogChild.GetComponent<Renderer> ().material = Normal_Materais [i];
				}
				foreach (Collider frogChild in colliders){
					frogChild.GetComponent<Collider> ().enabled = true;
				}
			}
		}
		//		Annotation.anno = false;

		//		Anno_Reset ();

		stdMode = true;
		TrancMode = false;
		IsoMode = false;
		MulSelMode = false;
		disect = false;
		undo_clk = false;
		expld = false;
		peel = false;
		selObj_count = 0;

		expld = false;
		peel = false;
//		Buttons [5].GetComponent<UISprite> ().spriteName = "peel";

	}	

	public void Explode(){
		if (!peel) {
			if (expld) {
				for (int i = 0; i<Objects.Length; i++) {
					Objects [i].transform.localPosition = Vector3.Lerp (Objects [i].transform.localPosition, Target_positions [i].localPosition, Time.deltaTime * 2);
				}
			} else {
				for (int j = 0; j<Objects.Length; j++) {
					Objects [j].transform.localPosition = Vector3.Lerp (Objects [j].transform.localPosition, Initial_positions [j], Time.deltaTime * 2);

				}
			}
		} 
	}

	

	public void Collider_Enable(){
		for (int i = 0; i<Objects.Length; i++) {
			Objects [i].tag = "Not_Selected";
			Objects [i].SetActive (true);

			if (Objects[i].GetComponent<Renderer> ()) {
				Objects [i].GetComponent<Collider> ().enabled = true;
			}
			else{
				Collider[] colliders = Objects[i].GetComponentsInChildren<Collider>();
				foreach (Collider frogChild in colliders){
					frogChild.GetComponent<Collider> ().enabled = true;
				}
			}
		}
	}
	public void Collider_disabled(){
		for (int i = 0; i<Objects.Length; i++) {
			Objects [i].tag = "Not_Selected";
			Objects [i].SetActive (true);

			if (Objects[i].GetComponent<Renderer> ()) {
				Objects [i].GetComponent<Collider> ().enabled = false;
			}
			else{
				Collider[] colliders = Objects[i].GetComponentsInChildren<Collider>();
				foreach (Collider frogChild in colliders){
					frogChild.GetComponent<Collider> ().enabled = false;
				}
			}
		}
	}


}

