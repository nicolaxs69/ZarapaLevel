using UnityEngine;
using System.Collections;

public class cambiandode : MonoBehaviour {
	private float timer = 50.0f;

	void Update(){
		timer -= Time.deltaTime;

		if (timer <= 0) {
			timer = 0;
		}
	
	}

	void OnGUI ()
	{
		
		GUIStyle style = GUI.skin.GetStyle ("label");
		style.fontSize = (int)(40.0f);

		//style.fontSize = (int)(20.0f + 10.0f * Mathf.Sin (Time.time));


		GUI.Label (new Rect (20, 20, 500, 80), ""+timer.ToString("0"));
	}
}
