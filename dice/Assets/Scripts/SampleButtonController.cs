using UnityEngine;
using System.Collections;

public class SampleButtonController : BaseButtonController {

	[SerializeField]
	private float throwDice_Power = 0.0f;

	protected override void OnClick(string objectName)
	{
		if("throwDice".Equals(objectName))
		{
			this.throwDice();
		}
		else{
			throw new System.Exception("Not implemented");

		}
	}


	//ダイスを投げる
	private void throwDice()
	{
		GameObject[] Dices= GameObject.FindGameObjectsWithTag ("Dice");

		Rigidbody rbody = null;
		//画面上のダイスを取得し、全てにaddForceする

		float rollX = 0;
		float rollZ = 0;


		foreach (GameObject hoge in Dices) {


			dice_stop piyo = hoge.GetComponent<dice_stop> ();

			rbody = hoge.GetComponent<Rigidbody> ();

			if (piyo != null) {
				if (rbody.velocity.magnitude <= 0.1) {
					piyo.checkDiceUp ();
				}
			}
			switch(Random.Range(0,4)){
			case 0:
				rollX = 1;
				rollZ = 1;
				break;
			case 1:
				rollX = 1;
				rollZ = -1;
				break;
			case 2:
				rollX = -1;
				rollZ = 1;
				break;
			case 3:
				rollX = -1;
				rollZ = -1;
				break;
			default:
				rollX = 0;
				rollZ = 0;
				break;
			}

			rbody.maxAngularVelocity = 10000;
			rbody.AddForce(new Vector3 (0, 10, 0) );
			rbody.AddTorque (new Vector3 (1000, 1000,0));
			rbody.AddForce(new Vector3 (rollX * throwDice_Power*50, 1, rollZ*throwDice_Power*50) );
			rbody.AddTorque (new Vector3 (2000, 2000,0));

		}
	}

	//private 

}
