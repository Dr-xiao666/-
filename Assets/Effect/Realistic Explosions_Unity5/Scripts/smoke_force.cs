using UnityEngine;
using System.Collections;

public class smoke_force : MonoBehaviour {
	private float t1=0f;
	private float t=0f;
	public float delay = .7f;
	private bool expl=false;
	public float force_k=1f;
	// Use this for initialization
	void explo () {
		expl=true;
	this.transform.eulerAngles = new Vector3(Random.Range(-50f,-85f),Random.Range(-180f,180f),0f);
		this.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward*50f*force_k*Random.Range(.9f,1.1f));
	}
	
	// Update is called once per frame
	void Update () {
	
	t1+=Time.deltaTime;
	if (t1>=delay){	
			t+=Time.deltaTime;
	if (t>3f){
			print (this.GetComponent<ParticleSystem>().startSize);	
			this.GetComponent<ParticleSystem>().startSize+=(0f-this.GetComponent<ParticleSystem>().startSize)/30f;
			this.GetComponent<ParticleSystem>().startColor+=(new Color(this.GetComponent<ParticleSystem>().startColor.r,this.GetComponent<ParticleSystem>().startColor.g,this.GetComponent<ParticleSystem>().startColor.b,0f)-this.GetComponent<ParticleSystem>().startColor)/10f;
		}	
		if (t>7f){
			Destroy(this.gameObject);
			
		}
	}
	}
	void FixedUpdate(){
		if (t1>=delay){	
			if (!expl)
			{
				explo ();
			}
		this.GetComponent<Rigidbody>().AddForce(-Vector3.up/4f);
		}
	}
}
