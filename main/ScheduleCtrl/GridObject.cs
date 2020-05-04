using System;
using System.Collections;

namespace GridCtrl
{
	public abstract class GridObject
	{
		public enum ObjectType
		{
			Grid,
			Column,
			Row,
			Cell,
		}

		private		int	    size		= 0;
		private		bool	isVisible	= true;
		private		bool	isHeader	= false;
		private		bool    selected	= false;
		private		bool	canResize	= true;
		public		Grid	grid		= null;
		protected	bool	disposed	= false;

		public abstract ObjectType GetObjectType();

		protected virtual void Dispose(bool disposeManagedResources)
		{
		}

		public void Dispose()
		{

			Dispose(true);

			GC.SuppressFinalize(this);
		}

		public GridObject()
		{
		}

		public GridObject(Grid grid_, uint defaultSize)
		{
			grid = grid_;
			size = (int) defaultSize;
		}

		public bool Selected
		{
			get
			{
				return selected;
			}

			set
			{			
				selected = value;
				grid.Invalidate(this);
			}
		}

		public bool CanResize
		{
			get
			{
				return canResize;
			}

			set 
			{
				canResize = value;
			}			
		}

		public bool Header
		{
			get  
			{
				return isHeader;
			}

			set
			{
				isHeader= value;
			}
		}

		virtual public int Size
		{
			get
			{
				return size;
			}

			set
			{
				size = value;
				grid.Invalidate();				
			}
		}

		public bool Visible
		{
			get
			{
				return isVisible;
			}

			set 
			{
				isVisible = value;
			}
		}
	}

	public class GridObjectCollection : CollectionBase  
	{
		public GridObject this[ int index ]  
		{
			get  
			{
				return( (GridObject) List[index] );
			}
			set  
			{
				List[index] = value;
			}
		}

		public int Add( GridObject value )  
		{
			return( List.Add( value ) );
		}

		public int IndexOf( GridObject value )  
		{
			return( List.IndexOf( value ) );
		}

		public void Insert( int index, GridObject value )  
		{
			List.Insert( index, value );
		}

		public void Remove( GridObject value )  
		{
			List.Remove( value );
		}

		public bool Contains( GridObject value )  
		{
			return( List.Contains( value ) );
		}

		protected override void OnInsert( int index, Object value )  
		{

        }

		protected override void OnRemove( int index, Object value )  
		{
			GridObject o = (GridObject) value;			
			o.Dispose();			
		}

		protected override void OnSet( int index, Object oldValue, Object newValue )  
		{

		}

		protected override void OnValidate( Object value )  
		{

        }

		public virtual GridObject GetNextObject(GridObject value)
		{
			GridObject gridObj = null;

			// Look up ordinal
			int i = IndexOf(value);
			
			do
			{
				i++;
				if (i == Count)
				{
					gridObj = this[Count-1];
					break;
				}

				gridObj = this[i];
				
				if (!gridObj.Visible || gridObj.Header)
					continue;
				
				break;
			}
			while (i < Count);

			return gridObj;
		}

		public virtual GridObject GetPrevObject(GridObject value)
		{		
			GridObject gridObj = null;
		
			// Look up ordinal
			int i = IndexOf(value);
			
			do
			{
				i--;
				if (i < 0)
				{
					gridObj = this[0];
					break;
				}

				gridObj = this[i];
				
				if (!gridObj.Visible)
					continue;

				if (gridObj.Header)
				{
					if (i+1 < Count-1)
					{
						gridObj = this[i+1];
						break;

					}
				}
				
				break;
			}
			while (i > 0);

			return gridObj;
		}
	}
}
