using UnityEngine;
using System.Collections;

public class Particle_force : MonoBehaviour {
	private float t=0f;
	// Use this for initialization
	void Start () {
	this.transform.eulerAngles = new Vector3(Random.Range(-40f,-60f),Random.Range(-180f,180f),0f);
		this.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward*20f*Random.Range(.75f,1.5f));
	}
	
	// Update is called once per frame
	void Update () {
	t+=Time.deltaTime;
	if (t>1f){
			this.GetComponent<ParticleSystem>().startSize+=(0f-this.GetComponent<ParticleSystem>().startSize)/30f;
			this.GetComponent<ParticleSystem>().startColor+=(new Color(this.GetComponent<ParticleSystem>().startColor.r,this.GetComponent<ParticleSystem>().startColor.g,this.GetComponent<ParticleSystem>().startColor.b,0f)-this.GetComponent<ParticleSystem>().startColor)/10f;
		}	
		if (t>2f){
			Destroy(this.gameObject);
			
		}
	}
	
	void FixedUpdate(){
		this.GetComponent<Rigidbody>().AddForce(-Vector3.up/4f);
		
	}
}
