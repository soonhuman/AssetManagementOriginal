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

	public Text currentDirectory;
	public InputField inputField;
	public Text displayInputText;
	public Text judgeText;
	public Text cPUMessage;

	public GameObject imageDirectory;
	public GameObject arrowHall;
	public GameObject arrowJewels;
	public GameObject arrowFromJewelsToOldBooks;
	public GameObject arrowFromJewelsToHall;
	public GameObject arrowFromHallToOldBooks;
	public GameObject withHall;
	public GameObject withJewels;
	public GameObject withOldBooks;


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
		imageDirectory.SetActive(false);
		arrowHall.SetActive(false);
		arrowJewels.SetActive(false);
		arrowFromJewelsToOldBooks.SetActive(false);
		arrowFromJewelsToHall.SetActive(false);
		arrowFromHallToOldBooks.SetActive(false);
		withHall.SetActive(false);
		withJewels.SetActive(false);
		withOldBooks.SetActive(false);

		var scenario03 = new Scenario()
        {
            ScenarioID = "scenario03",
            Texts = new List<string>()
            {
				"さっき君が入力した /Hall/OldBooks や /Hall/Jewels について説明しよう。",
				"/Hall/OldBooksのような物は<color=#4169e1>絶対パス</color>という。",
				"絶対パスとは、<color=#4169e1>ファイル</color>(History1.txtなど)や\n<color=#4169e1>ディレクトリ</color>(これまで 部屋 と呼んでいたもの)の場所を\n一番上の階層から示す方法のことだ。",
				"この家だと、Hallからここまでの階層を示してることになる。",
				"また、それに対して<color=#4169e1>相対パス</color>というのもある。",
				"相対パスは、<color=#4169e1>君が今いるディレクトリ</color>(今だとJewels)を基準にして\nファイルやディレクトリの場所を示す方法のことだ。",
				"今まで君が cd 部屋名 とコマンドを使って部屋を移動していた時は\n相対パスを使っていた。",
				"相対パスは<color=#4169e1>特に今いるディレクトリ内にあるファイルや\nディレクトリ</color>へのアクセスを行うときに便利だ。",
				"折角だし相対パスにもう少し慣れようか。\n君はここから相対パスを使って OldBooks に移動してくれ。",
				"ミッション:相対パスを用いて部屋 OldBooks に移動しろ！開始",
				"まずは部屋 Hall に移動しましょう。部屋を移動するコマンドは cd 部屋名 です。\nコンソールに cd .. を入力して実行しましょう。",
				"部屋 Hall に移動出来ました！",
				"そういえば、cd .. について言い忘れていたな。\n<color=#4169e1>cd .. は親ディレクトリに移動</color>するんだ。",
				"もう少しわかりやすく言おう。親ディレクトリは<color=#4169e1>今いるディレクトリから\n1つ上の階層に位置するディレクトリ</color>の事を指す。",
				"この家で例えよう。\nこの家で考えると<color=#4169e1>部屋 OldBooks や Jewels にとって、\n部屋 Hall は親ディレクトリ</color>になるんだ。",
				"そして、今いるディレクトリの親ディレクトリに移動するには cd .. を使う。\nだから君は移動できた、ということになる。",
				"こう見ると相対パスは便利だと思うだろうが、1つ注意点がある。\nそれは、<color=#4169e1>直接アクセスできるのは今いるディレクトリにあるものだけ、</color>\nということだ。",
				"さっきまでの行動を例にしよう。\n先ほど君がいた Jewels で cd .. をすれば、Hallに移動することができる。",
				"だがJewelsにいる時に cd OldBooks とやってもOldBooksには移動できない。\nそれは、<color=#4169e1>JewelsとOldBooksが直接線でつながっていない</color>からだ。",
				"もし君が Jewels から OldBooks に 直接移動したいなら\n<color=#4169e1>cd ../OldBooks</color> と打つ必要がある。",
				"こうすると、<color=#4169e1>一旦 Hall に移動してから、OldBooks に移動する</color>ので\n正しく線を通っているため移動できる。",
				"それじゃあ、君は OldBooks に移動してくれ。\n今は Hall にいるから、さっきのコマンドは使えないぞ。",
				"それでは部屋 OldBooks に移動します。コンソールにコマンドを入力して実行しましょう。",
				"部屋 OldBooks に移動できました！"
			},

        };

		inputField = GameObject.Find("InputField").GetComponent<InputField>();
		inputField.interactable = false;

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
							SetNextMessage();
							break;

						case 1:
							imageDirectory.SetActive(true);
							SetNextMessage();
							break;

						case 2:
							arrowHall.SetActive(true);
							SetNextMessage();
							break;

						case 3:
							arrowHall.SetActive(false);
							SetNextMessage();
							break;

						case 4:
							arrowJewels.SetActive(true);
							SetNextMessage();
							break;

						case 5:
							arrowJewels.SetActive(false);
							SetNextMessage();
							break;

						case 6:
							SetNextMessage();
							break;

						case 7:
							SetNextMessage();
							break;

						case 8:
							imageDirectory.SetActive(false);
							SetNextMessage();
							break;

						case 11:
							SetNextMessage();
							break;

						case 12:
							imageDirectory.SetActive(true);
							SetNextMessage();
							break;

						case 13:
							withHall.SetActive(true);
							withJewels.SetActive(true);
							withOldBooks.SetActive(true);
							SetNextMessage();
							break;

						case 14:
							SetNextMessage();
							break;

						case 15:
							withHall.SetActive(false);
							withJewels.SetActive(false);
							withOldBooks.SetActive(false);
							SetNextMessage();
							break;

						case 16:
							arrowFromJewelsToHall.SetActive(true);
							SetNextMessage();
							break;

						case 17:
							arrowFromJewelsToOldBooks.SetActive(true);
							SetNextMessage();
							break;

						case 18:
							arrowFromJewelsToHall.SetActive(false);
							arrowFromJewelsToOldBooks.SetActive(false);
							SetNextMessage();
							break;

						case 19:
							arrowFromJewelsToHall.SetActive(true);
							arrowFromHallToOldBooks.SetActive(true);
							SetNextMessage();
							break;

						case 20:
							imageDirectory.SetActive(false);
							SetNextMessage();
							break;

						case 9:
							currentDirectory.text = "/Hall/Jewels : ";
							inputField.text = "Please enter here.";
							inputField.interactable = true;
							Play();
							break;

						case 21:
							imageDirectory.SetActive(false);
							currentDirectory.text = "/Hall : ";
							inputField.text = "Please enter here.";
							inputField.interactable = true;
							Play();
							break;

						case 23:
							SetNextMessageOnPlay();
							break;

						case 10:
						case 22:
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
			currentDirectory.text = "";
			inputField.text = "";
			inputField.interactable = false;
			displayInputText.text = "";
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
					currentDirectory.text = "/Hall :";
					judgeText.text = "";

					SetNextMessageOnPlay();

					panelWalls.transform.localPosition = new Vector3(-2000.0f, 0.0f, 0.0f);
				}

				else
				{
					judgeText.text = "無効なコマンドです。";
					judgeText.color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
				}
				break;

			case 22:
				if (textValue == "cd OldBooks")
				{
					currentDirectory.text = "/Hall/OldBooks :";
					judgeText.text = "";

					SetNextMessageOnPlay();

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
