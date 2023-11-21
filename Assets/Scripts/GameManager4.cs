using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager4 : MonoBehaviour
{

    public GameObject talkDisplay;
    public Text talkText;
    public GameObject lSDisplay;

    public InputField inputField;
    public Text displayInputText;
    public Text judgeText;
    public Text cPUMessage;

    public GameObject imageEditor;
    public InputField inputField1;
    public InputField inputField2;
    public InputField inputFieldUnder;
    //public Text underText;

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


        var scenario04 = new Scenario()
        {
            ScenarioID = "scenario04",
            Texts = new List<string>()
            {
                "そういえば、君には作業場を教えてなかったな。",
                "この機会に作業場で Oldbooks にある本の一覧を記録して貰うか。\n 一覧の名前は Contents.txt で頼む。",
                "ミッション：区画 Oldbooks の中にある本の名前を記録しろ！開始",
                "まずは Contents.txt を生成します。",
                "新しいテキストファイルを作るには vi ファイル名 です。\nコンソールに vi Contents.txt を入力して実行しましょう。",
                "編集画面に移動できました！続いては編集モードをオンにします。\n編集モードをオンにするには a もしくは i を押します。",
                "編集モードをオンに出来ました。\nCollection List と書いてみてください。",
                "次は区画 Oldbooks にある古文書を書き記します。\n古文書の名前は Hisoty1.txt と Hisoty2.txt です。",
                "古文書一覧を書くことが出来たので編集画面を終了します。\nまず、編集モードを終了するためにはescキーを押します。",
                ":wqを押してEnterキーを押してください。",
                "最後に明かりをつけて区画の中にある物を確認します。\nコンソールにコマンドを入力して実行しましょう。",
                "Contents.txt を生成することができました！"
            },

        };

        inputField = GameObject.Find("InputField").GetComponent<InputField>();
        

        SetScenario(scenario04);
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
                            SetNextMessage();
                            break;

                        case 2:
                            Play();
                            break;

                        case 3:
                        
                        case 11:
                            SetNextMessageOnPlay();
                            break;

                        case 4:
                        case 10:
                            break;

                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                            break;
                    }

                }

            }

           
            else if (Input.GetKey(KeyCode.A) && index == 5 || Input.GetKey(KeyCode.I) && index == 5 )
            {
                pushFlag = true;
                SetNextMessageOnPlay();
                inputFieldUnder.text = "--INSERT--";
            }

            else if (Input.GetKey(KeyCode.Escape) && index == 8)
            {
                pushFlag = true;
                SetNextMessageOnPlay();
                inputFieldUnder.text = "";
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
            case 4:
                if (textValue == "vi Contents.txt")
                {
                    judgeText.text = "";
                    index++;
                    cPUMessage.text = currentScenario.Texts[index];

                    imageEditor.SetActive(true);
                    inputField1 = GameObject.Find("InputField1").GetComponent<InputField>();
                    inputField2 = GameObject.Find("InputField2").GetComponent<InputField>();
                    inputFieldUnder = GameObject.Find("InputFieldUnder").GetComponent<InputField>();
                }

                else
                {
                    judgeText.text = "無効なコマンドです。";
                }
                break;

            case 10:
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
                }
                break;
        }

    }

    public void DisplayEditor()
    {
        string textValue1 = inputField1.text;
        string textValue2 = inputField2.text;

        pushFlag = true;

        switch (index)
        {
            case 6:
                if (textValue1 == "Collection List")
                {
                    index++;
                    cPUMessage.text = currentScenario.Texts[index];
                }

                else
                {
                    
                }
                break;

            case 7:
                if (textValue2 == "History1.txt, History2.txt")
                {
                    index++;
                    cPUMessage.text = currentScenario.Texts[index];
                }

                else
                {
                    
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