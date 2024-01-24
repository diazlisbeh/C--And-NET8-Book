using WorkingWithEFCore;

using NorthwindDb db = new();
WriteLine($"Provider: {db.Database.ProviderName}");