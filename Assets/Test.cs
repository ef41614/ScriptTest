
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boss {        
	private int hp = 100;          // 体力
	private int mp = 53;          // 最大魔法力（初期値）
	private int recover = 10;          // エーテルによるMP回復量
	private int count_ether = 2;          // エーテルの所持数（初期値）

	// 魔法攻撃用の関数(ファイア：cost(=消費MP)は5)
	public void Magic(int cost,int power,int normal_atk) {
		// 残りmpを減らす
		if (mp >= cost){ 
			this.mp -= cost;
			if(power > 15){
				Debug.Log("魔法攻撃をした。残りMPは" + this.mp +"／53。" +power + "のダメージを与えた");
			}else{
				Debug.Log("魔法攻撃が外れた...。残りMPは" + this.mp +"／53。" +"(デバッグ用：power=" + power + ")");
			}

		}else{
			Debug.Log("残りMPは" + this.mp + "。MPが足りないため魔法が使えない。" );
			if(count_ether > 0){
				this.count_ether -= 1;
				// 回復用の関数を呼び出す
				Recovery();
			}else if(normal_atk > 0){
				Debug.Log("通常物理攻撃をした。" +normal_atk + "のダメージを与えた");
			}else{
				Debug.Log("通常物理攻撃が外れた...。" +"(デバッグ用：normal_atk=" + normal_atk + ")");	
			}		
		}
	}

	// 防御用の関数
	public  void Defence(int damage) { 
		if(damage >0){
			// 残りhpを減らす
			this.hp -= damage;
			Debug.Log( "相手の攻撃！"+damage+"のダメージを受けた。残りHPは" + this.hp +"／100。");
		}else{
			Debug.Log( "相手の攻撃！ MISS。残りHPは" + this.hp +"／100。");
		}

	}

	// 回復用の関数(回復エーテル)
	public  void Recovery() { 
		Debug.Log( "アイテム：エーテルを使用した。+" + recover +"MPが回復した" );
		// 残りmpを増やす
		this.mp += recover;
		Debug.Log( "残りMP："+mp+"／53。エーテルの残りは"+ this.count_ether +"個。" );
	}



}



public class Test : MonoBehaviour {

	private string datetimeStr;

	void Start () {
		//現在時刻表示
		datetimeStr = System.DateTime.Now.ToString();
		Debug.Log ("■■■■■■■■■■■■■■■■■■■■■■■■課題開始■■■■■■■■■■■■■■■■■■■■■■■■");
		Debug.Log(datetimeStr);

		// 要素数5の配列を初期化する
		int[] array = {28,56,15,77,02};

		//配列の各要素の値を順番に表示
		Debug.Log ("配列の各要素の値を「順番」に表示");
		for (int i = 0; i < 5; i++) {
			Debug.Log (array [i]);
		}
		Debug.Log ("------------------------------");

		// for文を使い、配列の各要素の値を逆順に表示
		Debug.Log ("配列の各要素の値を「逆順」に表示");
		for (int i = 4; i >= 0 ; i--) {
			Debug.Log (array [i]);
		}
		Debug.Log ("＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝");
		Debug.Log ("    ↓↓ここから発展課題↓↓      ");
		Debug.Log ("＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝");	





		// Bossクラスの変数を宣言してインスタンスを代入
		Boss lastboss = new Boss ();

		for (int i = 0; i < 20; i++) {
			Debug.Log("--◆"+ (i+1) +"ターン目◆---------------------------------------" );

			int rnd_power = Random.Range(10, 26);  // 魔法攻撃力	
			int rnd_normal_atk = Random.Range(-3, 10);  // 通常物理攻撃力	
			int rnd_damage = Random.Range(-2, 6);  // ダメージ	

			// 魔法攻撃用の関数を呼び出す
			lastboss.Magic(5,rnd_power,rnd_normal_atk);


			// 防御用の関数を呼び出す
			lastboss.Defence(rnd_damage);

		}

		// 打ち切りエンド
		Debug.Log ("■■■■■■■■■■■■■■■■■■■■■■■■■■");
		Debug.Log ("＞＞＞俺たちの戦いはこれからだ！！＜＜＜" );
		Debug.Log ("■■■■■■■■■■■■■■■■■■■■■■■■■■");

	}






	// Update is called once per frame
	void Update () {

	}
}
