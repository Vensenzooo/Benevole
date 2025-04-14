using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Benevole.Models
{
    [Table("Benevole")]
    public class BenevoleModel
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Le nom est requis")]
        [StringLength(100)]
        public string Nom { get; set; }
        
        [Required(ErrorMessage = "Le prenom est requis")]
        [StringLength(100)]
        public string Prenom { get; set; }
        
        [Required(ErrorMessage = "Le courriel est requis")]
        [EmailAddress(ErrorMessage = "Le format du courriel n'est pas valide")]
        [StringLength(100)]
        public string Courriel { get; set; }
        
        [Phone(ErrorMessage = "Le format du numero de telephone n'est pas valide")]
        [StringLength(20)]
        public string? Telephone { get; set; }
    }

    public class BenevoleContext : DbContext
    {
        public BenevoleContext(DbContextOptions<BenevoleContext> options) : base(options) { }

        public DbSet<BenevoleModel> Benevoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BenevoleModel>().ToTable("Benevole");
        }
    }
}