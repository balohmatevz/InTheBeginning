using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

    public bool progressOnClick;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseUp()
    {
        

        float aspectRationDifference = Screen.width - Screen.height;

        Vector3 mousePos = Input.mousePosition;
        mousePos.y = mousePos.y / Screen.height;
        mousePos.x = (mousePos.x - aspectRationDifference / 2) / Screen.height;

        mousePos.x -= 0.5f;
        mousePos.y -= 0.5f;

        if (Mathf.Abs(mousePos.x) < 0.15f && mousePos.y < -0.4f)
        {
            return;
        }

        Vector2 pos = new Vector2(mousePos.x, mousePos.y);

        float rot = Vector2.Angle(Vector2.up, pos);
        if (mousePos.x < 0)
        {
            rot = -rot;
        }
        
        if (C.inputController.usingTool != null)
        {
            C.inputController.usingTool.targetRotation = rot;
        }
        if (progressOnClick)
        {
            progressOnClick = false;
            C.campaign.Progress2();
        }
    }
}
