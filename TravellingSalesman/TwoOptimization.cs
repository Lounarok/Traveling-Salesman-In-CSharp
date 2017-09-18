using System;
using System.Collections.Generic;
using System.Text;

namespace TravellingSalesman
{
	// Public
	public partial class TwoOptimization
	{
		public TwoOptimization( AdjacencyMatrix AdjMatrix )
		{
		}
		public List<Location> RouteOptimize( List<Location> OriginRoute, AdjacencyMatrix AdjMatrix )
		{
			RouteCalculator Calculator = new RouteCalculator( AdjMatrix );
			bool bDone = false;

			// Copy sequence to prevent modifying Origin Route
			List<Location> BestRoute = new List<Location>( OriginRoute );
			double BestLength = Calculator.CalcLength( BestRoute );

			int nOperationCount = 0;

			// Stop criteria is n^4, because generally it only swap for n^2 * n vertices
			// Multiply n^3 with n to make it as an upper bound to preven loop freezing
			int nStopcriteria = (int)Math.Pow( BestRoute.Count, 4 );

			while( bDone == false ) {
				bool bRestart = false;
				//Except Start location, Iterate through all cities, Assume there is no loop
				for( int i = 0; i < BestRoute.Count; i++ ) {

					// check all cities
					for( int k = i + 1; k < BestRoute.Count - 1; k++ ) {
						// If temp swapped Route is smaller than current Route, swap
						List<Location> NewRoute = SwapRoute( BestRoute, i, k );
						double NewLength = Calculator.CalcLength( NewRoute );

						nOperationCount++;

						// If new length is shorter, set it as current route
						if( DoubleCmp.Less( NewLength, BestLength ) ) {
							bRestart = true;
							BestLength = NewLength;
							BestRoute = NewRoute;
						}
						else if( nOperationCount > nStopcriteria ) {
							return BestRoute;
						}

						// If swapped, restart iteration ( Not using recursion because it might cause stack overflow )
						if( bRestart ) {
							break;
						}
					}
					// Swapped, restart loop
					if( bRestart ) {
						break;
					}
				}
				if( bRestart == false ) {
					bDone = true;
				}
				// Future work: Error handling condition ( If any bug leads to unlimited test )
			}
			Console.WriteLine( "\r\n Operation count:" + nOperationCount.ToString() );
			return BestRoute;
		}
	}

	// Protected
	public partial class TwoOptimization
	{

	}

	// Private
	public partial class TwoOptimization
	{
		List<Location> SwapRoute( List<Location> OriginRoute, int nSwapStart, int nSwapEnd )
		{
			List<Location> NewRoute = new List<Location>( OriginRoute.Capacity );

			// 1. take route[0] to route[nSwapStart-1] and add them in order to new_route
			for( int i = 0; i < nSwapStart; i++ ) {
				NewRoute.Add( OriginRoute[ i ] );
			}
			// Reverse nStart to nEnd
			int nSwapCount = nSwapEnd - nSwapStart + 1;
			Stack<Location> ReverseRoute = new Stack<Location>( nSwapCount );

			//2. take route[nSwapStart] to route[nSwapEnd] and add them in reverse order to new_route
			for( int i = nSwapStart; i < nSwapEnd + 1; i++ ) {
				ReverseRoute.Push( OriginRoute[ i ] );
			}
			for( int i = 0; i < nSwapCount; i++ ) {
				NewRoute.Add( ReverseRoute.Pop() );
			}
			//3. take route[nSwapEnd+1] to end and add them in order to new_route
			for( int i = nSwapEnd + 1; i < OriginRoute.Count; i++ ) {
				NewRoute.Add( OriginRoute[ i ] );
			}
			return NewRoute;
		}
	}
}
