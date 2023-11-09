using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Text scenarioMessage;
    public GameObject talkDisplay;

    public Text cPUMessage;
    public InputField inputField;
    public Text displayInputText;
    // public GameObject placeHolder;

    private string text;


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
        var scenario01 = new Scenario()
        {
            ScenarioID = "scenario01",
            Texts = new List<string>()
            {
                "突然呼んで悪いが、君には私の家の資産整理を頼みたい。",
                "私の家には古文書がたくさんあってね、そろそろ整理したいと思っていてるんだ。",
                "そこで、古文書専用のそこで管理して欲しい。区画の名前も古い書物があることが伝わるようにしたい。",
                "そうだなぁ、区画の名前は OldBooks で頼む。",
                "ミッション：区画 OldBooks を作成せよ！開始",
                "あなたは新しく区画 OldBooks の作成を命令されました。コマンドを使用して命令を実行しましょう。",
                "区画の明かりをつけて中を確認するコマンドは ls です。コンソールに ls と入力して実行 (Enterを押す) しましょう。",
                "明かりがつきました！次は新しい区画 OldBooks を作成しましょう。",
                "区画を作成するコマンドは mkdir 区画名 です。コンソールに mkdir OldBooks と入力して実行しましょう。",
                "新しい区画 Oldbooks が正しくできているか明かりをつけて確認します。",
                "区画の明かりをつけて中を確認するコマンドは ls です。コンソールに ls と入力して実行 (Enterを押す) しましょう。"

            },
            
        };

        inputField = GameObject.Find("InputField").GetComponent<InputField>();
        SetScenario(scenario01);
    }

    void SetScenario(Scenario scenario)
    {
        currentScenario = scenario;
        scenarioMessage.text = currentScenario.Texts[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (currentScenario != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(index < 4)
                {
                    SetNextMessage();
                }

                else if(index == 4)
                {
                    Play();
                }

                else
                {

                }

            }

            else if (Input.GetKey(KeyCode.Return))
            {
                switch (index)
                {
                    case 5:
                        SetNextMessageOnPlay();
                        break;

                    case 6:
                        break;
                }
            }

        }

    }

    void SetNextMessage()
    {
        if (currentScenario.Texts.Count > index + 1)
        {
            index++;
            scenarioMessage.text = currentScenario.Texts[index];
        }
        else
        {
            ExitScenario();
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
            ExitScenario();
        }
    }

    void ExitScenario()
    {
        scenarioMessage.text = "";
        index = 0;
        if (string.IsNullOrEmpty(currentScenario.NextScenarioID))
        {
            currentScenario = null;
        }
        else
        {
            var nextScenario = scenarios.Find
                (s => s.ScenarioID == currentScenario.NextScenarioID);
            currentScenario = nextScenario;
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
        Debug.Log(textValue);


        switch (index)
        {
            case 6:
                if (textValue == "ls")
                {
                    index++;
                    cPUMessage.text = currentScenario.Texts[index];
                }

                else
                {
                    cPUMessage.text = "無効なコマンドです。";
                }
                break;
        }

    }
}
