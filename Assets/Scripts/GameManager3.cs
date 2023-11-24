using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager3 : MonoBehaviour
{
	public GameObject panelWalls;

	public GameObject talkDisplay;
	public Text talkText;
	public GameObject lSDisplay;

	public InputField inputField;
	public Text displayInputText;
	public Text judgeText;
	public Text cPUMessage;


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
        var scenario03 = new Scenario()
        {
            ScenarioID = "scenario03",
            Texts = new List<string>()
            {
				"さっき君が入力した /Hall/OldBooks や /Hall/Jewels について説明しよう。",
				"/Hall/OldBooksのような物は 絶対パス という。",
				"絶対パスとは、ファイル( History1.txt など)や\nディレクトリ(これまで 区画 と呼んでいたもの)の場所を\n一番上の階層から示す方法のことだ。",
				"この家だと、Hallからここまでの階層を示してることになる。",
				"また、それに対して 相対パス というのもある。",
				"相対パスは、君が今いるディレクトリを基準にして\nファイルやディレクトリの場所を示す方法のことだ。",
				"今まで君が cd 区画名 とコマンドを使って区画を移動していた時は\n相対パスを使っていた。",
				"相対パスは特に今いるディレクトリ内にあるファイルや\nディレクトリへのアクセスを行うときに便利だ。",
				"折角だし相対パスにもう少し慣れようか。\n君はここから相対パスを使って OldBooks に移動してくれ。",
				"ミッション:相対パスを用いて区画 OldBooks に移動しろ！開始",
				"まずは区画 Hall に移動しましょう。区画を移動するコマンドは cd 区画名 です。\nコンソールに cd .. を入力して実行しましょう。",
				"区画 Hall に移動出来ました！",
				"そういえば、cd .. について言い忘れていたな。cd .. は親ディレクトリに移動するんだ。",
				"もう少しわかりやすく言おう。親ディレクトリは今いるディレクトリから\n1つ上の階層に位置するディレクトリの事を指す。",
				"この家で考えるとわかりやすいと思う。\nこ家で考えると区画 OldBooks や Jewels にとって、\n区画 Hall は親ディレクトリになるんだ。",
				"そして、今いるディレクトリの親ディレクトリに移動するには cd .. を使う。\nだから君は移動できた、ということになる。",
				"それじゃあ、君は OldBooks に移動してくれ。私も後で向かう。",
				"それでは区画 OldBooks に移動します。コンソールにコマンドを入力して実行しましょう。",
				"区画 OldBooks に移動できました！"
			},

        };

		inputField = GameObject.Find("InputField").GetComponent<InputField>();

		SetScenario(scenario03);
	}

	void SetScenario(Scenario scenario)
	{
		currentScenario = scenario;
		talkText.text = currentScenario.Texts[0];
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
						case 11:
						case 12:
						case 13:
						case 14:
						case 15:
							SetNextMessage();
							break;

						case 9:
						case 16:
							Play();
							break;

						case 18:
							SetNextMessageOnPlay();
							break;

						case 10:
						case 17:
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

	void SetNextMessage()
	{
        talkDisplay.SetActive(true);

		if(index == 11)
        {
			cPUMessage.text = "";
        }

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

	void SetNextMessageOnPlay()
	{
		if (currentScenario.Texts.Count > index + 1)
		{
			index++;
			cPUMessage.text = currentScenario.Texts[index];
		}
		else
		{
			SceneManager.LoadScene("ClearScene");
		}
	}

	void Play()
	{
		talkDisplay.SetActive(false);
		index++;
		cPUMessage.text = currentScenario.Texts[index];
	}

	public void DisplayText()
	{
		string textValue = inputField.text;
		displayInputText.text = inputField.text;
		pushFlag = true;

		switch (index)
		{
			case 10:
				if (textValue == "cd ..")
				{
					judgeText.text = "";
					index++;
					cPUMessage.text = currentScenario.Texts[index];
					panelWalls.transform.localPosition = new Vector3(-2000.0f, 0.0f, 0.0f);
				}

				else
				{
					judgeText.text = "無効なコマンドです。";
					judgeText.color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
				}
				break;

			case 17:
				if (textValue == "cd OldBooks")
				{
					judgeText.text = "";
					index++;
					cPUMessage.text = currentScenario.Texts[index];
					panelWalls.transform.localPosition = new Vector3(-4000.0f, 0.0f, 0.0f);
				}

				else
				{
					judgeText.text = "無効なコマンドです。";
					judgeText.color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
				}
				break;
		}

	}

}
