
using System.Collections;
using UnityEngine;

class peelDrag : MonoBehaviour
{
	private bool dragging = false;
	private float distance;
	public Vector3 init_pos;
	RaycastHit hit;
	public Vector3 temp;
	public bool stick_l;
	static public bool stic_enab;
	public Vector3 screenSpace;
	public Vector3 offSet;
	public float speed;

	void Start (){
		stick_l =false;
		stic_enab =false;

		init_pos = transform.position;
//
//		if (Application.platform==RuntimePlatform.WebGLPlayer) {  
//			speed = speed*5;
//		}
//		else if(Application.platform==RuntimePlatform.Android){
//			speed = 0.03f;
//		}
//		else{
//			speed = 0.01f;
//		}
	}

	void MouseDown()
	{	

		init_pos = transform.position;
		dragging = true;
		screenSpace = Camera.main.WorldToScreenPoint (transform.position);
		offSet = transform.position-Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
	}

	void MouseUp5()
	{
		dragging = false;
	
	}
	
	void Update()
	{
		if (Controller.peel) {
			
			if (Input.GetMouseButtonDown (0)) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
			
				if (Physics.Raycast (ray, out hit, 100)) {
					if (hit.collider.name == this.name)
						hit.collider.SendMessage ("MouseDown", SendMessageOptions.DontRequireReceiver);
				}	
			}
		
			if (Input.GetMouseButtonUp (0)) {
				SendMessage ("MouseUp5", SendMessageOptions.DontRequireReceiver);
			}

			if (dragging) {
				Vector3 curScreenSpace = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
				Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenSpace) + offSet;
				gameObject.transform.position = curPosition;
			}
		}
	}

}
