
using System;
using Minio.DataModel;

namespace StormLight.Storage;

public interface IStorage<out T> {

    Task<string> GetUploadUrl();

    Task UploadFile(
        Guid         filename,
        Stream       fileStream,
        IProgress<T> progress
    );
}