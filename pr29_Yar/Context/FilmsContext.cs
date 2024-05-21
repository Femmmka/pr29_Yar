using Microsoft.EntityFrameworkCore;
using pr29_Yar.Classes.Common;
using pr29_Yar.Classes;
using pr29_Yar.Model;
using System.Collections.ObjectModel;


namespace pr29_Yar.Context
{
    public class FilmsContext : DbContext
    {
    public DbSet<Films> Films { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseMySql(Config.ConnectionConfig, Config.Version);

    public FilmsContext() => Database.EnsureCreated();

    public static ObservableCollection<Films> AllCourses()
    {
        using FilmsContext context = new();
        return new ObservableCollection<Films>(context.Films);
    }

    public void Save(Films filmsItem, bool isNew)
    {
        using FilmsContext context = new();
        if (isNew)
        {
            context.Films.Add(filmsItem);
        }
        else
        {
            context.Films.Update(filmsItem);
        }
        context.SaveChanges();
    }

    public void Delete(Films filmsItem)
    {
        using FilmsContext context = new();
        context.Films.Remove(filmsItem);
        context.SaveChanges();
    }

    public RelayCommand OnSave
    {
        get
        {
            return new RelayCommand(obj =>
            {
                if (obj is Films filmsItem)
                {
                    Save(filmsItem, filmsItem.Id == 0);
                    MainWindow.init?.frame.Navigate(new View.Films.Main());
                }
            });
        }
    }
}
}
