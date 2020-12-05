using System.IO;
using System.Linq;
using Xunit.Sdk;

namespace Katsuben.UnitTests.Utils
{
    public class FileAssert
    {
        public static void Equal(string expected, string actual)
        {
            if (EqualFileReference(expected, actual))
            {
                return;
            }

            EqualFileLength(expected, actual);
            EqualFileContent(expected, actual);
        }

        private static bool EqualFileReference(string expected, string actual)
        {
            return expected == actual;
        }

        private static void EqualFileLength(string expected, string actual)
        {
            using var fsExpected = new FileStream(expected, FileMode.Open, FileAccess.Read);
            using var fsActual = new FileStream(actual, FileMode.Open, FileAccess.Read);
            if (fsExpected.Length != fsActual.Length)
            {
                throw new EqualException(
                    $"{expected} content length {fsExpected.Length}",
                    $"{actual} content length {fsActual.Length}");
            }
        }

        private static void EqualFileContent(string expected, string actual)
        {
            if (!File.ReadAllBytes(expected).SequenceEqual(File.ReadAllBytes(actual)))
            {
                throw new EqualException(expected, actual);
            }
        }
    }
}
