using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameDAL.Models;

namespace VideoGameDAL.Data
{
    public class VideoGameContext : DbContext
    {

        public VideoGameContext(DbContextOptions<VideoGameContext> options) : base(options)
        {
            // If we need to do something with options, do it here...
        }

        public DbSet<Game> Games { get; set; }
    }
}
