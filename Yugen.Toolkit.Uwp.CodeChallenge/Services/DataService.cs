﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using Yugen.Toolkit.Uwp.CodeChallenge.Interfaces;
using Yugen.Toolkit.Uwp.CodeChallenge.Model;

namespace Yugen.Toolkit.Uwp.CodeChallenge.Services
{
    public class DataService : IDataService
    {
        private readonly IEncryptionManager _encryptionManager;

        public DataService(IEncryptionManager encryptionManager)
        {
            _encryptionManager = encryptionManager;
        }

        public bool HasValues => Values.Any();

        public IList<ValueModel> Values { get; private set; } = new List<ValueModel>();

        public async Task Load()
        {
            var localFolder = ApplicationData.Current.LocalFolder;
            var valuesFile = await localFolder.TryGetItemAsync("Values.txt");

            if (valuesFile != null)
            {
                var buffer = await FileIO.ReadBufferAsync((IStorageFile)valuesFile);
                //var content = await DecryptBuffer(buffer);
                //var values = JsonConvert.DeserializeObject<List<ValueModel>>(content);

                //foreach (var valueModel in values)
                //{
                //    Values.Add(valueModel);
                //}
            }
        }

        public async Task Save(IList<ValueModel> values)
        {
            Values = values;

            var valuesFile = await ApplicationData.Current.LocalFolder.CreateFileAsync("Values.txt", CreationCollisionOption.ReplaceExisting);
            //var json = JsonConvert.SerializeObject(Values);
            //var encryptedData = await EncryptJson(json);

            //await FileIO.WriteBytesAsync(valuesFile, encryptedData);
        }

        private async Task<string> DecryptBuffer(IBuffer buffer)
        {
            var bytesToDecrypt = buffer.ToArray();
            var decryptedBytes = await _encryptionManager.DecryptV2(bytesToDecrypt, true);
            var content = Encoding.ASCII.GetString(decryptedBytes);
            return content;
        }

        private async Task<byte[]> EncryptJson(string json)
        {
            var bytesToEncrypt = Encoding.ASCII.GetBytes(json);
            var encryptedData = await _encryptionManager.EncryptV2(bytesToEncrypt, true);
            return encryptedData;
        }
    }
}