using System;
using System.Collections;
using System.Collections.Generic;

namespace AutoChessTD.Grid {

    /// <summary>
    /// GridLocation with top left corresponding to A1
    /// </summary>
    public class GridLocation {

        public char Row { get; private set; }    // A, B, C, D, etc.
        public int Column { get; private set; }    // 1, 2, 3, 4, etc.

        public GridLocation(char row, int column) {
            Row = char.ToUpper(row);
            Column = column;
        }

        public GridLocation(int row, int column) {
            Row = (char)('A' + row);
            Column = column + 1;
        }

        public int GetRowValue() {
            return Row - 'A';
        }

        public int GetColumnValue() {
            return Column - 1;
        }

        public override string ToString() {
            return Row + Column.ToString();
        }

        public override int GetHashCode() {
            return Column.GetHashCode() ^ Row.GetHashCode();
        }

        public override bool Equals(object obj) {
            if (obj == null) return false;
            if (this == obj) return true;

            GridLocation other = (GridLocation)obj;
            if (other == null) return false;

            if (GetRowValue() != other.GetRowValue()) return false;
            if (GetColumnValue() != other.GetColumnValue()) return false;

            return true;
        }
    }
}
