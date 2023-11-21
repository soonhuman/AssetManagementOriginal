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
                "さっき君が入力した /Hall/OldBooks や /Hall/Jewels について説明しよう。",
                "/Hall/OldBooksのような物は 絶対パス という。",
                "絶対パスとは、ファイル( History1.txt など)や\nディレクトリ(これまで 区画 と呼んでいたもの)の場所を一番上の階層から示す方法のことだ。",
                "この家だと、Hallからここまでの階層を示してることになる。",
                "また、それに対して 相対パス というのもあるんだ。",
                "相対パスは、君が今いるディレクトリを基準にして\nファイルやディレクトリの場所を示す方法のことだ。",
				"今まで君が cd 区画名 とコマンドを使って区画を移動していた時は相対パスを使っていたんだ。",
				"相対パスは特に今いるディレクトリ内にあるファイルやディレクトリへのアクセスを行うときに便利だ。",
				"折角だし相対パスにもう少し慣れようか。\n君はここから相対パスを使って OldBooks に移動してくれ。",
				"ミッション:相対パスを用いて区画 OldBooks に移動しろ！開始",
				"まずは区画 Hall に移動しましょう。区画を移動するコマンドは cd 区画名 です。\nコンソールに cd .. を入力して実行しましょう。",
				"そういえば、cd .. について言い忘れていたな。cd .. は上位ディレクトリに移動するんだ。",
				"もう少しわかりやすく言おう。上位ディレクトリは今いるディレクトリから1つ上の階層に位置するディレクトリの事を指す。",
				"このマップで考えるとわかりやすいと思う。\nこのマップで考えると区画 OldBooks や Jewels にとって、区画 Hall は上位ディレクトリになるんだ。",
				"そして、今いるディレクトリから一つ上のディレクトリ親ディレクトリに移動するには cd .. を使う。"
			},

        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
