// Main.cs
// 
// Copyright (C) 2008 Jacob, jacobnix@gmail.com
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
//

using System;
using System.IO;
using GenBank2Html;
using GenBank2Text;
using GenBank2Pdf;
	
public class MainClass
{
	static string genBankFile = "";
	static string mode = "";
	static bool flagFile = false;
	static bool flagMode = false;
	
	public static void Main(string[] args)
	{
		if(args.Length!=0) {
		 try {	
			for(int i=0;i<args.Length;i++)
			{
				if(args[i].StartsWith("--")) {
					switch(args[i]) {
					  case "--file":
						             if(File.Exists(args[i+1])) {
							           genBankFile = args[i+1];
							           flagFile = true; 
						             }
						             else
							           throw new Exception("File " + args[i+1] + " does not exist!!!,"); 
						             break;
					  case "--mode":
						             if(args[i+1] != string.Empty && args[i+1] != null) {							            
							            mode = args[i+1];						              
						                if(mode != "html" && 
								           mode != "HTML" &&
								           mode != "text" &&
								           mode != "TEXT" &&
								           mode != "pdf" &&
								           mode != "PDF") 
						                  throw new Exception("Mode " + args[i+1] + " not recognized ");
							            else
								          flagMode = true; 
						             } 
						             else
							             throw new Exception("Mode " + args[i+1] + " not recognized ");
						             break;							
					  case "--help":		
							         if(args.Length == 1 && i==0)
								        ShowHelp();							           
						             break;
					}//end_switch				
				}//end_if
			}//end_for
		}//end_try
		catch(Exception e) {
		Console.WriteLine("Error: " + e.Message + "try again!!!");
		return;		
		}
				
			if(flagFile) 
				switch(mode.ToLower()) {
				  case "html":
					          ClsGenBank2Html objGbHtml = new ClsGenBank2Html();
			                  objGbHtml.Load(genBankFile);
			                  objGbHtml.GenBank2Html();
					          break;
				  case "text":
				              ClsGenBank2Text objGbText = new ClsGenBank2Text();
				              objGbText.Load(genBankFile);
				              objGbText.GenBank2Text();
				              break;
				  case "pdf":
				             ClsGenBank2Pdf objGbPdf = new ClsGenBank2Pdf();
				             objGbPdf.Load(genBankFile);
				             objGbPdf.GenBank2Pdf();
				             break; 
				  default:
				             Console.WriteLine("Error: Missing Mode, please set the mode operation value!!!!");
				             break;
				}//end_switch			
		}
		else 
			ShowHelp();		
	}
	
	static void ShowHelp()
	{
		Console.WriteLine("GenBank Flat File to Html,Text and PDF Converter version 0.2");
		Console.WriteLine("Copyright (C) 2008-2009 Jacob Cervantes. http://frenesssi.wordpress.com");
		Console.WriteLine("Usage: mono GenBank2Any.exe --file filename --mode [html|text|pdf]");
	}
}

