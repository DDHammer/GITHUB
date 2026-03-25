// --- One and done ---
    public class SimpleGoal : Goal
    {
        private bool _isComplete;
        public SimpleGoal(string name, string desc, int points, bool complete = false) : base(name, desc, points) => _isComplete = complete;
        public override int RecordEvent()
        {
            if (_isComplete) return 0;
            _isComplete = true;
            return _points;
        }
        public override bool IsComplete() => _isComplete;
        public override string GetStringRepresentation() => $"SimpleGoal:{_shortName},{_description},{_points},{_isComplete}";
    }