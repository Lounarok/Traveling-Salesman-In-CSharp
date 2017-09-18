using System;
using System.Collections.Generic;
using System.Collections;

namespace TravellingSalesman
{
	class Program
	{
		static void Main( string[] args )
		{
			List<Location> LocationList = new List<Location>( 5 );

			// U type test
			LocationList.Add( new Location( "1", 0, 0 ) );
			LocationList.Add( new Location( "2", 1, 0 ) );
			LocationList.Add( new Location( "3", 2, 0 ) );
			LocationList.Add( new Location( "4", 3, 0 ) );
			LocationList.Add( new Location( "5", 4, 0 ) );
			LocationList.Add( new Location( "6", 4, 1 ) );
			LocationList.Add( new Location( "7", 0, 2 ) );

			// Set location index
			for( int i = 0; i < LocationList.Count; i++ ) {
				LocationList[ i ].Index = i;
			}

			//TSPDataReader Reader = new TSPDataReader();
			//LocationList = Reader.Read( @"..\..\..\TSPData\wi29.tsp" );

			AdjacencyMatrix AdjMatrix = new AdjacencyMatrix( ref LocationList );

			Console.WriteLine( "Adjecent Matrix Done" );

			//calculate shortest route between...
			NearestNeighborStrategy RouteStrategy = new NearestNeighborStrategy( AdjMatrix, LocationList );

			// Start from 0
			double TotalDistance;
			RouteCalculator Calculator = new RouteCalculator( AdjMatrix );

			double BestResult = double.MaxValue;

			//int i = 1;
			for( int i = 0; i < LocationList.Count; i++ ) {
				List<Location> Route = RouteStrategy.CalcRoute( i, out TotalDistance );

				Console.WriteLine( "Origin  distance: " + TotalDistance.ToString() );
				foreach( Location place in Route ) {
					Console.Write( place.Name + " " );
				}
				TwoOptimization TwoOpt = new TwoOptimization( AdjMatrix );

				//// Make loop route
				//Route.Add( Route[ 0 ] );
				Route = TwoOpt.RouteOptimize( Route, AdjMatrix );

				double TwoOptLen = Calculator.CalcLength( Route );
				Console.WriteLine( "Reroute distance: " + TwoOptLen.ToString() );

				foreach( Location place in Route ) {
					Console.Write( place.Name + " " );
				}
				Console.WriteLine( "\r\n" );

				if( TwoOptLen < BestResult ) {
					BestResult = TwoOptLen;
				}
			}
			Console.WriteLine( "Best Result:" + BestResult.ToString() );
			Console.WriteLine( "Press to exit" );
			Console.ReadKey();
		}
	}
}
