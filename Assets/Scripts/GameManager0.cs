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
				"この世界には、キーボードの文字入力だけでやり取りをする世界がある。",
				"別に普通ではないかと思うかもしれないが、考えてみて欲しい。\n文字「だけ」ということは、そこには画像が存在しない。",
				"スマートフォンやパソコンのようなアイコンも無いし、\n画面上で何かを触ったり、ドラッグ&ドロップで動かしたりすることもない。\nそもそもそんな考え方は存在しない。",
				"では、そんな中で「パソコン上のファイルを移動してくれ。」\nと言われた時、君はどうすればよいのだろうか。\n何度も言うが、君にはキーボード1つしか使える物がない。",
				"そんな時、君はこう思うのではないか。\n「そんなの無理だ。」と。",
				"だが実は、ファイルを移動することはキーボードの文字入力だけで可能である。\nこれが出来るのが、Unix/Linuxコマンドだ。",
				"このようなファイルの移動をはじめとして、Unix/Linuxコマンドは\nファイルやディレクトリの名称変更や削除、コピーなどが\n文字を入力するだけで出来る。",
				"これを聞いてもしかしたらこう思ったかもしれない。\n「それならいつも使ってるパソコンやスマートフォンでも出来る。」\n「パソコンやスマホでやる方が簡単だよ。」と。",
				"確かにそうかもしれない。だが、将来君は自分のパソコンではないパソコンを"

				
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

}
