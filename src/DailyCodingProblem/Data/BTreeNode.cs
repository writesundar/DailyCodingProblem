using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DailyCodingProblem.Data
{
    [DebuggerDisplay("{" + nameof(Val) + "}")]
    public class BTreeNode
    {
        public int Val { get; set; }
        public BTreeNode Left { get; set; }
        public BTreeNode Right { get; set; }
    }
}
