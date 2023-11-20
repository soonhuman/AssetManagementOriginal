using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager2 : MonoBehaviour
{
    public GameObject panelWalls;

    public GameObject talkDisplay;
    public Text talkText;
    public GameObject lSDisplay;
    public GameObject toJewels;
    public GameObject toOldBooks;

    public InputField inputField;
    public Text displayInputText;
    public Text judgeText;
    public Text cPUMessage;

    public GameObject imageRuby;
    public GameObject imageSapphire;
    public GameObject imageBook1;
    public GameObject imageBook2;

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

        imageRuby.SetActive(false);
        imageSapphire.SetActive(false);
        imageBook1.SetActive(false);
        imageBook2.SetActive(false);

        var scenario02 = new Scenario()
        {
            ScenarioID = "scenario01",
            Texts = new List<string>()
            {
                "私は片付けがかなり苦手な故に、古文書と宝石を一括で Jewels に管理してしまっていてね。",
                "そこで君には Jewels という区画に行ってもらって、\nそこから古文書を先ほど作ったOldbooksに移動して欲しい。",
                "古文書は名前に .txt とついているからそれで判別してくれ。\nよろしく頼む。",
                "ミッション : 区画 Jewels に移動し、\nそこにある古文書を区画 Oldbooks に移動せよ！開始",
                "まずはコマンドを使用して区画 Jewels に移動します。",
                "区画を移動するコマンドは cd 区画名 です。\nコンソールに cd Jewels を入力して実行しましょう。",
                "区画 Jewels に移動しました！次は明かりをつけて中身を確認します。\nコンソールにコマンドを入力して実行しましょう。",
                "明かりがつきました！次は History1.txt を区画 Oldbooks に移動します。",
                "区画にある物を他の場所に移動するコマンドは mv 移動したい物の名前 移動先の区画の場所 です。\nコンソールに  mv Hisoty1.txt /Hall/Oldbooks を入力して実行しましょう。",
                "History1.txt が移動できたかを明かりをつけて確認します。\nコンソールにコマンドを入力して実行しましょう。",
                "History1.txtが移動できたのが確認できました！",
                "次は Hisoty2.txt を区画 OldBooks に移動します。\nコンソールにコマンドを入力して実行しましょう。",
                "History2.txt が移動できたかを明かりをつけて確認します。\nコンソールにコマンドを入力して実行しましょう。",
                "古文書 History1.txt と History2.txt を移動できました！"
            },

        };

        inputField = GameObject.Find("InputField").GetComponent<InputField>();
        SetScenario(scenario02);
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
                            SetNextMessage();
                            break;

                        case 3:
                            Play();
                            break;

                        case 4:
                        case 7:
                        case 10:
                        case 13:
                            SetNextMessageOnPlay();
                            break;

                        case 5:
                        case 6:
                        case 8:
                        case 9:
                        case 11:
                        case 12:
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

        imageRuby.SetActive(false);
        imageSapphire.SetActive(false);
        imageBook1.SetActive(false);
        imageBook2.SetActive(false);
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
            case 5:
                if (textValue == "cd Jewels")
                {
                    judgeText.text = "";
                    panelWalls.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                    index++;
                    cPUMessage.text = currentScenario.Texts[index];
                    
                }

                else
                {
                    judgeText.text = "無効なコマンドです。";
                }
                break;

            case 6:
            case 9:
            case 12:
                if (textValue == "ls")
                {
                    judgeText.text = "";
                    index++;
                    cPUMessage.text = currentScenario.Texts[index];
                    lSDisplay.SetActive(false);

                    if (index == 7)
                    {
                        imageRuby.SetActive(true);
                        imageSapphire.SetActive(true);
                        imageBook1.SetActive(true);
                        imageBook2.SetActive(true);
                    }

                    else if (index == 10)
                    {
                        imageRuby.SetActive(true);
                        imageSapphire.SetActive(true);
                        imageBook2.SetActive(true);
                    }

                    else if (index == 13)
                    {
                        imageRuby.SetActive(true);
                        imageSapphire.SetActive(true);
                    }
                }

                else
                {
                    judgeText.text = "無効なコマンドです。";
                }
                break;

            case 8:
                if (textValue == "mv History1.txt /Hall/OldBooks")
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

            case 11:
                if (textValue == "mv History2.txt /Hall/OldBooks")
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