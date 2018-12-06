using System;

namespace VerificationTool.Verification.Readers.Exceptions
{
    public class InvalidFileFormatException : Exception
    {
        public InvalidFileFormatException(string filename, string fileType)
            : base($"The file ${filename} does not have a valid ${fileType} format.")
        { }
    }
}
