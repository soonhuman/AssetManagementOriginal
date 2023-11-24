using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameManager5 : MonoBehaviour
{
	public GameObject panelWalls;

	public GameObject talkDisplay;
	public Text talkText;
	public GameObject lSDisplay;

	public InputField inputField;
	public Text displayInputText;
	public Text judgeText;
	public Text cPUMessage;

	public GameObject imageEditor;
	public InputField inputFieldUnder;

	public GameObject imageBook1;
	public GameObject imageBook2;
	public GameObject imageContents;

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
		lSDisplay.SetActive(true);
		imageEditor.SetActive(false);
		imageBook1.SetActive(false);
		imageBook2.SetActive(false);
		imageContents.SetActive(false);

		var scenario05 = new Scenario()
		{
			ScenarioID = "scenario05",
			Texts = new List<string>()
			{
				"最近、私の屋敷の中に入って古文書の情報を勝手に覗き見たり\n古文書そのものを盗もうとしたりする奴がいるんだ。",
				"屋敷の中には君のような使用人が24時間交代で常駐してはいるが、\nそれでも万が一という可能性は常にある。",
				"そこでだ、君のコマンドの力を使ってこの本に鍵をかけて欲しい。",
				"今まで言ってこなかったが、実はこの本はコマンドを唱えることによって\n鍵をかけることが出来る。",
				"君や私などの屋敷の人間には古文書そのものの閲覧権限と、\n古文書一覧の中身の編集や閲覧の許可を与えて欲しい。",
				"だが、 部外者には古文書やその一覧には何もできないようにしてほしい。\n権限の変更が終わったら最後には Hall に戻ってきてくれ。よろしく頼む。",
				"ミッション：区画 OldBooks の中の書類の権限を変更し、\n　　　　　　区画 Hall に移動せよ！開始",
				"まずは区画の中にある物を確認します。コンソールにコマンドを入力して実行しましょう。",
				"区画の中にあるものがわかりました。次は OldBooks の中にあるものの権限を変更します。",
				"権限を変更するコマンドは chmod モード 対象ファイル名 です。\nコンソールに chmod 440 History1.txt を入力して実行しましょう。",
				"先ほど同じように History2.txt の権限を変更します。コンソールにコマンドを入力して実行しましょう。",
				"最後にContents.txt の権限を変更します。コンソールに chmod 660 Contents.txt を入力して実行しましょう。",
				"権限が変更できたか確かめてみます。viを用いてHistory 1 を編集してみてください。",
				"History1.txt が編集できないことがわかりました。\n同じように History2.txt を編集してみてください。",
				"History2.txt も編集できないことがわかりました。\n最後に Contents.txt を編集してみてください。",
				"Contents.txt は編集できることがわかりました。\nですが今は編集の必要がないので編集画面を閉じてください。",
				"権限の変更が確認できました！最後に区画 Hall に移動します。\nコンソールにコマンドを入力して実行しましょう。",
				"区画 Hall に戻ることができました！"
			},

		};

		inputField = GameObject.Find("InputField").GetComponent<InputField>();

		SetScenario(scenario05);
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
							SetNextMessage();
							break;

						case 6:
							Play();
							break;

						case 8:
						case 17:
							SetNextMessageOnPlay();
							break;

						case 7:
						case 9:
						case 10:
						case 11:
						case 12:
						case 13:
						case 14:
						case 16:
							break;

						case 15:
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

	void LSDisplayOn()
	{
		lSDisplay.SetActive(true);
		imageBook1.SetActive(false);
		imageBook2.SetActive(false);
		imageContents.SetActive(false);
	}

	public void DisplayText()
	{
		string textValue = inputField.text;
		displayInputText.text = inputField.text;
		pushFlag = true;

		switch (index)
		{
			case 7:
				if (textValue == "ls")
				{
					judgeText.text = "";
					index++;
					cPUMessage.text = currentScenario.Texts[index];

					lSDisplay.SetActive(false);
					imageBook1.SetActive(true);
					imageBook2.SetActive(true);
					imageContents.SetActive(true);
				}

				else
				{
					judgeText.text = "無効なコマンドです。";
					judgeText.color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
				}
				break;

			case 9:
				if (textValue == "chmod 440 History1.txt")
				{
					judgeText.text = "";
					LSDisplayOn();
					SetNextMessageOnPlay();
				}

				else
				{
					judgeText.text = "無効なコマンドです。";
					judgeText.color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
				}
				break;

			case 10:
				if (textValue == "chmod 440 History2.txt")
				{
					judgeText.text = "";
					SetNextMessageOnPlay();
				}

				else
				{
					judgeText.text = "無効なコマンドです。";
					judgeText.color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
				}
				break;

			case 11:
				if (textValue == "chmod 660 Contents.txt")
                {
					judgeText.text = "";
					SetNextMessageOnPlay();
                }

				else
				{
					judgeText.text = "無効なコマンドです。";
					judgeText.color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
				}
				break;

			case 12:
				if (textValue == "vi History1.txt")
				{
					judgeText.text = "History1.txtへの書き込み権限が存在しません。";
					judgeText.color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
					index++;
					cPUMessage.text = currentScenario.Texts[index];
				}

				else
				{
					judgeText.text = "無効なコマンドです。";
					judgeText.color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
				}
				break;

			case 13:
				if(textValue == "vi History2.txt")
                {
					judgeText.text = "History2.txtへの書き込み権限が存在しません。";
					judgeText.color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
					index++;
					cPUMessage.text = currentScenario.Texts[index];
				}

                else
                {
					judgeText.text = "無効なコマンドです。";
					judgeText.color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
				}
				break;

			case 14:
				if (textValue == "vi Contents.txt")
				{
					judgeText.text = "";
					index++;
					cPUMessage.text = currentScenario.Texts[index];

					imageEditor.SetActive(true);
					inputFieldUnder = GameObject.Find("InputFieldUnder").GetComponent<InputField>();
				}

				else
				{
					judgeText.text = "無効なコマンドです。";
					judgeText.color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
				}
				break;

			case 16:
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

		}

	}

	public void EndEditor()
	{
		string textValueUnder = inputFieldUnder.text;

		if (textValueUnder == ":wq")
		{
			index++;
			cPUMessage.text = currentScenario.Texts[index];
			imageEditor.SetActive(false);
		}

		else
		{

		}
	}

}
