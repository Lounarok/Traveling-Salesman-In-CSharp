using System;
using System.Collections.Generic;

namespace TravellingSalesman
{
	// Public
	public partial class NearestNeighborStrategy
	{

		public NearestNeighborStrategy( AdjacencyMatrix AdjecentMatrix, List<Location> Locations )
		{
			m_AdjecentMatrix = AdjecentMatrix;
			m_Destinations = Locations;
		}

		public List<Location> CalcRoute( int StartIndex, out double TotalDistance )
		{
			if( m_Destinations.Count == 0 ) {
				throw new InvalidOperationException( "No Destinations entered" );
			}

			List<Location> Tour = new List<Location>( m_Destinations.Count );
			//enumerate each destination and find closest...
			Tour = IterateCalcRoute( StartIndex, out TotalDistance );
			return Tour;
		}
	}

	// Protected
	public partial class NearestNeighborStrategy
	{
	}

	// Private
	public partial class NearestNeighborStrategy
	{
		readonly List<Location> m_Destinations;
		AdjacencyMatrix m_AdjecentMatrix;

		/// <summary>
		/// Beware! This Route is NOT a LOOP
		/// </summary>
		/// <param name="StartIndex"></param>
		/// <param name="TotalDistance"></param>
		/// <returns></returns>
		List<Location> IterateCalcRoute( int StartIndex, out double TotalDistance )
		{
			// Make same capacity to prevent realloc memory for this list
			List<Location> Route = new List<Location>( m_Destinations.Capacity );
			List<Location> tempDest = new List<Location>( m_Destinations );

			// Set start location
			Route.Add( m_Destinations[ StartIndex ] );

			// Remove it from temp destination
			tempDest.Remove( m_Destinations[ StartIndex ] );

			TotalDistance = 0.0;

			// Use first route location as start
			Location CurLoc = Route[ 0 ];
			
			// Stop when all destinations are iterated
			while( tempDest.Count != 0 ){

				// Store shortest index and distance
				int ShortestIndex = -1;
				double Shortest = double.MaxValue;

				for( int i = 0; i < tempDest.Count; i++ ) {
					double EdgeDistance = m_AdjecentMatrix.Distance( CurLoc, tempDest[ i ] );

					// Find shortest one
					// Do not need to compare epsilon, because we don't need to check equal
					if( DoubleCmp.Less( EdgeDistance, Shortest ) ) {
						Shortest = EdgeDistance;
						ShortestIndex = i;
					}
				}
				if( ShortestIndex == -1 ) {
					throw new Exception( "Nearest neighbor issue, please check" );
				}
				// Found Shortest one, set it to route and set it as next start
				CurLoc = tempDest[ ShortestIndex ];
				Route.Add( CurLoc );
				tempDest.Remove( CurLoc );
				TotalDistance += Shortest;
			}
			// Don't need to calculate from end -> start distance

			return Route;
		}
	} 
}
