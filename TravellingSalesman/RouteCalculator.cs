using System;
using System.Collections.Generic;
using System.Text;

namespace TravellingSalesman
{
	public class RouteCalculator
	{
		AdjacencyMatrix m_AdjMatrix;

		public RouteCalculator( AdjacencyMatrix AdjMatrix )
		{
			m_AdjMatrix = AdjMatrix;
		}
		/// <summary>
		/// Calculate if swapped result will shorter than original route
		/// </summary>
		/// <param name="Route"></param>
		/// <param name="nSwapStart"></param>
		/// <param name="nSwapEnd"></param>
		/// <returns></returns>
		public double CalcLength( List<Location> Route )
		{
			double TotalLength = 0.0;

			// Calc distance, do not need to get to last one, or may encounter out of range exception
			for( int i = 0; i < Route.Count - 1; i++ ) {
				TotalLength += m_AdjMatrix.Distance( Route[ i ], Route[ i + 1 ] );
			}

			return TotalLength;
			// ==== old code ====
			// Try triangle compare
			//// Swap distance compare
			//// - A   B -             - A - D -
			////     X         ==>     
			//// - C   D -             - C - B -
			//// Swap difference:
			//// From Start-1 -> Start and End-> End+1
			//// To 
			//Location Start = Route[ nSwapStart ];
			//Location End = Route[ nSwapEnd ];

			//// Original length
			//double StartEdgeDistance = 0;

			//// Only 
			//if( nSwapStart > 1 ) {
			//}
			
		}
	}
	public class TwoOptNonLoopCompareStrategy
	{
		AdjacencyMatrix m_AdjMatrix;

		public TwoOptNonLoopCompareStrategy( AdjacencyMatrix AdjMatrix )
		{
			m_AdjMatrix = AdjMatrix;
		}
	}
}
