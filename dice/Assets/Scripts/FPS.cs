using UnityEngine;
using System.Collections;

public class FPS : MonoBehaviour {

	void Awake() {
		Application.targetFrameRate = 30;
	}
}
