using System;
using System.Collections;

namespace GridCtrl
{
	public class Column : GridObject
	{
		public override ObjectType GetObjectType()
		{
			return GridObject.ObjectType.Column;
		}

		~Column()
		{		
			Dispose(false);
		}

		protected override void Dispose(bool disposeManagedResources)
		{
			if (!this.disposed)
			{
				if (disposeManagedResources)
				{
				}

                disposed = true;
			}
			else
			{
			}
		}


		public object Value(Row row)
		{
			return grid.GetRowList().IndexOf(row);
		}


		public Column(Grid grid, uint Width)
		{
			this.grid = grid;
			this.Size = (int) Width;
		}
	}
}
