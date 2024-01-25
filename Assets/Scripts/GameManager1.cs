using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{

    public GameObject talkDisplay;
    public Text talkText;
    public GameObject lSDisplay;
    public GameObject toJewels;
    public GameObject toOldBooks;

	public Text currentDirectory;
	public InputField inputField;
    public Text displayInputText;
    public Text judgeText;
    public Text cPUMessage;

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
        toJewels.SetActive(false);
        toOldBooks.SetActive(false);

        var scenario01 = new Scenario()
        {
            ScenarioID = "scenario01",
            Texts = new List<string>()
            {
				"突然呼んで悪いが、君には私の家の資産整理を頼みたい。",
				"私の家には古文書がたくさんあってね、\nそろそろ整理したいと思っていてるんだ。",
				"そこで、古文書専用の部屋を作り、そこで管理して欲しい。\n部屋の名前も古い書物があることが伝わるようにしたい。",
				"そうだなぁ、部屋の名前は OldBooks で頼む。",
				"ミッション：部屋 OldBooks を作成せよ！開始",
				"あなたは新しく部屋 OldBooks の作成を命令されました。\nコマンドを使用して命令を実行しましょう。",
				"部屋の明かりをつけて中を確認するコマンドは ls です。\nコンソールに ls と入力して実行 (Enterを押す) しましょう。",
				"明かりがつきました！次は新しい部屋 OldBooks を作成しましょう。",
				"部屋を作成するコマンドは mkdir 部屋名 です。\nコンソールに mkdir OldBooks と入力して実行しましょう。",
				"新しい部屋 OldBooks が正しくできているか明かりをつけて確認します。",
				"部屋の明かりをつけて中を確認するコマンドは ls です。\nコンソールに ls と入力して実行 (Enterを押す) しましょう。",
				"部屋 OldBooks が出来ているのが確認できました！"
			},
            
        };

        inputField = GameObject.Find("InputField").GetComponent<InputField>();
		inputField.interactable = false;
		SetScenario(scenario01);
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
                            SetNextMessage();
                            break;

                        case 4:
                            Play();
                            break;

                        case 5:
							currentDirectory.text = "/Hall :";
							inputField.interactable = true;
							inputField.text = "Please enter here.";
							SetNextMessageOnPlay();
							break;

						case 7:
						case 9:
							inputField.text = "Please enter here.";
							SetNextMessageOnPlay();
							break;

						
                        case 11:
                            SetNextMessageOnPlay();
                            break;

                        case 6:
                        case 8:
                        case 10:
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

    void LSDisplayOn()
    {
        lSDisplay.SetActive(true);
        toJewels.SetActive(false);
        toOldBooks.SetActive(false);
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
            case 6:
            case 10:
                if (textValue == "ls")
                {
					
                    judgeText.text = "";

					SetNextMessageOnPlay();

                    lSDisplay.SetActive(false);
                    
                    if(index == 7)
                    {
                        toJewels.SetActive(true);
                    }

                    else if(index == 11)
                    {
                        toJewels.SetActive(true);
                        toOldBooks.SetActive(true);
						inputField.interactable = true;
					}

                }

                else
                {
                    judgeText.text = "無効なコマンドです。";
					judgeText.color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
				}
                break;

            case 8:
                if (textValue == "mkdir OldBooks")
                {
                    judgeText.text = "";

					SetNextMessageOnPlay();

                    LSDisplayOn();
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
