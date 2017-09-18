using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TravellingSalesman
{
	public class TSPDataReader
	{
		public TSPDataReader()
		{
		}

		public List<Location> Read( string szPath )
		{
			StreamReader sr = new StreamReader( szPath );
			string szVal = string.Empty;
			// Get Size from DIMENSION

			szVal = ReadToLine( sr, out szVal, "DIMENSION" );

			// Get DIMENSION: #, where number "#" index is 11
			int nCapacity = Convert.ToInt32( szVal.Substring( 11 ) );
			List<Location> List = new List<Location>(nCapacity*2 );

			// Get to NODE_COORD_SECTION
			ReadToLine( sr, out szVal, "NODE_COORD_SECTION" );

			int nDataIndex = 0;
			while( sr.Peek() != 0 ){

				if( nDataIndex == nCapacity ) {
					break;
				}
				string szTmp =sr.ReadLine();
				Location Loc = StrToLoc( szTmp, nDataIndex );
				List.Add( Loc );
				nDataIndex++;
			}
			return List;
		}

		string ReadToLine( StreamReader sr, out string szVal, string szExistString )
		{
			do {
				szVal = sr.ReadLine();
			} while( szVal.IndexOf( szExistString ) == -1 );
			return szVal;
		}
		Location StrToLoc( string szVal, int nLocationIndex )
		{
			// Split data with space, 
			string[] szData = szVal.Split( ' ' );
			Location Loc = new Location();

			// Set data to location Eg: 5 11183.333300 42933.333300, 1st is name, 2nd is X, 3rd is Y
			Loc.Name = szData[ 0 ];
			Loc.X = Convert.ToDouble( szData[ 1 ] );
			Loc.Y = Convert.ToDouble( szData[ 2 ] );
			return Loc;
		}
	}
}
