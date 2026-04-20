using UnityEngine;
using System.Collections;

public class debris_force : MonoBehaviour {
	private float t=0f;
	// Use this for initialization
	void Start () {
	this.transform.eulerAngles = new Vector3(Random.Range(-0f,-45f),Random.Range(-180f,180f),0f);
		this.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward*20f*Random.Range(1f,1.5f));
		this.transform.localScale= new Vector3(Random.Range(.6f,1.2f),Random.Range(.3f,1f),Random.Range(.3f,1f));
		
	}
	
	// Update is called once per frame
	void Update () {
	this.GetComponent<Renderer>().material.color += (new Color(1f,1f,1f,1f)- this.GetComponent<Renderer>().material.color)/30f;
	}
	
	void FixedUpdate(){
		this.GetComponent<Rigidbody>().AddForce(-Vector3.up/2f);
		
	}
}
