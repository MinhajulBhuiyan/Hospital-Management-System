using System;

namespace Hospital_Management_System
{
    public class ExceptionHandler
    {
        // Method to handle exceptions and log error messages
        public void HandleError(Exception ex)
        {
            // Implement logic to handle exceptions, log error messages, or perform any necessary actions
            Console.WriteLine($"Error: {ex.Message}");
        }

        // Method to create a formatted error message
        public string CreateErrorMessage(string errorDescription)
        {
            // Implement logic to create a formatted error message
            return $"Error: {errorDescription}";
        }
    }
} 