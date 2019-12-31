// <copyright file=ZipFileWithProgress>
// Copyright (c) 2019-2020 All Rights Reserved
// </copyright>
// <author>Franco28</author>
// <date> 31/12/2019 19:15:46</date>
// <summary>A basic simple Tool based on C# for Xiaomi Redmi Note 7 Lavender </summary>




using System;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace RedmiNote7ToolC
{

    static class ZipFileWithProgress
    {
        public static void CreateFromDirectory(string sourceDirectoryName, string destinationArchiveFileName, IProgress<double> progress)
        {
            sourceDirectoryName = Path.GetFullPath(sourceDirectoryName);

            FileInfo[] sourceFiles =
                new DirectoryInfo(sourceDirectoryName).GetFiles("*", SearchOption.AllDirectories);
            double totalBytes = sourceFiles.Sum(f => f.Length);
            long currentBytes = 0;

            using (ZipArchive archive = ZipFile.Open(destinationArchiveFileName, ZipArchiveMode.Create))
            {
                foreach (FileInfo file in sourceFiles)
                {
                    // NOTE: naive method to get sub-path from file name, relative to
                    // input directory. Production code should be more robust than this.
                    // Either use Path class or similar to parse directory separators and
                    // reconstruct output file name, or change this entire method to be
                    // recursive so that it can follow the sub-directories and include them
                    // in the entry name as they are processed.
                    string entryName = file.FullName.Substring(sourceDirectoryName.Length + 1);
                    ZipArchiveEntry entry = archive.CreateEntry(entryName);

                    entry.LastWriteTime = file.LastWriteTime;

                    using (Stream inputStream = File.OpenRead(file.FullName))
                    using (Stream outputStream = entry.Open())
                    {
                        Stream progressStream = new StreamWithProgress(inputStream,
                            new BasicProgress<int>(i =>
                            {
                                currentBytes += i;
                                progress.Report(currentBytes / totalBytes);
                            }), null);

                        progressStream.CopyTo(outputStream);
                    }
                }
            }
        }

        public static void ExtractToDirectory(string sourceArchiveFileName, string destinationDirectoryName, IProgress<double> progress)
        {
            using (ZipArchive archive = ZipFile.OpenRead(sourceArchiveFileName))
            {
                double totalBytes = archive.Entries.Sum(e => e.Length);
                long currentBytes = 0;

                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    string fileName = Path.Combine(destinationDirectoryName, entry.FullName);

                    Directory.CreateDirectory(Path.GetDirectoryName(fileName));
                    using (Stream inputStream = entry.Open())
                    using (Stream outputStream = File.OpenWrite(fileName))
                    {
                        Stream progressStream = new StreamWithProgress(outputStream, null,
                            new BasicProgress<int>(i =>
                            {
                                currentBytes += i;
                                progress.Report(currentBytes / totalBytes);
                            }));

                        inputStream.CopyTo(progressStream);
                    }

                    File.SetLastWriteTime(fileName, entry.LastWriteTime.LocalDateTime);
                }
            }
        }

        private class StreamWithProgress : Stream
        {
            private Stream inputStream;
            private BasicProgress<int> basicProgress;
            private object p;

            public StreamWithProgress(Stream inputStream, BasicProgress<int> basicProgress, object p)
            {
                this.inputStream = inputStream;
                this.basicProgress = basicProgress;
                this.p = p;
            }

            public override bool CanRead => throw new NotImplementedException();

            public override bool CanSeek => throw new NotImplementedException();

            public override bool CanWrite => throw new NotImplementedException();

            public override long Length => throw new NotImplementedException();

            public override long Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public override void Flush()
            {
                throw new NotImplementedException();
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                throw new NotImplementedException();
            }

            public override long Seek(long offset, SeekOrigin origin)
            {
                throw new NotImplementedException();
            }

            public override void SetLength(long value)
            {
                throw new NotImplementedException();
            }

            public override void Write(byte[] buffer, int offset, int count)
            {
                throw new NotImplementedException();
            }
        }
    }

}
