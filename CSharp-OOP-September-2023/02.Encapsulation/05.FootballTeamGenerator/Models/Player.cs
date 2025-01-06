using System;

namespace FootballTeamGenerator.Models;

public class Player
{
    private const string StatOutOfRangeExceptionMessage = "{0} should be between 0 and 100.";
    private const string NameEmpyExceptionMessage = "A name should not be empty.";

    private const int StatMinValue = 0;
    private const int StatMaxValue = 100;

    private string name;
    private int endurance;
    private int sprint;
    private int dribble;
    private int passing;
    private int shooting;

    public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
    {
        Name = name;
        Endurance = endurance;
        Sprint = sprint;
        Dribble = dribble;
        Passing = passing;
        Shooting = shooting;
    }

    public string Name
    {
        get => name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(NameEmpyExceptionMessage);
            }

            name = value;
        }
    }

    public int Endurance
    {
        get => endurance;
        private set
        {
            if (CheckStatValue(value))
            {
                throw new ArgumentException(string.Format(StatOutOfRangeExceptionMessage, nameof(Endurance)));
            }

            endurance = value;
        }
    }

    public int Sprint
    {
        get => sprint;
        private set
        {
            if (CheckStatValue(value))
            {
                throw new ArgumentException(string.Format(StatOutOfRangeExceptionMessage, nameof(Sprint)));
            }

            sprint = value;
        }
    }

    public int Dribble
    {
        get => dribble;
        private set
        {
            if (CheckStatValue(value))
            {
                throw new ArgumentException(string.Format(StatOutOfRangeExceptionMessage, nameof(Dribble)));
            }

            dribble = value;
        }
    }

    public int Passing
    {
        get => passing;
        private set
        {
            if (CheckStatValue(value))
            {
                throw new ArgumentException(string.Format(StatOutOfRangeExceptionMessage, nameof(Passing)));
            }

            passing = value;
        }
    }

    public int Shooting
    {
        get => shooting;
        private set
        {
            if (CheckStatValue(value))
            {
                throw new ArgumentException(string.Format(StatOutOfRangeExceptionMessage, nameof(Shooting)));
            }

            shooting = value;
        }
    }

    public double Stats => (Endurance + Sprint + Dribble + Passing + Shooting) / 5.0;

    private bool CheckStatValue(int value)
        => value < StatMinValue || value > StatMaxValue;
}
