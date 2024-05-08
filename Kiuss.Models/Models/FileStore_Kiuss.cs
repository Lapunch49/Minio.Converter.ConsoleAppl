﻿using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Dt.Kiuss.Common.File.Dto;
using Microsoft.Extensions.Primitives;
using Minio;
using Minio.DataModel.Args;
using Minio.DataModel.Notification;
using Minio.Exceptions;
using Dt.File.Store;
using Dt.File.MinioConfig;

namespace Dt.Kiuss.Supervisor.Domain.Utils.File
{
    public class FileStoreKiuss : FileStore, IFileStore
    {
        public FileStoreKiuss(MinioConfiguration minioConfig) 
            : base(minioConfig)
        {
        }

        public async Task<FileContentDto> LoadFile(Guid fileId, Guid drillingProjectId, string fileName)
        {
            var objectName = $"{fileId}.{fileName}";
            var folderName = drillingProjectId.ToString();
            var minioFileName = $"{folderName}\\{objectName}";
            var filePath = $"{this.rootFolderName}\\{minioFileName}";

            Task<FileContentDto> task = LoadFile_(objectName, folderName, minioFileName, filePath);
            return task.Result;
        }

        public async Task CreateFile(Guid fileId, Guid drillingProjectId, byte[] fileContent, string fileName)
        {
            var objectName = $"{fileId}.{fileName}";
            var folderName = drillingProjectId.ToString();
            var minioFileName = $"{folderName}\\{objectName}";
            var filePath = $"{this.rootFolderName}\\{minioFileName}";

            _ = CreateFile_(objectName, folderName, minioFileName, filePath, fileContent);
        }

        public async void DeleteFile(Guid fileId, Guid drillingProjectId, string fileName)
        {
            var objectName = $"{fileId}.{fileName}";
            var folderName = drillingProjectId.ToString();
            var minioFileName = $"{folderName}\\{objectName}";
            var filePath = $"{this.rootFolderName}\\{minioFileName}";

            DeleteFile_(objectName, folderName, minioFileName, filePath);
        }
    }
}