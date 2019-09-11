using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AutoChessTD.Grid {

    /// <summary>
    /// GridLocation with top left corresponding to A1
    /// </summary>
    public class GridLocation {

        public int Row { get; private set; }
        public char Column { get; private set; }

        public GridLocation(int row, char column) {
            Row = row;
            Column = column;
        }

        public GridLocation(int row, int column) {
            Row = row + 1;
            Column = (char)((int)'A' + column);
        }

        public int GetRowValue() {
            return Row - 1;
        }

        public int GetColumnValue() {
            return Column - 'A';
        }

        public override string ToString() {
            return Column + Row.ToString();
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
