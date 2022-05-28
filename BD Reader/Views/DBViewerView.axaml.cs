using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using BaseRead.ViewModels;
using BaseRead.Models;
using BaseRead.Views;
using Microsoft.Data.Sqlite;
using System.IO;

namespace BaseRead.Views
{
    public partial class DBViewerView : UserControl
    {
        public DBViewerView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void DeleteTab(object control, RoutedEventArgs args)
        {
            Button? btn = control as Button;
            if (btn != null)
            {
                DBViewerViewModel? context = this.DataContext as DBViewerViewModel;
                if (context != null)
                {
                    context.Tables.Remove(btn.DataContext as Table);
                }
            }
        }
        
        private void AddStroke(object control, RoutedEventArgs args)
        {
            Button? btn = control as Button;
            DBViewerViewModel? context = this?.DataContext as DBViewerViewModel;
            Table table_name = this.FindControl<TabControl>("nameTables").SelectedItem as Table;
            string table_n = table_name.Name.ToString();
            if (btn != null)
            {
                if (table_n == "Matches")
                {
                    Matches temp = new Matches();
                    temp.Player_of_match = null;
                    temp.Vennue = null;
                    temp.Match = null;
                    temp.Match_conditions = null;
                    temp.Points = null;
                    temp.Toss = null;
                    context.match.Add(temp);
                }
                if (table_n == "Players")
                {
                    Players temp = new Players();
                    temp.Born = null;
                    temp.FullName = null;
                    temp.Bowls = null;
                    temp.Bats = null;
                    temp.Matches = null;
                    context.players.Add(temp);
                }
                if (table_n == "Season_year")
                {
                    Season_year temp = new Season_year();
                    temp.Result = null;
                    temp.Date_Year = null;
                    temp.Date_month_day = null;
                    temp.Teams = null;
                    temp.Ground = null;
                    temp.Id = null;
                    temp.Match = null;
                    context.Season_year.Add(temp);
                }
                if (table_n == "Seasons")
                {
                    Seasons temp = new Seasons();
                    temp.Year = null;
                    temp.Winner = null;
                    context.Seasons.Add(temp);
                }
                if (table_n == "Teams")
                {
                    Teams temp = new Teams();
                    temp.Team_name = null;
                    temp.Match = null;
                    temp.Id = null;
                    temp.Players = null;
                    context.Teams.Add(temp);
                }
                
            }
        }
        private void DeleteStroke(object control, RoutedEventArgs args)
        {
            Button? btn = control as Button;
            DBViewerViewModel? context = this?.DataContext as DBViewerViewModel;
            if (btn != null)
            {
            }
        }
        private void SaveTab(object control, RoutedEventArgs args)
        {
            Button? btn = control as Button;
            DBViewerViewModel? context = this?.DataContext as DBViewerViewModel;
            Table table_name = this.FindControl<TabControl>("nameTables").SelectedItem as Table;
            string table_n = table_name.Name.ToString();
            string DbPath = @"Assets\cricket.db";
            string directoryPath = Directory.GetCurrentDirectory();
            directoryPath = directoryPath.Remove(directoryPath.LastIndexOf("bin"));
            DbPath = directoryPath + DbPath;
            SqliteConnection con = new SqliteConnection("Data source=" + DbPath + ";Foreign Keys=False");
            SqliteCommand com = new SqliteCommand();
            
            con.Open();
            com.Connection = con;
            com.CommandText = "DROP TABLE IF EXISTS " + table_n + ";";
            com.ExecuteNonQuery();
            if (btn != null)
            {
                if (table_n == "Matches")
                {
                    foreach(Matches i in context.match)
                    {
                        com.CommandText = "CREATE TABLE IF NOT EXISTS " + table_n + "(Match TEXT PRIMARY KEY, Vennue TEXT, Match_conditions TEXT, Toss TEXT, Player_of_match TEXT, Points TEXT)";
                        com.ExecuteNonQuery();
                        com.CommandText = "INSERT INTO " + table_n + " VALUES('" + i.Match + "','" + i.Vennue.Replace("'","") + "','" + i.Match_conditions + "','" 
                            + i.Toss + "','" + i.Player_of_match + "','" + i.Points + "')";
                        com.ExecuteNonQuery();
                    }
                    
                }
                if (table_n == "Players")
                {
                    foreach (Players i in context.players)
                    {
                        com.CommandText = "CREATE TABLE IF NOT EXISTS " + table_n + "(FullName TEXT PRIMARY KEY, Born TEXT, Bats TEXT, Bowls TEXT, Matches TEXT)";
                        com.ExecuteNonQuery();
                        com.CommandText = "INSERT INTO " + table_n + " VALUES('" + i.FullName.Replace("'","") + "','" + i.Born + "','" + i.Bats + "','" +  i.Bowls + "','" + i.Matches + "')";
                        com.ExecuteNonQuery();
                    }
                }
                if (table_n == "Season_year")
                {
                    foreach (Season_year i in context.Season_year)
                    {
                        com.CommandText = "CREATE TABLE IF NOT EXISTS " + table_n + "(Id INT PRIMARY KEY, Match TEXT, Date_Year TEXT, Date_month_day TEXT, Teams TEXT, Ground TEXT, Result TEXT)";
                        com.ExecuteNonQuery();
                        com.CommandText = "INSERT INTO " + table_n + " VALUES(" + i.Id.ToString() + ",'" + i.Match + "','" + i.Date_Year + "','" + i.Date_month_day + "','" + i.Teams + "','" + i.Ground + "','" + i.Result + "')";
                        com.ExecuteNonQuery();
                    }
                }
                if (table_n == "Seasons")
                {
                    foreach (Seasons i in context.Seasons)
                    {
                        com.CommandText = "CREATE TABLE IF NOT EXISTS " + table_n + "(Year TEXT PRIMARY KEY, Winner TEXT)";
                        com.ExecuteNonQuery();
                        com.CommandText = "INSERT INTO " + table_n + " VALUES('" + i.Year + "','" + i.Winner + "')";
                        com.ExecuteNonQuery();
                    }
                }
                if (table_n == "Teams")
                {
                    foreach (Teams i in context.Teams)
                    {
                        com.CommandText = "CREATE TABLE IF NOT EXISTS " + table_n + "(Id INT PRIMARY KEY, Team_name TEXT, Players TEXT, Match TEXT)";
                        com.ExecuteNonQuery();
                        com.CommandText = "INSERT INTO " + table_n + " VALUES(" + i.Id.ToString() + ",'" + i.Team_name + "','" + i.Players.Replace("'", "") + "','" + i.Match + "')";
                        com.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
