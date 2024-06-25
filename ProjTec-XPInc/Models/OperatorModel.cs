using System.ComponentModel.DataAnnotations;

namespace ProjTec_XPInc.Models
{
	public class OperatorModel
	{
		[Key]
		public int Id { get; set; }
		public string? Name { get; set; }
		public string Email { get; set; }
		public bool Manager { get; set; }
		public bool Active { get; set; }
	}
}
