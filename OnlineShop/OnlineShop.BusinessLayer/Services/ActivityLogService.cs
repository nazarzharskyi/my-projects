using OnlineShop.Constants;

namespace OnlineShop.Records
{
    public class ActivityLogService
    {
        public async Task OutputLog(ActivityLog log)
        {
            string logPath = FileConstants.LOG_PATH_D;

            // Check if the D: drive exists
            if (!Directory.Exists("D:\\"))
            {
                logPath = FileConstants.LOG_PATH_C;
            }

            try
            {
                FileInfo fileInfo = new FileInfo(logPath);

                // Create file if it doesn't exist
                if (!File.Exists(logPath))
                {
                    using (FileStream fs = File.Create(logPath)) ;
                }

                // Clean file if its size is bigger than MAX_FILE_SIZE
                if (fileInfo.Length > FileConstants.MAX_FILE_SIZE)
                {
                    await File.WriteAllTextAsync(logPath, string.Empty);
                }

                // Write log to the file
                using (StreamWriter writer = new StreamWriter(logPath, true))
                {
                    await writer.WriteLineAsync(log.ToString());
                }
            }
            catch (Exception ex)
            {
                // Log error to console or ignore it silently
                Console.WriteLine($"Failed to write to log file: {ex.Message}");
                // or just ignore the error
            }
        }
    }
}