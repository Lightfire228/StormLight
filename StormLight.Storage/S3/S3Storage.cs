
using Minio;
using Minio.DataModel;
using Minio.DataModel.Args;

namespace StormLight.Storage.S3;

public class S3Storage
    : IStorage<ProgressReport>
{

    protected IMinioClient Client;

    public string Bucket { get; } = "stormlight-storage";
    public string Queue  { get; } = "queue";

    public int OneHour { get; } = 1 * 60 * 60;

    public S3Storage(IMinioClient client) {
        Client = client;
    }

    public async Task<string> GetUploadUrl() {


        Guid   filename = Guid.NewGuid();
        string objName  = GetQueueObject(filename);

        return await Client
            .PresignedPutObjectAsync(
                new PresignedPutObjectArgs()
                .WithBucket(Bucket)
                .WithObject(objName)
                .WithExpiry(OneHour)
            )
        ;
    }

    public async Task UploadFile(
        Guid   filename,
        Stream fileStream,
        IProgress<ProgressReport> progress
    ) {

        string objName = GetQueueObject(filename);

        var args = new PutObjectArgs()
            .WithBucket     (Bucket)
            .WithObject     (objName)
            .WithStreamData (fileStream)
            .WithObjectSize (fileStream.Length)
            .WithContentType("application/octet-stream")
            // .WithHeaders(metaData)
            .WithProgress   (progress)
            // .WithServerSideEncryption(sse);
        ;

        _ = await Client.PutObjectAsync(args);
    }

    public string GetQueueObject(Guid filename) =>
        $"{Queue}/{filename}"
    ;
}