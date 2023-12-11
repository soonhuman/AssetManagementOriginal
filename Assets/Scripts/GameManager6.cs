using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameManager6 : MonoBehaviour
{
	public GameObject talkDisplay;
	public Text talkText;

	public GameObject imageAuthority;
	public GameObject cover4;
	public GameObject cover2;
	public GameObject cover1;

	public GameObject image660;
	public GameObject coverOwner;
	public GameObject coverOwnershipGroup;
	public GameObject coverOthers;
	public GameObject cover660;

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
		var scenario06 = new Scenario()
		{
			ScenarioID = "scenario06",
			Texts = new List<string>()
			{
				"君がさっきまで使っていたchmodについて少し説明しよう。\nだがその前に、ファイルの権限について話をする必要がある。",
				"ファイルの権限とは、そのファイルやディレクトリを扱うユーザー毎に\n与えられる権限のことだ。",
				"ファイルの権限には、読み取り権限 (read) 、書き込み権限 (write)、\n実行権限 (exec) の3つがある。",
				"それぞれの権限は、ユーザー毎に許可するかどうかを決めることが出来る。\nこの権限を操作できるのがchmodコマンドだ。",
				"chmodは、\nchmod 権限設定 (ファイル名やディレクトリ名)\nで使うのは以前に学んだと思う。",
				"この権限設定をする際には、与える権限に対応した数字を用いる必要がある。",
				"権限設定に用いる数字には4、2、1の3種類がある。\n4が読み取りの許可、2が書き込みの許可、1が実行の許可を意味する。",
				"また、この数字は足して用いることが出来る。\n例えば、6の場合は 6 = 4 + 2 で、\n読み取りと書き込みの2種類の権限を許可していることになる。",
				"だが、おそらくここまで聞いたことと先ほどやったことを併せて考えると、\nある疑問が出てくると思う。",
				"それは、chmodで権限設定をする際に3桁の数字を使っていたにも関わらず、\nここでは1桁しか取り扱っていないので、\n3桁の時はどうすればよいか、ということだ。",
				"だが、実はこれは3桁の数字というわけではなく、\n3つのグループに異なる1桁の数字を与えているのだ。",
				"権限を与えている順番は所有者、所有グループ、その他である。",
				"先ほどのContents.txtを例に当てはめて考えるとわかる。\n先ほどのコマンドは、chmod 660 Contents.txt だった。",
				"これを先ほど言ったことに当てはめると\n6　　　　　6　　　　　0　　　　　\nと分けることが出来る。",
				"そして、先ほどの数字と当てはめて考えてみると、\n6 = 4 + 2 で、読み取りと書き込みの許可を\n0はいかなる許可も与えてないということになる。",
				"これを先ほどの権限を与える順番と照らし合わせると、\nContents.txt所有者の君や所有グループの私達には読み取りや書き込みの許可を",
				"部外者には何も権限を与えていない、ということになる。",
				"これでchmodの権限変更について少し理解できただろうか。\nもしまたわからなくなったらいつでも聞いてくれ。\nそれでは、今日の作業はここまでにしようか。"
			},

		};

		SetScenario(scenario06);
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
						case 9:
						case 10:
						case 11:
						case 12:
						case 13:
						case 14:
						case 15:
						case 16:
						case 17:
							SetNextMessage();
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

	void SetScenario(Scenario scenario)
	{
		currentScenario = scenario;
		talkText.text = currentScenario.Texts[0];
	}

	void SetNextMessage()
	{
		if (currentScenario.Texts.Count > index + 1)
		{
			index++;
			UIManagement();
			talkText.text = currentScenario.Texts[index];
		}
		else
		{
			SceneManager.LoadScene("ClearScene");
		}
	}

	void UIManagement()
    {
		switch (index)
        {
			case 2:
				imageAuthority.SetActive(true);
				break;

			case 6:
				cover4.SetActive(false);
				cover2.SetActive(false);
				cover1.SetActive(false);
				break;

			case 10:
				image660.SetActive(true);
				break;

			case 11:
				coverOwner.SetActive(false);
				coverOwnershipGroup.SetActive(false);
				coverOthers.SetActive(false);
				break;

			case 13:
				cover660.SetActive(false);
				break;

			default:
				break;
		}
    }
}
