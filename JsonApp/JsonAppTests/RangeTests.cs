
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonApp;
using Xunit;


namespace JsonAppTests
{
    public class RangeTests
    {
        [Fact]
        public static void CheckIfWork_WithNull()
        {
            Range range = new('a', 'f');
            Assert.False(range.Match(null));
        }

     }
}