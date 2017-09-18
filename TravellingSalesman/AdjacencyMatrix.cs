using System;
using System.Collections.Generic;
using System.Text;

namespace TravellingSalesman
{
	// Public
	public partial class AdjacencyMatrix
	{
		/// <summary>
		/// Will Set index of Location in list by it's list index.
		/// </summary>
		/// <param name="LocationList"></param>
		public AdjacencyMatrix( ref List<Location> LocationList )
		{
			int nCityNum = LocationList.Count;
			CreateAdjacencyMatrix( ref LocationList );
		}
		public double Distance( Location A, Location B )
		{
			return m_AdjecencyMatrix[ A.Index, B.Index ];
		}
	}

	// Protected
	public partial class AdjacencyMatrix
	{
	}

	// Private
	public partial class AdjacencyMatrix
	{
		double[ , ] m_AdjecencyMatrix;

		void CreateAdjacencyMatrix( ref List<Location> LocationList )
		{
			int nCityNum = LocationList.Count;

			// Using Adjecent Matrix, Matrix[ i ][ j ] means the distance of i -> j
			double[ , ] AdjMatrix = new double[ nCityNum, nCityNum ];

			//prepare the first location
			var current = LocationList[ 0 ];

			for( int i = 0; i < nCityNum; i++ ) {

				LocationList[ i ].Index = i;

				// Iterate through all cities
				for( int j = i + 1; j < nCityNum; j++ ) {
					// Calculate distance
					Point Vector = (Point)LocationList[ i ] - (Point)LocationList[ j ];
					AdjMatrix[ i, j ] = Vector.Distance();

					// Because our path is undirected distance(i,j) == distance(j,i), only need to calculate once
					AdjMatrix[ j, i ] = AdjMatrix[ i, j ];
				}
				// Because you can't move from A to A itself. make all diagonal value to infinite
				AdjMatrix[ i, i ] = double.PositiveInfinity;
			}

			m_AdjecencyMatrix = AdjMatrix;
		}
	}
}
