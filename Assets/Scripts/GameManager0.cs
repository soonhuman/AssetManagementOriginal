using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameManager0 : MonoBehaviour
{
	public GameObject talkDisplay;
	public Text talkText;

	private string text;
	private bool pushFlag = false;

	List<Scenario> scenarios = new List<Scenario>();
	Scenario currentScenario;
	int index = 0;

	class Scenario
	{
		public string ScenarioID;
		public List<string> Texts;
		public string NextScenarioID;
	}

	// Start is called before the first frame update
	void Start()
    {
		var scenario00 = new Scenario()
		{
			ScenarioID = "scenario00",
			Texts = new List<string>()
			{
				"ここ数年、世界中でCOVID-19が大流行し、企業はクラウドサービスを用いて\nシステム開発を行うようになった。",
				"企業はクラウドサービスを用いてシステムを作ることが出来る人材を育成したり\n雇用したりする傾向が見られる。",
				"だが、その一方で高校や大学ではクラウドサービスを自分のシステムに組み込む\n際に用いられるUnix/Linuxコマンドの教育が行われていない。",
				"それでは、企業が求めているクラウドサービスが利用できる人材は育ちにくい。\nそれゆえ、今日ではUnix/Linuxコマンドを学ぶ手段の拡充が必要なのだ。\nこのアプリも、それが目的の1つとしてある。",
				"君にはこれからUnix/Linuxコマンドを学んでもらおうと思うが、\nその前にまず、Unix/Linuxコマンドについて説明しようと思う。",
				"この世界には、キーボードの文字入力だけでやり取りをする世界がある。",
				"別に普通ではないかと思うかもしれないが、考えてみて欲しい。\n文字「だけ」ということは、そこには画像が存在しないという事である。",
				"スマホやパソコンのアプリのアイコンも無ければ、\n画面上で何かを触ったり、ドラッグ&ドロップで動かしたりすることもない。\nまず、そもそもそんな考え方が最初から存在しない。",
				"ではそんな中で「パソコン上のファイルを移動してくれ。」\nと言われた時、君はどうするだろうか。\n何度も言うが、君が使えるものはキーボード1つだけだ。",
				"もしかしたら君は「そんなの不可能ではないか。」と思うかもしれない。",
				"だが実は、ファイルを移動することはキーボードの文字入力だけで可能である。\nそれを実現するために用いられるのが、Unix/Linuxコマンドだ。",
				"Unix/Linuxコマンドは、このようなファイルの移動をはじめとして\nファイルやディレクトリの名称変更や削除、コピーなどを\n文字入力だけで行う。",
				"これを聞いて、もしかしたら君はこう思ったかもしれない。\n「それならいつも使ってるパソコンやスマートフォンでも出来る。」\n「パソコンやスマホでやる方が簡単だ。」と。",
				"確かにそうかもしれない。実際、君のパソコンで Ctrl + C でコピーをする方が\nわざわざ文字を打ってコピーするより遥かに速いのは事実だろう。\nだが、将来君は自分のパソコンではないパソコンで作業をしている可能性もある。",
				"「もしかして他人のPCを勝手に操作しているのか？」と思うかもしれない。\nその通りである。厳密には、操作しているのは他人のパソコンというよりは\n世界のどこかにあるパソコンだが。\n",
				"言っていることがあまり理解できないかもしれないが、\n世の中には実際にそれを仕事の1つにしている人もいる。\nもちろん、犯罪行為に手を染めているわけではない。",
				"すまない、話が逸れてしまったね。そろそろ本題に入ろうか。\n折角ここに来てもらったんだ、君に1つ仕事を頼みたい。\n君にはある家の資産管理を手伝ってもらいたい。",
				"その家は不思議でね。なぜかUnix/Linuxコマンドを用いないと何もできないんだ。\n家にあるものはUnix/Linuxコマンドでしか動かせないし、\n部屋の移動や明かりをつけて中を確認することもUnix/Linuxコマンドでしか出来ない。",
				"なんだその家は、と思っただろう。\nだが、私がさっき言った「キーボードの文字入力だけでやり取りをする世界」を\n体験するにはもってこいの場所だと思わないか？",
				"それでは、その家のことは頼んだぞ。"
			},

		};

		SetScenario(scenario00);
	}

    // Update is called once per frame
    void Update()
    {
		if (currentScenario != null)
		{
			if (Input.GetKey(KeyCode.Return))
			{
				if (pushFlag == false)
				{
					pushFlag = true;

					switch (index)
					{
						case 0:
						case 1:
						case 2:
						case 3:
						case 4:
						case 5:
						case 6:
						case 7:
						case 8:
						case 9:
						case 10:
						case 11:
						case 12:
						case 13:
						case 14:
						case 15:
						case 16:
						case 17:
						case 18:
						case 19:
						case 20:
							SetNextMessage();
							break;
					}

				}

			}

			else
			{
				pushFlag = false;
			}

		}

	}

	void SetScenario(Scenario scenario)
	{
		currentScenario = scenario;
		talkText.text = currentScenario.Texts[0];
	}

	void SetNextMessage()
	{
		if (currentScenario.Texts.Count > index + 1)
		{
			index++;
			talkText.text = currentScenario.Texts[index];
		}
		else
		{
			SceneManager.LoadScene("ClearScene");
		}
	}

	public void OnClick()
    {
		index = 0;
		SceneManager.LoadScene("LevelScene");
	}

}
