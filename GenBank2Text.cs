// GenBank2Text.cs
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

namespace GenBank2Text {
  public class ClsGenBank2Text : IGenBank2Text {	
	
		string filename;
		string saveDirectory;
		StreamReader sr;
		StreamWriter sw;
		StreamWriter swOutList;
		
		public void Load(string file)
  	    {
			this.filename = Path.GetFullPath(file);
			sr = File.OpenText(this.filename);
			saveDirectory = Path.GetDirectoryName(this.filename);	
	    }
		
		public void GenBank2Text()
		{
			string line = "";
			short index = 0;		
			string[] tokensGenBankFlatFile = {"LOCUS","//"};
			char[] token = {' '};
			string ContigName = "";
			string BlockGenBankStart = "";
			string BlockGenBankEnd = "";
			string newTextFile = "";

			Console.WriteLine("Creating a empty output list....");
			swOutList = File.CreateText(saveDirectory + "/GenBank2Text.out.list"); 
			
			Console.WriteLine("Parsing....");
			
			do 
		         {
		          try {		
			       line = sr.ReadLine();
			       index = (short)line.IndexOf(tokensGenBankFlatFile[0]);
			        if(index!=-1) { //found LOCUS?
			
				 BlockGenBankStart = line;				 	
				 line = line.Substring(5,(line.Length-5));
				 line = line.Trim();
				 index = (short)line.IndexOf(token[0]);
				 ContigName = line.Substring(0,index);
				 swOutList.WriteLine(ContigName);
				 Console.WriteLine(ContigName + " appended to out list....");	 
				 //start to generate a new Text Gen Bank Flat File
				 newTextFile = saveDirectory + "/" + ContigName + ".txt";  		
				 sw = File.CreateText(newTextFile);					  	
				 sw.WriteLine(BlockGenBankStart);	
				 Console.WriteLine("Extracting data block with identifier: {0} on file:{1}",ContigName,newTextFile);
				 continue;				
			        }
			
				    index = (short)line.IndexOf(tokensGenBankFlatFile[1]);
				    if(index!=-1) { //found end block
				      BlockGenBankEnd = line;
				      sw.WriteLine(BlockGenBankEnd);				      	
				      sw.Close();
				      continue;	
			        }				
				
			       if(line != "" && line != " " && line != string.Empty)
				 sw.WriteLine(line);
		     }//end_try
		     catch(Exception e) {
				;
		     }//end_try_catch
		    }//end_while				
	         while(line!=null);
		     swOutList.Close();
		     sr.Close();			
		}
  }
}
