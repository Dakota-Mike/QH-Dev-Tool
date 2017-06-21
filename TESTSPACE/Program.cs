using System;
using QH;

namespace TESTSPACE
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			QHSchool p1 = new QHSchool('#', "bicep", "working", "19XX!?" , "School");
			Console.WriteLine (p1.save());
		}
	}
}
