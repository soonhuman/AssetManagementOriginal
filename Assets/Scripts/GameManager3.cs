using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager3 : MonoBehaviour
{

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
                "さっき君が入力した /Hall/Oldbooks や /Hall/Jewels について説明しよう。",
                "/Hall/Oldbooksのような物は 絶対パス という。",
                "絶対パスとは、ファイル( History1.txt など)や\nディレクトリ(これまで 区画 と呼んでいたもの)の場所を一番上の階層から示す方法のことだ。",
                "この家だと、Hallからここまでの階層を示してることになる。",
                "また、それに対して 相対パス というのもあるんだ。",
                "相対パスは、君が今いるディレクトリを基準にして\nファイルやディレクトリの場所を示す方法のことだ。",
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
