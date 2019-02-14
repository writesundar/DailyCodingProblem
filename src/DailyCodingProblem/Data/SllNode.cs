using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DailyCodingProblem.Data
{
    [DebuggerDisplay("{" + nameof(Val) + "}")]
    public class SllNode
    {
        public int Val { get; set; }
        public SllNode Next { get; set; }
    }
}
