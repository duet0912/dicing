using UnityEngine;
using System.Collections;

public class dice_men  : MonoBehaviour{

	public int test(int diceType, GameObject dice)
	{
		float posY = -20000;
		int diceMen =-1;
		foreach (Transform child in dice.transform)
		{

			if (posY < child.transform.position.y) {
				posY = child.transform.position.y;
				diceMen = int.Parse(child.name);
			}
		}
		return diceMen;
	}
}





/*
foreach (Transform child in transform)
{
	//child is your child transform

	Debug.Log ("Child[" + count + "]:" + child.name);
	count++;
}
*/
