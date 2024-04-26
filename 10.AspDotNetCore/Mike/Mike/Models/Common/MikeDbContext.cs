using Microsoft.EntityFrameworkCore;
using Mike.Models.Entities;

namespace Mike.Models.Common
{
    public class MikeDbContext : DbContext
    {
        public MikeDbContext(DbContextOptions<MikeDbContext> options) : base(options) { }

        #region DbSet
        public DbSet<Navigation> Navigations { get; set; }

        public DbSet<Announcement> Announcements { get; set; }

        public DbSet<New> News { get; set; }

        public DbSet<ImageGallery> ImageGalleries{ get; set; }
        public DbSet<VideoGallery> VideoGalleries{ get; set; }
        public DbSet<DocumentCategory> DocumentCategories{ get; set; }
        public DbSet<Document> Documents{ get; set; }
        public DbSet<QuickLink> QuickLinks{ get; set; }
        public DbSet<Event> Events{ get; set; }

        public DbSet<How> Hows{ get; set; }

        #endregion
    }
}
