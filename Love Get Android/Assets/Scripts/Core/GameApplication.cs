using UnityEngine;
using System.Collections;
using LitJson;
using System.IO;

public class GameElement : MonoBehaviour
{
    //gameapp

    public GameApplication app { get { return GameObject.FindObjectOfType<GameApplication>(); } }
}


public class GameApplication : MonoBehaviour {

    public GameModel model;
	public caseModeModel caseModeModel;
	public caseAnswerModel caseAnswerModel;
	public caseQuestionModel caseQuestionModel;
    public GameView view;
    public GameController controller;

	private string caseJson;
	private string questionJson;

	public caseMode caseMode;
	public caseQuestion caseQuestion;

    // Use this for initialization
    void Start () {

		mapJsonToPoco ();

		controller.dialogLine (0);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void mapJsonToPoco(){
		caseJson = File.ReadAllText (Application.dataPath +  "/Model/caseMode.json");
		caseMode = JsonMapper.ToObject<caseMode>(caseJson);

		questionJson = File.ReadAllText (Application.dataPath +  "/Model/caseMode-Question.json");
		print (questionJson.ToString ());
		caseQuestion = JsonMapper.ToObject<caseQuestion>(questionJson);
	}

}
