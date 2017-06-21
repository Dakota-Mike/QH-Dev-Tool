using System;
using System.Text.RegularExpressions;

namespace QH
{
	public class QHCore
	{
		public Guid qhID;
		public char coreFlag;
		public string name;
	
		public string save()
		{
			string saver = "|" + qhID + "|" + coreFlag + "|" + name;
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

		public QHCore (char flag, string nameHold):this()
		{	coreFlag = flag;
			name = text(nameHold);
		}
	}

	public class QHSkill:QHCore
	{
		public string descrption;
		public char type;	

		public QHSkill ():base()
		{
		}

		public QHSkill (char flag, string nameHold, string descriptHold, char typeHold):base(flag, nameHold)
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

	public class QHFEAT:QHCore
	{
		public string description;
		public string bonus;
		public int bonusMod;

		public QHFEAT ():base()
		{
		}

		public QHFEAT (string descriptHold, string bonusHold, int modHold):base()
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
		public string description;
		public string year;
		public string location;

		public QHSchool (char flag, string name, string descriptHold, string yearHold, string locationHold) : base(flag, name)
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
	{
		public static void Input ()
		{
		}

		public static void Output ()
		{
		}
	}
}
	