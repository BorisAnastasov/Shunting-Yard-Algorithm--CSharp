using System;
using System.Collections.Generic;
using System.Linq;

public class ShuntingYardAlgorithm
{
	public ShuntingYardAlgorithm()
	{

		//readind data
		string input = Console.ReadLine();

		var data = input.Split().ToList<char>();

		var output = new Queue<char>();

		var stack = new Stack<char>();

		while(data.Length > 0)
		{
			if (char.IsDigit(data[0]))
			{
				output.Enqueue();
			} 
			else if()
			{ 
			 
			}
		}

	}
}
