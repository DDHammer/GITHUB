// THE PROMPT GENERATOR CLASS
public class PromptGenerator
{
    public List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was something fun you did today?",
        "If I had one thing I could do over today, what would it be?",
        "What do you want to do tomorrow?",
        "What is the most fun thing you did today?"
    };
    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}