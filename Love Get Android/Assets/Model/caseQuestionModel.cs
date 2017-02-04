using UnityEngine;
using System.Collections.Generic;
using LitJson;

public class AnswerList
{
	public string answerDialog { get; set; }
	public int expression { get; set; }
	public int effect { get; set; }
	public int point { get; set; }
	public string explanation { get; set; }
}

public class MainQuestion
{
	public int id { get; set; }
	public string question { get; set; }
	public int is_over { get; set; }
	public int continue_id { get; set; }
	public AnswerList[] answerList { get; set; }
}

public class Question
{
	public MainQuestion[] mainQuestion { get; set; }
}

public class caseQuestion
{
	public Question question { get; set; }
}


public class caseQuestionModel : GameElement{


}