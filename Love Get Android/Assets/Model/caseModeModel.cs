using UnityEngine;
using System.Collections.Generic;
using LitJson;



public class MainCase
{
	public int id { get; set; }
	public string dialog { get; set; }
	public int expression { get; set; }
	public int is_flipped { get; set; }
	public int is_main { get; set; }
	public int is_over { get; set; }
	public int continue_id { get; set; }
	public int question_id { get; set; }
}

public class Dialog
{
	public MainCase[] mainCase { get; set; }
}

public class caseMode
{
	public Dialog dialog { get; set; }
}

public class caseModeModel : GameElement {

}
