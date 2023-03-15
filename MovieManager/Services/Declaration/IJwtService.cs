using System;
namespace MovieManager.Services.Declaration
{
	public interface IJwtService
	{
		string GenerateToken(int userId);
		int? ValidateToken(string token);
	}
}

