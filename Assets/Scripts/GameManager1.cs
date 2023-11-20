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
                "そこで、古文書専用の区画を作り、そこで管理して欲しい。\n区画の名前も古い書物があることが伝わるようにしたい。",
                "そうだなぁ、区画の名前は OldBooks で頼む。",
                "ミッション：区画 OldBooks を作成せよ！開始",
                "あなたは新しく区画 OldBooks の作成を命令されました。\nコマンドを使用して命令を実行しましょう。",
                "区画の明かりをつけて中を確認するコマンドは ls です。\nコンソールに ls と入力して実行 (Enterを押す) しましょう。",
                "明かりがつきました！次は新しい区画 OldBooks を作成しましょう。",
                "区画を作成するコマンドは mkdir 区画名 です。\nコンソールに mkdir OldBooks と入力して実行しましょう。",
                "新しい区画 OldBooks が正しくできているか明かりをつけて確認します。",
                "区画の明かりをつけて中を確認するコマンドは ls です。\nコンソールに ls と入力して実行 (Enterを押す) しましょう。",
                "区画 OldBooks が出来ているのが確認できました！"
            },
            
        };

        inputField = GameObject.Find("InputField").GetComponent<InputField>();
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
                        case 7:
                        case 9:
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
                    index++;
                    cPUMessage.text = currentScenario.Texts[index];
                    lSDisplay.SetActive(false);
                    
                    if(index == 7)
                    {
                        toJewels.SetActive(true);
                    }

                    else if(index == 11)
                    {
                        toJewels.SetActive(true);
                        toOldBooks.SetActive(true);
                    }

                }

                else
                {
                    judgeText.text = "無効なコマンドです。";
                }
                break;

            case 8:
                if (textValue == "mkdir OldBooks")
                {
                    judgeText.text = "";
                    index++;
                    cPUMessage.text = currentScenario.Texts[index];
                    LSDisplayOn();
                }

                else
                {
                    judgeText.text = "無効なコマンドです。";
                }
                break;
        }

    }
}
