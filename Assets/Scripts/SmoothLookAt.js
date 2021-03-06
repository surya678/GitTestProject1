var target : GameObject;
var damping = 6.0;
var smooth = true;

function Start () {
target = GameObject.Find("Main Camera");
	// Make the rigid body not change rotation
if (GetComponent.<Rigidbody>())
		GetComponent.<Rigidbody>().freezeRotation = true;
}

@script AddComponentMenu("Camera-Control/Smooth Look At")

function LateUpdate () {
	if (target) {
		if (smooth){
			// Look at and dampen the rotation
			var rotation = Quaternion.LookRotation(target.transform.position - transform.position);
			//print(target.transform.position - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
			//print(transform.rotation, rotation, Time.deltaTime * damping));
		}else{
			// Just lookat
		    transform.LookAt(target.transform);
		}
	}
}

