using UnityEngine;
using System.Collections;

public class debris_force_big : MonoBehaviour {
	private float t=0f;
	public float delay = .7f;
	private bool expl=false;
	// Use this for initialization
	void Start() {
		this.GetComponent<Collider>().enabled=false;
		
	}
	
	void explo () {
		expl=true;
		this.GetComponent<Collider>().enabled=true;
	this.transform.eulerAngles = new Vector3(Random.Range(-0f,-45f),Random.Range(-180f,180f),0f);
		this.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward*30f*Random.Range(1f,1.5f));
		this.transform.localScale= new Vector3(Random.Range(.9f,1.4f),Random.Range(.8f,1.2f),Random.Range(.9f,1.4f));
		
	}
	
	// Update is called once per frame
	void Update () {
		t+=Time.deltaTime;
		if (t>=delay){
	this.GetComponent<Renderer>().material.color += (new Color(1f,1f,1f,1f)- this.GetComponent<Renderer>().material.color)/30f;
		}
	}
	
	void FixedUpdate(){
		if (t>=delay){
			if (expl==false)
			{
				explo();
			}
		this.GetComponent<Rigidbody>().AddForce(-Vector3.up/2f);
		}
		
	}
}
