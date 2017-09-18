using System;
using System.Collections.Generic;
using System.Text;

namespace TravellingSalesman
{
	public class Point
	{
		public double X
		{
			get
			{
				return Coordinate[ 0 ];
			}
			set
			{
				Coordinate[ 0 ] = value;
			}
		}
		public double Y
		{
			get
			{
				return Coordinate[ 1 ];
			}
			set
			{
				Coordinate[ 1 ] = value;
			}
		}
		public double Z
		{
			get
			{
				return Coordinate[ 2 ];
			}
			set
			{
				Coordinate[ 2 ] = value;
			}
		}
		public double[] Coordinate
		{
			get
			{
				return m_Coord;
			}
			set
			{
				m_Coord = value;
			}
		}
		public Point()
			: this( 0, 0, 0 )
		{
		}
		public Point( double x, double y, double z )
		{
			m_Coord = new double[] { x, y, z };
		}
		override public string ToString()
		{
			return string.Concat( "(", X.ToString(), ", ", Y.ToString(), ", ", Z.ToString(), ")" );
		}
		public Point( Point pt )
			: this( 0, 0, 0 )
		{
			for( int i = 0; i < m_TotalCoordNum; i++ ) {
				m_Coord[ i ] = pt.m_Coord[ i ];
			}
		}
		public Point Clone()
		{
			return new Point( this.X, this.Y, this.Z );
		}
		public Point CrossProduct( Point other )
		{
			// u x v = ( u2v3 - u3v2 )i + (u3v1 - u1v3)j + (u1v2 - u2v1)k
			double i = this.Coordinate[ 1 ] * other.Coordinate[ 2 ] - this.Coordinate[ 2 ] * other.Coordinate[ 1 ];
			double j = this.Coordinate[ 2 ] * other.Coordinate[ 0 ] - this.Coordinate[ 0 ] * other.Coordinate[ 2 ];
			double k = this.Coordinate[ 0 ] * other.Coordinate[ 1 ] - this.Coordinate[ 1 ] * other.Coordinate[ 0 ];
			Point ret = new Point( i, j, k );
			return ret;
		}
		public double Distance()
		{
			double ret = Math.Sqrt( this.X * this.X + this.Y * this.Y + this.Z * this.Z );
			return ret;
		}
		public static Point operator +( Point a, Point b )
		{
			Point tmp = new Point();
			for( int i = 0; i < m_TotalCoordNum; i++ ) {
				tmp.Coordinate[ i ] = a.Coordinate[ i ] + b.Coordinate[ i ];
			}
			return tmp;
		}
		public static Point operator -( Point a )
		{
			return ( ( new Point() ) - a );
		}
		public static Point operator -( Point a, Point b )
		{
			Point tmp = new Point();
			for( int i = 0; i < m_TotalCoordNum; i++ ) {
				tmp.Coordinate[ i ] = a.Coordinate[ i ] - b.Coordinate[ i ];
			}
			return tmp;
		}
		public static Point operator /( Point a, double Number ){
			Point tmp = new Point();
			for( int i = 0; i < a.Coordinate.Length; i++ ) {
				tmp.Coordinate[ i ] = a.Coordinate[ i ] / Number;
			}
			return tmp;
		}
		public static Point operator *( Point a, double Number )
		{
			Point tmp = new Point();
			for( int i = 0; i < a.Coordinate.Length; i++ ) {
				tmp.Coordinate[ i ] = a.Coordinate[ i ] * Number;
			}
			return tmp;
		}
		double[] m_Coord;
		const int m_TotalCoordNum = 3;
	}
}
