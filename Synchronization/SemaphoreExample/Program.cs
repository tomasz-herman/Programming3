namespace SemaphoreExample;

class Program
{
    private static (string, string)[] downloads = [
        ("https://pages.mini.pw.edu.pl/~hermant/wp-content/uploads/2024/10/Tomek-1152x1536.jpg", "hermant.jpg"),
        ("https://pages.mini.pw.edu.pl/~aszklarp/images/me.jpg", "aszklarp.jpg"),
        ("https://pages.mini.pw.edu.pl/~rafalkoj/templates/mini/images/photo.jpg", "rafalkoj.jpg"),
        ("https://pages.mini.pw.edu.pl/~kaczmarskik/krzysztof.jpg", "kaczmarskik.jpg"),
        ("https://cadcam.mini.pw.edu.pl/static/media/kadra8.7b107dbb.jpg", "sobotkap.jpg")
    ];
    
    private static async Task Main()
    {
        Downloader downloader = new Downloader(2);
        await downloader.StartDownloadsAsync(downloads);
    }
}