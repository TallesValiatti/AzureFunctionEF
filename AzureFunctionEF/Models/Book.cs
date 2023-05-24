using System;
namespace AzureFunctionEF.Models
{
	public class Book
	{
		public Guid Id { get; set; }

		public string Name { get; set; } = default!;
    }
}