using System;
using System.Collections.Generic;
using System.Text;

namespace TravellingSalesman
{
	// Public
	public static partial class DoubleCmp
	{
		public static double Tolerance
		{
			get
			{
				return m_Tolerance;
			}
			set
			{
				m_Tolerance = value;
			}
		}
		public static int AboutCompare( double A, double B )
		{
			double Diff = A - B;

			// Difference less than tolerance, it's equal
			double AbsDiff = Math.Abs( Diff );
			if( AbsDiff < m_Tolerance ) {
				return 0;
			}
			// Difference > 0, A > B
			if( Diff > 0.0 ) {
				return 1;
			}
			// Diff < 0. A < B
			else {
				return -1;
			}
		}
		/// <summary>
		/// Greater or Equal
		/// </summary>
		/// <param name="A"></param>
		/// <param name="B"></param>
		/// <returns></returns>
		public static bool GE( double A, double B )
		{
			int nRet = AboutCompare( A, B );

			// If less, then it's not GE
			if( nRet == -1 ) {
				return false;
			}
			else {
				return true;
			}
		}
		public static bool LE( double A, double B )
		{
			int nRet = AboutCompare( A, B );

			// If it's greater, then it's not LE
			if( nRet == 1 ) {
				return false;
			}
			else {
				return true;
			}
		}
		public static bool Great( double A, double B )
		{
			int nRet = AboutCompare( A, B );
			if( nRet == 1 ) {
				return true;
			}
			else {
				// Not greater then it's false
				return false;
			}
		}
		public static bool Less( double A, double B )
		{
			int nRet = AboutCompare( A, B );
			if( nRet == -1 ) {
				return true;
			}
			else {
				// Not lesser then it's false
				return false;
			}
		}
		public static bool EQ( double A, double B )
		{
			int nRet = AboutCompare( A, B );
			if( nRet == 0 ) {
				return true;
			}
			else {
				// Anything else not equal
				return false;
			}
		}
		public static bool NE( double A, double B )
		{
			int nRet = AboutCompare( A, B );
			if( nRet != 0 ) {
				return true;
			}
			else {
				// Anything not not equals is false
				return false;
			}
		}
	}
	// Protected
	public static partial class DoubleCmp
	{
	}
	// Private
	public static partial class DoubleCmp
	{
		static double m_Tolerance = 10E-6;
	}
}
