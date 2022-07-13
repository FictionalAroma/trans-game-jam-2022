using HexGridLib;
using NUnit.Framework;

namespace BackendTesting.HexTesting
{


    [TestFixture]
    public class HexCoordTests
    {
        private static HexCoords ZeroCoord = new HexCoords() { X = 0, Z = 0 };
        private static HexCoords Coord11 = new HexCoords() { X = 1, Z = 1 };


        private static object[] HexGridLengthCases =
        {
            new object[] { 0,0,0 },

            new object[] { -1, 1, 1 },
            new object[] { 0, 1, 1 },
            new object[] { 1, 0, 1 },
            new object[] { 1, -1, 1 },
            new object[] { 0, -1, 1 },
            new object[] { -1, 0, 1 },
            new object[] {-1, -1, 2 },
            new object[] { 1, 1, 2 },

        };

        [Test]
        [TestCaseSource(nameof(HexGridLengthCases))]
        public void TestHexGridLengthAway(int x, int y, int expectedDistance)
        {
            var testCoords = new HexCoords() { X = x, Z = y };

            Assert.AreEqual(expectedDistance, (int)testCoords.HexGridLengthAway());
        }

        public void TestDistanceFromZero()
        {

        }

    }

}