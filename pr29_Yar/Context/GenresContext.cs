using Microsoft.EntityFrameworkCore;
using pr29_Yar.Classes.Common;
using pr29_Yar.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pr29_Yar.Model;

namespace pr29_Yar.Context
{
    public class GenresContext : DbContext
    {
        public DbSet<Genres> Genres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseMySql(Config.ConnectionConfig, Config.Version);

        public GenresContext() => Database.EnsureCreated();
        public static ObservableCollection<Genres> AllTeachers()
        {
            using GenresContext context = new();
            return new ObservableCollection<Genres>([.. context.Genres]);
        }

        public void Save(Genres genresItem, bool isNew)
        {
            using GenresContext context = new();
            if (isNew)
            {
                context.Genres.Add(genresItem);
            }
            else
            {
                genresItem.Films = null;
                context.Genres.Update(genresItem);
            }
            context.SaveChanges();
        }

        public void Delete(Genres genresItem)
        {
            Genres.Remove(genresItem);
            SaveChanges();
        }

        public RelayCommand OnSave
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (obj is Genres genresItem)
                    {
                        Save(genresItem, genresItem.Id == 0);
                        MainWindow.init?.frame.Navigate(new View.Genres.Main());
                    }
                });
            }
        }
    }
}
