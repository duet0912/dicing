using UnityEngine;
using System;
using System.Collections;
using UniRx;
using UniRx.Triggers;

public class dice_stop : MonoBehaviour {

	//ダイスの出目
	private int diceUp = 0;

	//ダイスの位置
	private Transform dicePos;

	private GameObject thisDice;
	private Rigidbody _rigidbody;
	private dice_men dice_men;


	//これは何面ダイス？
	public int diceType = 0;

	void Start () {
		//初期代入
		thisDice = this.gameObject;

		dicePos = this.gameObject.transform;
		dice_men = GetComponent<dice_men> ();

		_rigidbody = GetComponent<Rigidbody>();



		//ダイスの停止状態を検知
		//引数：
		//戻り値：出た目の値
		//checkDiceUp();

	}
	
	// Update is called once per frame
	void Update () {

	}



	public void checkDiceUp()
	{
		//Transform lastPos = nowPos; //過去の位置
		var disposables = new CompositeDisposable ();
		/*
		Observable.EveryUpdate()
			.Where(_ => isdiceRoll)
			.Subscribe(_ =>{
			}).AddTo(disposables);
		*/
		/*
		Observable.Interval (TimeSpan.FromMilliseconds (50))
			//.Where (_ => _rigidbody.velocity.magnitude <= 0.1)

			.Subscribe (_ => {
				disposables.Dispose();
		}).AddTo (disposables);
	*/


		Observable.Interval (TimeSpan.FromMilliseconds (50)) //一定時間ごとに
			.Where (_ => _rigidbody.velocity.magnitude <= 0.1 ) //オブジェクトの停止判定
			//.ThrottleFirst(TimeSpan.FromMilliseconds(1000))
			.Subscribe (l => {
				diceUp = dice_men.test (diceType, thisDice);
				Debug.Log (diceUp);		
				disposables.Dispose ();
			}).AddTo (disposables);
		

	}
		






	// ------------------------------------------------------------------------------------------------

	int checkXYZ(Transform nowP,Transform lastP,int dU)
	{		

		//もしサイコロが停止したら,出目を計測する
		if(mathDistance(nowP.transform.position, lastP.transform.position)){
			
			mathDiceUp(nowP,dU); //出目の計測
			return dU;
		}

		nowP = lastP; //状態の更新


		return dU; //出目の計測
	}


	//出目の計測
	int mathDiceUp(Transform nowP, int dU)
	{
		//Debug.Log (nowP.rotation);

		return dU;
	}


	//2点間の距離が0なら、TRUEを返す
	bool mathDistance(Vector3 A ,Vector3 B)
	{
		bool disCheck = false;

		if(Vector3.Distance (A,B) == 0.0){
			disCheck =true;
		}

		return disCheck;
	}

}
