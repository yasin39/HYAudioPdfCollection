namespace HYAudioPdfCollection.Client.Models
{
    public class MediaFile
    {
        public string Title { get; set; } = "";
        public string FileId { get; set; } = "";
        public string Type { get; set; } = ""; // "audio" veya "pdf"
        public string Language { get; set; } = ""; // "turkish" veya "english"

        public string DownloadUrl => $"https://drive.google.com/uc?export=download&id={FileId}";
    }
}
