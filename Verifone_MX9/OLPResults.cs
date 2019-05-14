using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Verifone_MX9
{
    class OLPResults
    {
        public OLPResults()
        {
            Results = new List<TestResult>();
        }
        public bool IsPassed { get; set; }
        public string tamperCode { get; set; }
        public IList<TestResult> Results { get; set; }
    }

    class TestResult
    {
        public string Code { get; set; }
        public bool IsPassed { get; set; }
    }
}
