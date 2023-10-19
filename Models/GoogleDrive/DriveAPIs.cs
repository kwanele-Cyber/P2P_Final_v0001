﻿using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using static Google.Apis.Drive.v3.DriveService;

namespace P2P_Final_v0._001.Models.GoogleDrive
{
    public static class DriveAPIs
    {
        private static DriveService GetService()
        {
            var tokenResponse = new TokenResponse
            {
                AccessToken = Credentials.AccessToken,
                RefreshToken = Credentials.RefreshToken,
            };

            var applicationName = Credentials.applicationName; // Use the name of the project in Google Cloud
            var username = Credentials.username; // Use your email
            var apiCodeFlow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets
                {
                    ClientId = Credentials.ClientId,
                    ClientSecret = Credentials.ClientSecret
                },
                Scopes = new[] { Scope.Drive },
                DataStore = new FileDataStore(applicationName)
            });

            var credential = new UserCredential(apiCodeFlow, username, tokenResponse);
            
            var service = new DriveService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = applicationName
            });

            return service;
        }

        public static string CreateFolder(string parent, string folderName)
        {
            var service = GetService();

            var driveFolder = new Google.Apis.Drive.v3.Data.File();
                driveFolder.Name = folderName;
                driveFolder.MimeType = "application/vnd.google-apps.folder";
                driveFolder.Parents = new string[] { parent };

            var command = service.Files.Create(driveFolder);
            var file = command.Execute();

            return file.Id;
        }

        public static string UploadFile(Stream file, string fileName, string fileMime, string folder, string fileDescription)
        {
            DriveService service = GetService();


            var driveFile = new Google.Apis.Drive.v3.Data.File();
                driveFile.Name = fileName;
                driveFile.Description = fileDescription;
                driveFile.MimeType = fileMime;
                driveFile.Parents = new string[] { folder };


            var request = service.Files.Create(driveFile, file, fileMime);
                request.Fields = "id";

            var response = request.Upload();

            if (response.Status != Google.Apis.Upload.UploadStatus.Completed) 
                throw response.Exception;

            return request.ResponseBody.Id;
        }

        public static void DeleteFile(string fileId)
        {
            var service = GetService();
            var command = service.Files.Delete(fileId);
            var result = command.Execute();
        }

        public static IEnumerable<Google.Apis.Drive.v3.Data.File> GetFiles(string folder)
        {
            var service = GetService();

            var fileList = service.Files.List();
                fileList.Q = $"mimeType!='application/vnd.google-apps.folder' and '{folder}' in parents";
                fileList.Fields = "nextPageToken, files(id, name, size, mimeType)";

            var result = new List<Google.Apis.Drive.v3.Data.File>();
            string pageToken = null;
            do
            {
                fileList.PageToken = pageToken;
                var filesResult = fileList.Execute();
                var files = filesResult.Files;
                pageToken = filesResult.NextPageToken;
                result.AddRange(files);
            }
            while (pageToken != null);
            return result;
        }

    }
}