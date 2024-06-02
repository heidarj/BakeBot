using BakeBot.Models;

namespace BakeBot.Extensions;
public static class TimeSpanExtensions
{
	public static TimeSpan? AddNullable(this TimeSpan? first, TimeSpan? second)
	{
		if (first.HasValue && second.HasValue)
		{
			return first.Value.Add(second.Value);
		}
		else if (first.HasValue)
		{
			return first.Value;
		}
		else if (second.HasValue)
		{
			return second.Value;
		}
		else
		{
			return TimeSpan.Zero;
		}
	}

	public static TimeSpan TotalTime(this Recipe recipe)
    {
        return recipe.PreparationTime.AddNullable(recipe.CookingTime) ?? TimeSpan.Zero;
    }
}