using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace PropertyAdministration.Test.ZipUp
{
    [TestClass]
    public class ZipUpPublished
    {

        private const string path = @"C:\Users\Ronald\Documents\Visual Studio 2019\Projects\PropertyAdministration\PropertyAdministration\bin\Release\netcoreapp3.0\publish\";
        private const string outputZipDir = @"C:\temp\";
        private const string outputZipFile = @"propertyAdministration.zip";


        public string GetInputFilePath(string path)
        {
            return Path.GetDirectoryName(path);

        }
        [TestMethod]
        public void Process()
        {
            string inputPath = GetInputFilePath(path);
            string outputFileName = Path.Combine(outputZipDir, outputZipFile);

            if (File.Exists(outputFileName))
            {
                File.Delete(outputFileName);
            }
            ZipDirectory(inputPath, outputFileName);

            CopySettingsFiles();

        }


        public void ZipDirectory(string dirToZip, string outputFileName)
        {
            ZipFile.CreateFromDirectory(dirToZip,
                                        outputFileName,
                                        CompressionLevel.Fastest,
                                        true);
        }

         public void CopySettingsFiles()
        {
            const string workingDir = @"C:\temp\propertyAdministration";


            string[] applicationFiles = System.IO.Directory.GetFiles(workingDir, "appsettings.*");

            foreach(var sourceFile in applicationFiles)
            {
                string sourcefileName = Path.GetFileName(sourceFile);
                string destination = Path.Combine(outputZipDir, sourcefileName);
                if (File.Exists(destination))
                {
                    File.Delete(destination);
                } 
                System.IO.File.Copy(sourceFile, destination , true);
            }
             

        }
}
}
