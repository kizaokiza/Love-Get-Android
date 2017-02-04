using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainAnswer
{
	public int id { get; set; }
	public int is_right { get; set; }
	public string answer0 { get; set; }
	public int expression0 { get; set; }
	public int effect0 { get; set; }
	public int point0 { get; set; }
	public string explanation0 { get; set; }
	public string answer1 { get; set; }
	public int expression1 { get; set; }
	public int effect1 { get; set; }
	public int point1 { get; set; }
	public string explanation1 { get; set; }
	public string answer2 { get; set; }
	public int expression2 { get; set; }
	public int effect2 { get; set; }
	public int point2 { get; set; }
	public string explanation2 { get; set; }
	public string answer3 { get; set; }
	public int effect3 { get; set; }
	public int point3 { get; set; }
	public string explanation3 { get; set; }
	public int? expression3 { get; set; }
}

public class Answer
{
	public IList<MainAnswer> mainAnswer { get; set; }
}

public class caseAnswer
{
	public Answer answer { get; set; }
}

public class caseAnswerModel : GameElement {


}
