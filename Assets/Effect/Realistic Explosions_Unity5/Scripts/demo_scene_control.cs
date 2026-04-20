using UnityEngine;
using System.Collections;

public class demo_scene_control : MonoBehaviour {
	public GameObject gr_explosion;
	public GameObject mass_gr_explosion;
	public GameObject d_gr_explosion;
	public GameObject short_gr_explosion;
	public GameObject space_explosion;
	public GameObject short_space_explosion;
	public GameObject circle_explosion;
	public GameObject nuke_explosion;
	public GameObject flash_explosion;
	public GameObject huge_explosion;
	public GameObject smoke_explosion;
	private Transform spawn;
	private Transform n_spawn;
	private Transform dir_spawn;
	private Transform space_spawn;
	private Transform mass_spawn;
	private Transform spawn_smoke;
	// Use this for initialization
	void Start () {
	spawn = GameObject.Find("spawn").transform;
		dir_spawn = GameObject.Find("dir_spawn").transform;
	space_spawn = GameObject.Find("space_spawn").transform;
	mass_spawn = GameObject.Find("mass_spawn").transform;
		spawn_smoke = GameObject.Find("spawn_smoke").transform;
	n_spawn = GameObject.Find("spawn_nuke").transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI(){
		if (GUI.Button(new Rect(20,20,200,20),"Ground Explosion")){
		Instantiate(gr_explosion,spawn.position,spawn.rotation);
			PanWM.shake_value=1f;
			PanWM.shake_speed=10f;
		}
		if (GUI.Button(new Rect(20,50,200,20),"Flash Explosion")){
		Instantiate(flash_explosion,spawn.position,spawn.rotation);
			PanWM.shake_value=1f;
			PanWM.shake_speed=10f;
		}
		if (GUI.Button(new Rect(20,80,200,20),"Massive Ground Explosion")){
		Instantiate(mass_gr_explosion,mass_spawn.position,mass_spawn.rotation);
			PanWM.shake_value=1.5f;
			PanWM.shake_speed=10f;
		}
		if (GUI.Button(new Rect(20,110,200,20),"Directed Ground Explosion")){
		Instantiate(d_gr_explosion,dir_spawn.position,dir_spawn.rotation);
			PanWM.shake_value=.7f;
			PanWM.shake_speed=10f;
		}
		if (GUI.Button(new Rect(20,140,200,20),"Ground Short Explosion")){
		Instantiate(short_gr_explosion,spawn.position,spawn.rotation);
			PanWM.shake_value=.7f;
			PanWM.shake_speed=10f;
		}
		if (GUI.Button(new Rect(20,170,200,20),"Space (No Gravity) Explosion")){
		Instantiate(space_explosion,space_spawn.position,space_spawn.rotation);
			PanWM.shake_value=1f;
			PanWM.shake_speed=10f;
		}
		if (GUI.Button(new Rect(20,200,200,20),"Space Short Explosion")){
		Instantiate(short_space_explosion,space_spawn.position,space_spawn.rotation);
			PanWM.shake_value=.7f;
			PanWM.shake_speed=10f;
		}
		if (GUI.Button(new Rect(20,230,200,20),"Circle Explosion")){
		Instantiate(circle_explosion,spawn.position,spawn.rotation);
			PanWM.shake_value=.5f;
			PanWM.shake_speed=10f;
		}
		
		if (GUI.Button(new Rect(20,260,200,20),"Huge Explosion")){
		Instantiate(huge_explosion,n_spawn.position,n_spawn.rotation);
			PanWM.shake_value=2f;
			PanWM.shake_speed=5f;
			
		}
		
		if (GUI.Button(new Rect(20,290,200,20),"Smoke Explosion")){
		Instantiate(smoke_explosion,spawn_smoke.position,spawn_smoke.rotation);
			PanWM.shake_value=2f;
			PanWM.shake_speed=5f;
			
		}
		
		
		if (GUI.Button(new Rect(20,320,200,20),"NUKE")){
		Instantiate(nuke_explosion,n_spawn.position,n_spawn.rotation);
			PanWM.shake_value=2f;
			PanWM.shake_speed=5f;
			
		}
		
		
	}
}
