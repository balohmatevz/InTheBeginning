using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

	public Tool usingTool;

	// Use this for initialization
	void Awake () {
		C.inputController = this;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void SelectTool(int i){
		if (i < C.planet.ToolList.Count) {
			usingTool = C.planet.ToolList [i];
		}
	}
}
