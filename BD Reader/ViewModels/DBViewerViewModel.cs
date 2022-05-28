using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ReactiveUI;
using System.Reactive;
using BaseRead.Models;
using Microsoft.Data.Sqlite;
using System.IO;
using System;

namespace BaseRead.ViewModels
{
    public class DBViewerViewModel : ViewModelBase
    {
        public ObservableCollection<Table> tables;
        public ObservableCollection<Matches> match;
        public ObservableCollection<Players> players;
        public ObservableCollection<Season_year> Season_year;
        public ObservableCollection<Seasons> Seasons;
        public ObservableCollection<Teams> Teams;
        public ObservableCollection<Table> requests;

        private ObservableCollection<string> FindProperties(string entityName, List<string> properties)
        {
            ObservableCollection<string> result = new ObservableCollection<string>();
            for (int i = 0; i < properties.Count(); i++)
            {
                if (properties[i].IndexOf("EntityType:" + entityName) != -1)
                {
                    try
                    {
                        i++;
                        while (properties[i].IndexOf("(") != -1 && i < properties.Count())
                        {
                            result.Add(properties[i].Remove(properties[i].IndexOf("(")));
                            i++;
                        }
                        return result;
                    }
                    catch
                    {
                        return result;
                    }
                }
            }
            return result;
        }

        public DBViewerViewModel()
        {

                tables = new ObservableCollection<Table>();
                var DataBase = new CricketContext();

                string tableInfo = DataBase.Model.ToDebugString();
                tableInfo = tableInfo.Replace(" ", "");
                string[] splitTableInfo = tableInfo.Split("\r\n");
                List<string> properties = new List<string>(splitTableInfo.Where(str => str.IndexOf("Entity") != -1 ||
                                                            (str.IndexOf("(") != -1 && str.IndexOf("<") == -1) &&
                                                            str.IndexOf("Navigation") == -1 && str.IndexOf("(Matches)") == -1));


                match = new ObservableCollection<Matches>(DataBase.Matches);
                tables.Add(new Table("Matches", false, new MatchesTableViewModel(match), FindProperties("Matches", properties)));
                players = new ObservableCollection<Players>(DataBase.Players);
                tables.Add(new Table("Players", false, new PlayersTableViewModel(players), FindProperties("Players", properties)));
                Season_year = new ObservableCollection<Season_year>(DataBase.Season_year);
                tables.Add(new Table("Season_year", false, new Season_yearTableViewModel(Season_year), FindProperties("Season_year", properties)));
                Seasons = new ObservableCollection<Seasons>(DataBase.Seasons);
                tables.Add(new Table("Seasons", false, new SeasonsTableViewModel(Seasons), FindProperties("Seasons", properties)));
                Teams = new ObservableCollection<Teams>(DataBase.Teams);
                tables.Add(new Table("Teams", false, new TeamsTableViewModel(Teams), FindProperties("Teams", properties)));
        }

        public ObservableCollection<Table> Tables
        {
            get => tables;
            set
            {
                this.RaiseAndSetIfChanged(ref tables, value);
            }
        }
        public ObservableCollection<Matches> Cars
        {
            get => match;
            set
            {
                this.RaiseAndSetIfChanged(ref match, value);
            }
        }
        public ObservableCollection<Table> Requests
        {
            get => requests;
            set
            {
                this.RaiseAndSetIfChanged(ref requests, value);
            }
        }
    }
}
