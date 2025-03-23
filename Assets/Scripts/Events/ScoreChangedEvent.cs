namespace Events
{
    public class ScoreChangedEvent
    {
        public readonly int Score;

        public ScoreChangedEvent(int score)
        {
            Score = score;
        }
    }
}