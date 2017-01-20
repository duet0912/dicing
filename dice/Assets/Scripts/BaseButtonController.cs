using UnityEngine;
using System.Collections;

public class BaseButtonController : MonoBehaviour {

	public BaseButtonController button;

	public void OnClick()
	{
		if (button == null) {
			throw new System.Exception ("Button instance is NULL");
		}

		button.OnClick (this.gameObject.name);
	}


	protected virtual void OnClick(string objectName)
	{
		Debug.Log ("Base Button");

	}
}
