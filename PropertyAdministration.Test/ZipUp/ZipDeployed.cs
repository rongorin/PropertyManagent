using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace PropertyAdministration.Test.ZipUp
{
    [TestClass]
    public class ZipDeployed
    {
        
        private const string outputZipDir = @"C:\temp\";
        private const string outputZipFile = @"propertyAdministration.zip";
        private const string inputFolder = @"C:\temp\propertyAdministration";

        [TestMethod]
        public void Process()
        {

            var outputZip = CheckNewFilePath();

            ZipDirectory(inputFolder, outputZip);
 
        }

        private void ZipDirectory(string inputFolder, string outputZip)
        {
            ZipFile.CreateFromDirectory(inputFolder, outputZip);
        }

        private string CheckNewFilePath()
        {
            string outputFile  = Path.Combine(outputZipDir, outputZipFile); 
            if (File.Exists(outputFile))
            {
                File.Delete(outputFile);
            }
            return outputFile;
        }
    }
}
