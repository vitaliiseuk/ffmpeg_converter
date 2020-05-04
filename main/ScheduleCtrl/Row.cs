using System;
using System.Drawing;
using System.Collections;

namespace GridCtrl
{
	public class Row : GridObject
	{
		public	CellCollection	cellList = new CellCollection();

		public override ObjectType GetObjectType()
		{
			return GridObject.ObjectType.Row;
		}

		~Row()
		{		
			Dispose(false);
		}

		protected override void Dispose(bool disposeManagedResources)
		{
			if (!this.disposed)
			{
				if (disposeManagedResources)
				{
					foreach (Cell c in cellList)
					{
						c.Image = null;
					}
				}
				disposed=true;
			}
			else
			{

            }
		}

		public Cell GetCell(int c)
		{
			if (c > cellList.Count-1)
				throw new GridException("Cell out of range");

			return cellList[c];
		}

		public virtual void Draw(int xOffset, int y, Graphics g)
		{
			int x = 0;
			int xCnt=0;
			foreach (Cell c in cellList)
			{
				if (c.col.Visible)
				{
					if (!c.col.Header && xCnt < xOffset)
					{
						xCnt += c.col.Size;
						continue;
					}

					c.Draw(x,y,g);
					x += c.col.Size;
				}
			}
		}

		public Row(Grid grid, int defaultHeight)
		{
			
			this.grid = grid;
			Size = defaultHeight;

			foreach (Column c in grid.colList)
				AddCell(c);
		}
	
		public Cell AddCell(Column c)
		{
			Cell cell = grid.CreateCell(this, c);
			cellList.Add(cell);
			return cell;
		}

		public virtual object Value(Column col)
		{
			return grid.GetColList().IndexOf(col).ToString();
		}

		public void ReplaceCell(Cell replaceCell, Cell cell)
		{
			int index = cellList.IndexOf(replaceCell);

			cellList.RemoveAt(index);
			cell.Attach(replaceCell.row, replaceCell.col);
			cellList.Insert(index, cell);
		}
	}	
}
