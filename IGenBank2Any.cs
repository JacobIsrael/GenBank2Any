// IGenBank2Any.cs
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
	
	public interface IGenBank2Html
	{
	   void GenBank2Html();
	   void Load(string file);
	}

	public interface IGenBank2Text
	{
	   void GenBank2Text();
	   void Load(string file);
	}

    public interface IGenBank2Pdf
    {
	   void GenBank2Pdf();
	   void Load(string file);
    }

    public interface IGenBan2Xml
	{

	} 

