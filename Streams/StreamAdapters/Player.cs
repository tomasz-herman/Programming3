using System.Numerics;

namespace StreamAdapters;

public record Player(string Name, int Health, long Experience, long Money, Vector2 Position);