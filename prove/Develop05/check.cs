// ---Checklist Goal---
    public class ChecklistGoal : Goal
    {
        private int _amountCompleted;
        private int _target;
        private int _bonus;
        public ChecklistGoal(string name, string desc, int pts, int target, int bonus, int current = 0) : base(name, desc, pts)
        {
            _target = target;
            _bonus = bonus;
            _amountCompleted = current;
        }
        public override int RecordEvent()
        {
            _amountCompleted++;
            return (_amountCompleted == _target) ? _points + _bonus : _points;
        }
        public override bool IsComplete() => _amountCompleted >= _target;
        public override string GetDetailsString()
        {
            return base.GetDetailsString() + $" -- Currently completed: {_amountCompleted}/{_target}";
        }
        public override string GetStringRepresentation() => $"ChecklistGoal:{_shortName},{_description},{_points},{_amountCompleted},{_target},{_bonus}";
    }
