﻿using System;
using System.IO;

namespace TestKastuben
{
    public class FileUtil
    {
        public static string ResourcePath(string resource)
        {
            return Path.Join(AppContext.BaseDirectory, resource);
        }

        public static string CreateTempFileForResource(string resource)
        {
            var tempPath = Path.Join(Path.GetTempPath(), Path.GetRandomFileName());
            var tempFile = Path.Join(tempPath, Path.GetFileName(resource));
            Directory.CreateDirectory(tempPath);
            File.Copy(ResourcePath(resource), tempFile);
            return tempFile;
        }
    }
}
