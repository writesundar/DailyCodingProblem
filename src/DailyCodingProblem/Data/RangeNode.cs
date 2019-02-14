using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DailyCodingProblem.Data
{
    [DebuggerDisplay("{Start},{End}")]
    public class RangeNode
    {
        public RangeNode(int start, int end)
        {
            Start = start;
            End = end;
        }

        public int Start { get; }
        public int End { get; }

        public override bool Equals(object obj)
        {
            var node = (RangeNode)obj;
            return node.Start == Start && node.End == End;
        }

        public override int GetHashCode()
        {
            return (Start.GetHashCode() + End.GetHashCode()).GetHashCode();
        }
    }
}
