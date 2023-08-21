using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KitchenRental.DataAccess.Models.DataTransferObjects
{
	public class EquipmentDto
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Required]
		[StringLength(50)]
		public string Name { get; set; }
	}
}