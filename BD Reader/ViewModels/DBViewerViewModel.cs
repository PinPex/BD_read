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
        private ObservableCollection<Table> tables;
        private ObservableCollection<Matches> match;
        private ObservableCollection<Players> players;
        private ObservableCollection<Season2021> Season2021;
        private ObservableCollection<Season2022> Season2022;
        private ObservableCollection<Seasons> Seasons;

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
                tables.Add(new Table("Матчи", false, new MatchesTableViewModel(match), FindProperties("Matches", properties)));
                players = new ObservableCollection<Players>(DataBase.Players);
                tables.Add(new Table("Игроки", false, new PlayersTableViewModel(players), FindProperties("Players", properties)));
                Season2021 = new ObservableCollection<Season2021>(DataBase.Season2021);
                tables.Add(new Table("Сезон 2021", false, new Season2021TableViewModel(Season2021), FindProperties("Season2021", properties)));
                Season2022 = new ObservableCollection<Season2022>(DataBase.Season2022);
                tables.Add(new Table("Сезон 2022", false, new Season2022TableViewModel(Season2022), FindProperties("Season2022", properties)));
                Seasons = new ObservableCollection<Seasons>(DataBase.Seasons);
                tables.Add(new Table("Все сезоны", false, new SeasonsTableViewModel(Seasons), FindProperties("Seasons", properties)));
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
    }
}
