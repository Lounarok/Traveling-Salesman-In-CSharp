namespace TravellingSalesman
{
	public partial class Location : Point
	{
		// Public
		public override int GetHashCode()
		{
			unchecked {
				return ( X.GetHashCode() * 397 ) ^ Y.GetHashCode();
			}
		}

		public Location() : base() 
		{
		}

		public int Index;

		public Location( string name, double X, double Y  )
		{
			Name = name;
			this.X = X;
			this.Y = Y;
		}

		public string Name;

		public override bool Equals( object obj )
		{
			if( ReferenceEquals( null, obj ) )
				return false;
			if( ReferenceEquals( this, obj ) )
				return true;
			if( obj.GetType() != this.GetType() )
				return false;
			return Equals( (Location)obj );
		}
		public override string ToString()
		{
			return this.Name;
		}
	}
	// Protected
	public partial class Location
	{
		protected bool Equals( Location other )
		{
			return X.Equals( other.X ) && Y.Equals( other.Y );
		}
	}
	// Private
	public partial class Location
	{
	}
}