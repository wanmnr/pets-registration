namespace PetFriendsApp.Helpers
{
    public static class InputHelper
    {
        // Method to get user input with a prompt
        public static string GetUserInput(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine()?.Trim() ?? string.Empty;
        }

        // Method to validate user input with a custom validation function
        public static string GetValidatedInput(string prompt, Func<string, bool> validationFunc)
        {
            string input;
            do
            {
                input = GetUserInput(prompt);
            } while (!validationFunc(input));

            return input;
        }

        // Method to get optional input with a default value
        public static string GetOptionalInput(string prompt, string defaultValue)
        {
            string input = GetUserInput(prompt);
            return string.IsNullOrWhiteSpace(input) ? defaultValue : input;
        }
    }
}
