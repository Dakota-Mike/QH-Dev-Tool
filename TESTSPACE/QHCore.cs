using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

/*Planning Space*/


namespace QH
{
	public class QHCore
	{
		public Guid qhID;
		public string coreFlag, name;
	
		public string save()
		{
			string saver = qhID + "|" + coreFlag + "|" + name;
			return saver;
		}

		public string year (string year)
		{
			Regex yearRgx= new Regex("[^Xx0-9?]");
			return yearRgx.Replace(year, String.Empty);
		}

		public string text (string text)
		{
			return text.Replace('|','-');
		}

		public QHCore ()
		{
			qhID = Guid.NewGuid();
		}

		public QHCore (string flag, string nameHold):this()
		{	coreFlag = flag;
			name = text(nameHold);
		}
	}

	public class QHSkill:QHCore
	{
		public string descrption, type;	

		public QHSkill ():base()
		{
		}

		public QHSkill (string flag, string nameHold, string descriptHold, string typeHold):base(flag, nameHold)
		{
			descrption = descriptHold;
			type = typeHold;

		}


		public string save()
		{
			string saver = base.save() + "|" + descrption + "|" + type;
			return saver;
		}
	}

	public class QHFeat:QHCore
	{
		public string description, bonus, bonusMod;

		public QHFeat ():base()
		{
		}

		public QHFeat (string flag, string nameHold, string descriptHold, string bonusHold, string modHold) : base(flag, nameHold)
		{
			description = text(descriptHold);
			bonus = text(bonusHold);
			bonusMod = modHold;
		}

		public string save()
		{
			string saver = base.save() + "|" + description + "|" + bonus + "|" + bonusMod;
			return saver;
		}
	}

	public class QHSchool:QHCore
	{
		public string description, year, location;

		public QHSchool (string flag, string name, string descriptHold, string yearHold, string locationHold) : base(flag, name)
		{
			description = text(descriptHold);
			year = this.year(yearHold);
			location = text(locationHold);
		}

		public string save()
		{
			string saver = base.save() + "|" + description + "|" + year + "|" + location;
			return saver;
		}
	}

	public class QHManager
	{	//Should we make a manager each Module? That way we can turn on and off in the program?
	
		List<QHCore> QHListCore = new List<QHCore>();
		List<QHFeat> QHListFeat = new List<QHFeat>();
		List<QHSchool> QHListSchool = new List<QHSchool>();
		List<QHSkill> QHListSkill = new List<QHSkill>();

		public void Input ()
		{	string[] testLines = System.IO.File.ReadAllLines(@"C:\Users\Public\TestFolder\module.cfg");
			int state = 0; //simple flag, 0 for core, 1 for Skill, 2 for Feats, and 3 for Schools
			foreach (string testLine in testLines) 
			{
			//Else look for sorting header
			if (testLine.Contains("|||"))
			{	//break apart, set to caps, compare to dictionary. Hardcoding okay? M.
				string[] resultLine = Regex.Split(testLine, "|||");
				//If found Change header type, go back to looking for header.
				state = Convert.ToInt32(resultLine[0]);
					//Remember to create the term dictionary. For now we number, then we dictionary.
			}
			else
			{
			//If no header found, follow through with current type.
			string[] resultLine = testLine.Split('|');
			switch (state)
			{
				case 0:
					QHListCore.Add(new QHCore(resultLine[0],resultLine[1]));
				break;

				case 1:
					QHListSkill.Add(new QHSkill(resultLine[0],resultLine[1],resultLine[2],resultLine[3]));
				break;

				case 2:
					QHListFeat.Add(new QHFeat(resultLine[0],resultLine[1],resultLine[2],resultLine[3],resultLine[4]));
				break;

				case 3:
					QHListSchool.Add(new QHSchool(resultLine[0],resultLine[1],resultLine[2],resultLine[3],resultLine[4]));
				break;
				}
			}
			}
		}

		public void Output ()
		{	//Output function should only produce the core Module for the moment. Will modify upon phase 2.
			using (System.IO.StreamWriter file = 
				new System.IO.StreamWriter(@"C:\Users\Public\TestFolder\moduleCustom.cfg", true))
			{
				file.WriteLine("|||[0]|||[#]|||[CORE]|||");
				foreach (var result in QHListCore)
				{
				file.WriteLine(result.save());
				}
				file.WriteLine("|||[1]|||[#]|||[CORE]|||");
				foreach (var result in QHListSkill)
				{
				file.WriteLine(result.save());
				}
				file.WriteLine("|||[2]|||[#]|||[CORE]|||");
				foreach (var result in QHListFeat)
				{
					file.WriteLine(result.save());
				}
				file.WriteLine("|||[3]|||[#]|||[CORE]|||");
				foreach (var result in QHListSchool)
				{
					file.WriteLine(result.save());
				}
			}
		}
	}
}