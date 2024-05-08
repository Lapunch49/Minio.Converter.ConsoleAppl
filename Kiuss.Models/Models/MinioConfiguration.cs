// <copyright file="MinioConfiguration.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Dt.File.MinioConfig
{
    public record MinioConfiguration(string endpoint, string accessKey, string secretKey, string rootFolderName, string bucketName, string location);
}
