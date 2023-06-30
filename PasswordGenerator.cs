using System;

public class PasswordGenerator
{
    private int timer;
    public PasswordGenerator(int timer)
    {
        this.timer = timer;
    }

    public string GeneratePassword(string userId, DateTime dateTime)
    {
        string combinedString = $"{userId}_{dateTime.ToString("yyyyMMddHHmmss")}";
        byte[] byteData = System.Text.Encoding.UTF8.GetBytes(combinedString);
        byte[] hashBytes;
        using (System.Security.Cryptography.SHA256 sha256 = System.Security.Cryptography.SHA256.Create())
        {
            hashBytes = sha256.ComputeHash(byteData);
        }
        int passwordLength = 6;
        string password = BitConverter.ToString(hashBytes, 0, passwordLength).Replace("-", "");
        return password;
    }

    public bool IsPasswordValid(string userId, DateTime dateTime, string password)
    {
        string generatedPassword = GeneratePassword(userId, dateTime);
        bool isValid = string.Equals(password, generatedPassword, StringComparison.OrdinalIgnoreCase);
        DateTime currentDateTime = DateTime.Now;
        bool isExpired = currentDateTime > dateTime.AddSeconds(timer);
        return isValid && !isExpired;
    }
}
