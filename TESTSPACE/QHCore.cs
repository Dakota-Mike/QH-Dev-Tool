using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
	{	List<QHCore> QHListCore = new List<QHCore>();
		List<QHFeat> QHListFeat;
		List<QHSchool> QHListSchool;
		List<QHSkill> QHListSkill;

		public void Input ()
		{	int state = 0; //simple flag, 0 for core, 1 for Skill, 2 for Feats, and 3 for Schools
			string testLine = "DO NOT RUN, JUST HERE FOR ERROR CHECKER";
			//openfile here
			//Begin Loop
			//Check for EOF
				//Return void
			//Else look for sorting header
				//If found Change header type, go back to looking for header.
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

		public static void Output ()
		{
		}
	}
}