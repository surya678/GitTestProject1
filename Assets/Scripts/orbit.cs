using UnityEngine;
using System.Collections;

public class orbit : MonoBehaviour
{
	public Transform target;
	public Transform cam;
	public Vector3 offset = Vector3.zero;
	static public float cameraRotSide;
	static public float cameraRotUp;
	public float cameraRotSideCur;
	public float cameraRotUpCur;
	static public float distance;
	public bool reset_pos ;
	public GameObject hlp;
	public float pinchSpeed;
	private Touch touch;
	private float lastDist = 0;
	private  float curDist = 0;
	static public float initial_dist;
	static  public float c;
	public float zoomStart = 15;
	public float zoomMin;
	public float zoomMax;
	public float cameraRotSideStart;
	public float cameraRotUpStart;
	public float CurentZoom;
	static public bool zoom_In;
	static public bool zoom_Out;
	public static bool orbit_enabled;
	public static bool Zoom_bool;
	public static bool pan_bool;

	void Start ()
	{
		pinchSpeed = 2f;
		cameraRotSide = cameraRotSideStart;
		cameraRotUp = cameraRotUpStart;
		cameraRotUpCur = transform.localEulerAngles.x;	
		cameraRotSideCur = transform.localEulerAngles.y;
		distance = zoomStart;	
		reset_pos = false;
		orbit_enabled = false;
		Zoom_bool= false;
		pan_bool = false;
	}
	
	void Update ()
	{
		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit ();
		}

		if(orbit_enabled){
			reset_pos = false;
			CurentZoom = cam.localPosition.z;
			if (Application.platform != RuntimePlatform.Android) {

					if(Input.GetMouseButton (0)&&!pan_bool){
			
					cameraRotSide += Input.GetAxis ("Mouse X") * 9;
				    cameraRotUp -= Input.GetAxis ("Mouse Y") * 9;

					}
			} else {
				if ((Input.touchCount == 1) && (Input.GetTouch (0).phase == TouchPhase.Moved)) {
					cameraRotSide += Input.GetAxis ("Mouse X") * 5;
					cameraRotUp -= Input.GetAxis ("Mouse Y") * 5;	
				}
			}
		}

		if(Zoom_bool){
			if (Application.platform != RuntimePlatform.Android) {
	
				if (Input.GetKey (KeyCode.KeypadPlus)){
					distance -= 0.1f;
				}
				if (Input.GetKey(KeyCode.KeypadMinus)) {
					distance += 0.1f;
				}
				if(zoom_In){
					distance -= 0.01f;
				}
				if(zoom_Out){
					distance += 0.01f;
				}

				distance *= (1 - 1 * Input.GetAxis ("Mouse ScrollWheel"));

			} else {
				if (Input.touchCount > 1 && (Input.GetTouch (0).phase == TouchPhase.Moved || Input.GetTouch (1).phase == TouchPhase.Moved)) {
					var touch1 = Input.GetTouch (0);
					var touch2 = Input.GetTouch (1);
					curDist = Vector2.Distance (touch1.position, touch2.position);

					if (curDist > lastDist) {
						distance -= Vector2.Distance (touch1.deltaPosition, touch2.deltaPosition) * pinchSpeed / 30;
					} else {
						distance += Vector2.Distance (touch1.deltaPosition, touch2.deltaPosition) * pinchSpeed / 30;
					}

					lastDist = curDist;
				}
				if(zoom_In){
					distance -= 0.01f;
				}
				if(zoom_Out){
					distance += 0.01f;
				}
			}
		}

		if(pan_bool){

				if(Application.platform !=  RuntimePlatform.Android){
				
					if (Input.GetMouseButton(0)) {
				
						float x = - Input.GetAxis("Mouse X")*0.8f*distance/30;
						float y = - Input.GetAxis("Mouse Y")*0.8f*distance/30;
						cam.transform.localPosition = new Vector3(cam.transform.localPosition.x+x, cam.transform.localPosition.y+y,cam.transform.localPosition.z);
					}					

				}
				else{
					if((Input.touchCount == 1)&&(Input.GetTouch(0).phase==TouchPhase.Moved)){
						if (Input.GetMouseButton(0)) {
							float x = - Input.GetAxis("Mouse X")*0.8f*distance/60;
							float y = - Input.GetAxis("Mouse Y")*0.8f*distance/60;
							cam.transform.localPosition = new Vector3(cam.transform.localPosition.x+x, cam.transform.localPosition.y+y,cam.transform.localPosition.z);
						}
					}
				}
		}

		if (distance <= zoomMin) {
			distance = zoomMin;
		} else if (distance >= zoomMax) {
			distance = zoomMax;
		}
	
		if (cam.GetComponent<Camera>().orthographicSize <= zoomMin) {
			cam.GetComponent<Camera>().orthographicSize = zoomMin;
		}
		else if (cam.GetComponent<Camera>().orthographicSize >= zoomMax) {
			cam.GetComponent<Camera>().orthographicSize = zoomMax;
		}
	

		if(cameraRotUp<-89){
			cameraRotUp = -89;	
				}
		if(cameraRotUp>89){
			cameraRotUp = 89;
		}
		
		cameraRotSideCur = Mathf.LerpAngle (cameraRotSideCur, cameraRotSide, Time.deltaTime * 5);
		cameraRotUpCur = Mathf.Lerp (cameraRotUpCur, cameraRotUp, Time.deltaTime * 5);

		Vector3 targetPoint = target.position;
		transform.position = Vector3.Lerp (transform.position, targetPoint + offset, Time.deltaTime);
		transform.rotation = Quaternion.Euler (cameraRotUpCur, cameraRotSideCur, 0);
		float dist = Mathf.Lerp (-cam.transform.localPosition.z, distance, Time.deltaTime * 5);
		cam.localPosition = new Vector3 (cam.localPosition.x, cam.localPosition.y, -dist);
		c = -dist;

	}
}
