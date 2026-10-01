namespace Scope_India.DAL
{
    public class ChatbotService : IChatbotService
    {
        private readonly Dictionary<string[], string> _faq = new()
        {
            { new[] { "course", "courses", "offer" }, "We offer courses in Web Development, Data Science, Cloud Computing, and Cybersecurity. Check the Courses page for full details." },
            { new[] { "fee", "fees", "cost", "price" }, "Course fees vary by program. Visit the specific course page for exact pricing." },
            { new[] { "register", "registration", "enroll", "sign up" }, "You can register from the Registration page — click 'Register' in the top menu." },
            { new[] { "duration", "how long", "time" }, "Course durations typically range from 6 weeks to 6 months depending on the program." },
            { new[] { "contact", "phone", "email", "reach" }, "You can reach us via the Contact Us page, or email info@scopeindia.org." },
            { new[] { "login", "sign in" }, "Use the Login page with your registered email and password." },
            { new[] { "password", "forgot" }, "Click 'Forgot Password' on the login page to reset it via email." },
            { new[] { "certificate", "certification" }, "Yes, a certificate is provided upon successful completion of each course." }
        };

        public string GetAnswer(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return "Please type a question and I'll try to help!";

            var lowerQuery = query.ToLower();

            foreach (var entry in _faq)
            {
                if (entry.Key.Any(keyword => lowerQuery.Contains(keyword)))
                    return entry.Value;
            }

            return "Sorry, I couldn't find an answer to that. Please contact us at info@scopeindia.org for further help.";
        }
    }
}